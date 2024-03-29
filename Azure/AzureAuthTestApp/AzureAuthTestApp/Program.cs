using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Initialise Authentication services for the app, using OpenIdConnect as the authentication scheme
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    // Use Azure AD as the identity provider, using the parameters defined in appsettings.json to communicate
    // with the Azure AD instance:
    .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"))
    // To support getting user delegation key using user's token acquisition:
    .EnableTokenAcquisitionToCallDownstreamApi(new string[] { "user.read" })
    .AddInMemoryTokenCaches();

// Enable and user Razor pages:
builder.Services.AddRazorPages()
    // Add authentication policy and require users to be authenticated to use the app (for all pages)
    // If an action/page is accessible without authentication, it will be decorated with [AllowAnonymous]
    .AddMvcOptions(options =>
    {
        var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        options.Filters.Add(new AuthorizeFilter(policy));
    })
    // Add default UI pages for sign in, sign out etc. This also add the nice error message if I try to access 
    // a page I'm not authorised for (e.g. "Access Denied" instead of some generic http not found error)
    .AddMicrosoftIdentityUI();

// Add Autofac for DI:
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(bld =>
{
    bld.RegisterInstance(configuration).As<IConfiguration>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();   // Require in order to support the Sign In/Out pages 

app.Run();
