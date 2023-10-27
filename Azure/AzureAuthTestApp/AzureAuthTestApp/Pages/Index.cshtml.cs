using Azure;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcoreapp.Pages;

public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IConfiguration configuration, ILogger<IndexModel> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnGetImageFromBlob()
    {
        const String accountName = "sarahrg4491storage";
        const String storageAccountName = $"https://{accountName}.blob.core.windows.net";
        
        var userDelegationKey = await GetDelegationKeyUsingServicePrincipal(storageAccountName);
        var imageSasUri = GetSasUriUsingDelegationKey(userDelegationKey, accountName, storageAccountName);
        var blobClientSas = new BlobClient(imageSasUri);
        
        return await DownloadAndReturnImageResult(blobClientSas);

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
