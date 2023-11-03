using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Web;

namespace aspnetcoreapp.Pages;

public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<IndexModel> _logger;
    private readonly ITokenAcquisition _tokenAcquisition;

    public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger, ITokenAcquisition tokenAcquisition)
    {
        _configuration = configuration;
        _logger = logger;
        _tokenAcquisition = tokenAcquisition;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnGetImageFromBlob()
    {
        const String accountName = "sarahrg4491storage";
        const String storageAccountName = $"https://{accountName}.blob.core.windows.net";
        
        // Experiment with different types of permissions for getting the image from the blob storage account: 
        //var userDelegationKey = await GetDelegationKeyUsingServicePrincipal(storageAccountName);
        var userDelegationKey = await GetUserDelegationKeyUsingDefaultCredentials(storageAccountName);
        //var userDelegationKey = await GetUserDelegationKeyUsingUserCredentials(storageAccountName);
        
        var imageSasUri = GetSasUriUsingDelegationKey(userDelegationKey, accountName, storageAccountName);
        var blobClientSas = new BlobClient(imageSasUri);
        
        return await DownloadAndReturnImageResult(blobClientSas);

    }
    
    public async Task<IActionResult> OnGetImageSasUriFromBlob()
    {
        const String accountName = "sarahrg4491storage";
        const String storageAccountName = $"https://{accountName}.blob.core.windows.net";
        
        // Experiment with different types of permissions for getting the image from the blob storage account: 
        //var userDelegationKey = await GetDelegationKeyUsingServicePrincipal(storageAccountName);
        var userDelegationKey = await GetUserDelegationKeyUsingDefaultCredentials(storageAccountName);
        //var userDelegationKey = await GetUserDelegationKeyUsingUserCredentials(storageAccountName);
        
        var imageSasUri = GetSasUriUsingDelegationKey(userDelegationKey, accountName, storageAccountName);

        return new JsonResult(new {success = true, imageSasUri});
    }

    private static async Task<IActionResult> DownloadAndReturnImageResult(BlobClient blobClientSas)
    {
        try
        {
            // download the image to memory stream:
            using (var memoryStream = new MemoryStream())
            {
                await blobClientSas.DownloadToAsync(memoryStream);

                // Convert to Base64:
                var imageBytes = memoryStream.ToArray();
                var base64Image = Convert.ToBase64String(imageBytes);

                return new JsonResult(new { success = true, imageData = base64Image });
            }
        }
        catch
        {
            return new JsonResult(new { success = false });
        }
    }

    private async Task<Response<UserDelegationKey>> GetUserDelegationKeyUsingDefaultCredentials(string storageAccountName)
    {
        // using DefaultAzureCredential() - will get Azure to automatically try different types of credentials 
        // (ServicePrincipal, Managed Identity etc) until it finds one that works and use it:  
       var blobServiceClient = new BlobServiceClient(new Uri(storageAccountName), new DefaultAzureCredential());
        
        // Get a user delegation key for the Blob service that's valid for 2 hours.
        // This call takes a lot of time (~15 seconds). We probably want to run this in the background in advance to allow
        // more time for it to finish before we actually need the key.
        var userDelegationKey =  await blobServiceClient.GetUserDelegationKeyAsync(DateTimeOffset.UtcNow,
            DateTimeOffset.UtcNow.AddMinutes(30));
        
        return userDelegationKey;
    }
    
    
    // NOTE: this method currently doesn't work - I need to fix the caching to check if the token is not caches, to
    // get it before continuing. Also need to set up the cachign method in program.cs.
    private async Task<Response<UserDelegationKey>> GetUserDelegationKeyUsingUserCredentials(string storageAccountName)
    {
        const string scope = "https://storage.azure.com/user_impersonation";
        string userAccessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });
        
        // Here, you'll have to know or estimate the expiration of your token.
        var tokenCredential = new StaticTokenCredential(userAccessToken, DateTimeOffset.UtcNow.AddHours(1));
 
        // using DefaultAzureCredential() - will get Azure to automatically try different types of credentials 
        // (ServicePrincipal, Managed Identity etc) until it finds one that works and use it:  
        var blobServiceClient = new BlobServiceClient(new Uri(storageAccountName), tokenCredential);
        
        // Get a user delegation key for the Blob service that's valid for 2 hours.
        // This call takes a lot of time (~15 seconds). We probably want to run this in the background in advance to allow
        // more time for it to finish before we actually need the key.
        var userDelegationKey =  await blobServiceClient.GetUserDelegationKeyAsync(DateTimeOffset.UtcNow,
            DateTimeOffset.UtcNow.AddMinutes(30));
        
        return userDelegationKey;
    }
    
    
    // Use the application's Service Principal to request and return a delegation key for this application
    // Note: this is the 1st step, to see how to use Service Principal to get access to the Storage Blob.
    // The next step will be to get a delegation key specific for each user.
    async Task<Response<UserDelegationKey>> GetDelegationKeyUsingServicePrincipal(String storageAccountName)
    {
        var applicationId = _configuration["AzureAd:ApplicationId"];
        var servicePrincipalSecret = _configuration["AzureAd:ServicePrincipalSecret"];
        var tenantId = _configuration["AzureAd:TenantId"];
        
        var clientSecretCredential = new ClientSecretCredential(tenantId, applicationId, servicePrincipalSecret);
        var blobServiceClient = new BlobServiceClient(new Uri(storageAccountName), clientSecretCredential);
        var delegationKey = await blobServiceClient
            .GetUserDelegationKeyAsync(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddMinutes(30));
        return delegationKey;
    }

    // Generate the Shared Access Signature (SAS) and return the image-blob's Uri using it.
    // For additional information on SAS, see https://learn.microsoft.com/en-us/azure/storage/common/storage-sas-overview
    Uri GetSasUriUsingDelegationKey(Response<UserDelegationKey> userDelegationKey, String accountName, String storageAccountName)
    {
        const String containerName = "images";
        const String imageName = "Lioness.jpg";
        
        var sasBuilder = new BlobSasBuilder()
        {
            BlobContainerName   = containerName,
            BlobName = imageName,
            Resource = "b",
            StartsOn = DateTimeOffset.UtcNow.AddMinutes(-5),
            ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(20),
        };
        sasBuilder.SetPermissions(BlobSasPermissions.Read);

        var blobUriBuilder = new BlobUriBuilder(new Uri($"{storageAccountName}/{containerName}/{imageName}"))
        {
            Sas = sasBuilder.ToSasQueryParameters(userDelegationKey, accountName)
        };

        return blobUriBuilder.ToUri();
    }
}

public class StaticTokenCredential : TokenCredential
{
    private readonly AccessToken _token;

    public StaticTokenCredential(string token, DateTimeOffset expiresOn)
    {
        _token = new AccessToken(token, expiresOn);
    }

    public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return _token;
    }

    public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
    {
        return new ValueTask<AccessToken>(_token);
    }
}
