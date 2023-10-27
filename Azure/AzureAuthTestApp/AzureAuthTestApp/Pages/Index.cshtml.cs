using Azure.Storage.Blobs;
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
        const String imageUri = "https://sarahrg4491storage.blob.core.windows.net/images/Lioness.jpg";
        const String containerName = "images";
        const String imageName = "Lioness.jpg";

        var blobConnectionString = _configuration["StorageAccount:ConnectionString"];

        var blobServiceClient = new BlobServiceClient(blobConnectionString);
        var imageContainer = blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = imageContainer.GetBlobClient(imageName);

        try
        {
            // download the image to memory stream:
            using (var memoryStream = new MemoryStream())
            {
                await blobClient.DownloadToAsync(memoryStream);

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
}
