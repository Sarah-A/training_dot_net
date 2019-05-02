# ASP .Net MVC 5 - Video Rental Application
This project was created as part of the Udemy 'The Complete ASP .Net MVC 5 Course'. It includes different features of the ASP .Net framework and different technologies as learned in the course. It includes both features that were developed following the course and features developed independently as excercises</br>
**Note:** Since this project is a 'learning project' and not a full working application, it was more important for me to show how to work with the different technologies. Therefore:
1. Not all the functionality that you would expect from a video rental store is implemented.
1. Different operations are implemented differently. For example: Adding/editing movies is limited to logged in admins only while editing customers is open to everyone. 
1. Since this course wasn't about html/css/bootstrap, I didn't put much work into them. I concentrated on the ASP .Net MVC and related frameworks/libraries only.

In this project, I used:
* HTML, CSS, JavaScript, Bootstrap, jQuery, Ajax
* ASP .Net MVC 5, Razor, Web API 2, Entity Framework, Identity Framework, OAuth 2.0 
* Additional ASP .Net Libraries: AutoMapper, Elmah and Glimpse (for debugging and profiling).
* Additional jQuery libraries: DataTables, Typeahead, validation, toastr.

Some interesting additional notes:
* The Login/Logout mechanism uses Identity Framework. I also implemented login through Facebook, using OAuth 2.0. Other social media outlets can be added in a similar way. 
* The Movies page uses Identity to show either the read-only list (for regular users) or the full editable list for admins. In addition, it uses jQuery's DataTables library for rendering a searchable and sortable table. It uses Ajax and the backend's Web API controllers to return and display the data in DTOs. AutoMapper is used for translating between the Web API's DTOs and the internal domain objects for sercurity and stability.
* In a similar way, ViewModels are used to transfer data between the model objects and the main views in order to decouple the views from the model and add a layer of security between them. In addition, the ViewModels allow me to display only specific fields according to the view, without leaking additional fields to the users. 
* The Rental Page uses Typeahead jQuery library to get suggested Customer/Movie from the backend (through Ajax call to the Web API controller) and uses jQuery validation library in order to validate the form before Submitting (through Ajax) to the server.
* The Web API controllers actions (see under Controllers/Api) are also availabe through direct http requests.

## Development Environment:

### Installations
Make sure that the following tools are installed on your system in order to clone the code and develop/debug it on your PC:
* Git (<http://git-scm.com/downloads>)
* Visual Studio Community 2017 (<https://visualstudio.microsoft.com/downloads/>)

Additional Recommended Tools:
* Postman - for working with and debugging the Web API (<https://www.getpostman.com/>)


### Clone, Build and Run Project
1. Clone the repository: 
    ```
    > git clone https://github.com/Sarah-A/training_dot_net
    ```  
1. Copy `AppSecretSettings.config.sample` as `AppSecretSettings.config` and change all its keys to actual values. You can leave the values as they are in the sample file but you won't be able to use the related functionality until you update them. 
1. Open : `training_dot_net\Web\AspDotNetCourseApp\AspDotNetCourseApp.sln` in Visual Studio 2017.<br /> 
_Note:_ After openning the solution, Visual Studio will display a few errors because of missing NuGet packages. This is fine and will be fixed once you build the solution in the next step.
1. Build -> Build Solution. Visual Studio will install all the required NuGet packages and build the project.
1. Open Package Manger Console and run the following to create the database and seed it:
    ```
    PM> Update-database
    ```
1. Debug -> Start With/out Debugging
1. Your default browser should open automatically to the correct address. If it doesn't, open your project's Properties -> Web -> Project Url and copy it to your browser.
1. The following Users are pre-configured for demonstrating  working with regular users and admin:
    * Regular user: User: user@example.com Password: P@ssw0rd!
        regular users will have full access to the 'Customers' and 'Rent' pages but read-only access to the 'Movies' page.
        This is just to demonstrate limiting access to pages/functionality.
    * Admin user: User: admin@example.com Password: P@ssw0rd!
        admin users will have full access to all pages.




