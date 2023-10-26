# Azure Authentication and Authorization Test ASP.Net Razor Web App

- Added Authentication (OIDC) and Authorization (OAuth 2.0) through Identity Providers
  - Added both Microsoft and GitHub as identity providers 
  - verified that I can access the app only using my authenticated user (ash..) and not using a different, unauthenticated user (asa...)  
- Added `Standard User` and `Application Admin` roles and assigned different users to each.
  - Verified that only the Admin can access the `Admin` page. 
- Added UI interface to support Sign In/Out


See [ASP.Net Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio) for general structure of the code.

## Development Environment:

### Deploy app to Azure:
> az login <br>
> az webapp up --sku F1 --name azureauthtestapp --os-type windows --location australiaeast

__To Redeploy app:__
> az webapp up

### Add Identity Providers
1. In Azure Portal, find your `app -> Authentication -> Add Identity Provider`
2. Enter your application's Client Id and Secret Id (see your application in Azure Portal -> Certificates and Secrets to see them) 

### Add Users:
1. In `Azure Portal -> Microsoft Entra ID -> Users` - Add User
2. Add the email and send an invitation. Once the user accept the invitation, they will be added to the users and then you'll be able to assign roles to them.

### Add Groups:
1. In `Azure Portal -> Microsoft Entra ID -> Groups` - Add Group
2. Add a new group and choose users to add to it.
Note: I can't use groups to define application roles since I'm on free account. Therefore, I'll use individual users for now.

### Add App Roles:
1. In `Microsoft Entra Admin Center -> Applications -> {application name} -> App roles`, add roles.
2. I defined:
  - Application Admin 
  - Standard User 

### Assign Roles to Users
In `Azure Portal -> Microsoft Entra ID -> Enterprise applications -> Open application -> Users and Groups`:
1. Add user/group
2. Choose Role to assign to the user.



__TODO:__
- [ ] Add Google as identity provider
- [ ] Add roles and users.