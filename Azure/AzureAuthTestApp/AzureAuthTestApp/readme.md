# Azure Authentication and Authorization Test ASP.Net Razor Web App

- Added Authentication (OIDC) and Authorization (OAuth 2.0) through Identity Providers
  - Added both Microsoft and GitHub as identity providers 
  - verified that I can access the app only using my authenticated user (ash..) and not using a different, unauthenticated user (asa...)  
- Added `Standard User` and `Application Admin` roles and assigned different users to each.
  - Verified that only the Admin can access the `Admin` page. 
- Added UI interface to support Sign In/Out
- Wired up Autofac so that I can inject the configuration into controllers and use parameters in secrets.json
- Set up a blob storage account, added a "Read only" role to it and assigned it to my app, using Azure Portal (`{My storage account -> IAM -> Add Role Assignment -> Storage Blob Data Reader -> User, group or service principal -> application name` - see [instructions](https://learn.microsoft.com/en-us/entra/identity-platform/howto-create-service-principal-portal)
  - Uploaded an image to it (manually through the Portal)
  - Verified that I can access and download the image using the connection string (copied from `{my storage account} -> Access keys`)
- Created a new Service Principal for my app (on Azure Side: `Entra ID -> App registrations -> {my app} -> Certificates & secrets -> add new client secret`)
- Used the Service Principal to get a userDelegatedKey in order to get a Shared Access Signature (SAS) will limited permissions and shorter expiry time to download the image.
  - Note: this allows me to remove the usage of the connection string which is not secure because it doesn't have an expiration time and doesn't require any additional permissions to access the resource (so will compromise the resource if exposed)
  - Verified that the image still downloads correctly. 
- Used DefaultAzureCredential() to have Azure automatically try different types of credentials (e.g. ServicePrincipal, Managed Identity etc) until it finds one that works and use it.
  - Verified that this works when I remove the ServicePrincipal secret.
  - Drawback: this still uses the applicaiton credentials rather then the user-specific credentials for getting the image blob. I didn't have time to change the implementation to use user-specific delegation keys to resolve this issue.

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
