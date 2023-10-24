# Azure Authentication and Authorization Test ASP.Net Razor Web App

- Added Authentication (OIDC) and Authorization (OAuth 2.0) through Identity Providers (in Azure Portal: `app service -> Authentication -> Add Provider`) 
  - verified that I can access the app only using my authenticated user (ash..) and not using a different, unauthenticated user (sar...)
- 






See [ASP.Net Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio) for general structure of the code.


## Development Environment:

### Deploy app to Azure:
> az login <br>
> az webapp up --sku F1 --name azureauthtestapp --os-type windows --location australiaeast

__To Redeploy app:__
> az webapp up


__TODO:__
- [ ] Add Google as identity provider
- [ ] Add rol