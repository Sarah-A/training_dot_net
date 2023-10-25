using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcoreapp.Pages;

[Authorize(Roles = "AppRoles.Admin")]
public class AdminModel : PageModel
{
    private readonly ILogger<AdminModel> _logger;

    public AdminModel(ILogger<AdminModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

