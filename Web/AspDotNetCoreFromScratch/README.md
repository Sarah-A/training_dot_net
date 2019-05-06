# ASP .Net Core From Scratch 
This project was created as part of the Pluralsight Asp .Net Core course. It includes different features of the ASP .Net Core framework and different technologies as learned in the course. It includes all  features that were developed following the course</br>
**Note:** Since this project is a 'learning project' and not a full working application, it was more important for me to show how to work with the different technologies. Therefore:
1. Not all the functionality that you would expect from a shopping site is implemented.
1. Since this course wasn't about html/css/bootstrap, I didn't put much work into them. I concentrated on the ASP .Net Core and related frameworks/libraries only.

In this project, I used:
* HTML, CSS, JavaScript, TypeScript, Bootstrap, jQuery
* ASP .Net Core,  MVC , Razor, Entity Framework Core, Core Identity, Web API, Angular. 

Some interesting additional notes:
* To demonstrate the internal working of the ASP .Net Core and additional frameworks, this project was developed from the gound up from an empty project template, without using any of the ASP .Net Core build-in templates.
* The 'Shop' page was developed as an Angular application (implemented under 'ClientApp' directory). It includes the products list, the checkout and login services. It communicate with the backend API through HttpClient.
* The 'Shop' page is open to all users (no need to login). However, the Checkout is only available to logged-in users.
* For testing and demonstration, I seeded a single user: user@example.com with password: P@ssw0rd! 
* The Login/Logout mechanism uses Identity Framework. The Login mechanism uses cookies for the main web site and Jason Web Tokens (JWT) for the Web API (and Angular Shopping sub-site).
* I used the Repository pattern to decouple the persistence layer (i.e. database) from the application layer.


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
1. Open : `training_dot_net\Web\AspDotNetCoreFromScratch\AspDotNetCoreFromScratch.sln` in Visual Studio 2017.<br /> 
_Note:_ After openning the solution, Visual Studio will display an error message that 'gulp' in not recognized. This is fine and will be fixed once you build the solution in the next step.
1. Build -> Build Solution. Visual Studio will install all the required NuGet packages and build the project.
1. Debug -> Start With/out Debugging
1. Your default browser should open automatically to the correct address. If it doesn't, open your project's Properties -> Debug -> Web Server Settings -> App Url and copy it to your browser.


### Known Issues:
The following are known issues that I didn't fix due to lack of time and due to the fact that this is just a training-project to follow the course and not a full application:
* Since the Shop page is its own Angular application, its Login is separated from the main site's login mangements. Therefore, if a user go  back and forth between the 'Shop' page and the main site (e.g. Home page), they will be logged out. In a real Angular application, the main site will be in Angular and not only parts of it so this will not be na issue.

