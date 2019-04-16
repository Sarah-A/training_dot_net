using AspDotNetCoreFromScratch.Data;
using AspDotNetCoreFromScratch.Data.Entities;
using AspDotNetCoreFromScratch.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCoreFromScratch.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<StoreUser> _signInManager;
        private readonly UserManager<StoreUser> _userManager;
        private readonly IConfiguration _config;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<StoreUser> signInManager,
                                UserManager<StoreUser> userManager,
                                IConfiguration config,
                                ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "App");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,
                    loginViewModel.Password,
                    loginViewModel.RememberMe,
                    false);

                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }
                    else
                    {
                        return RedirectToAction("Shop", "App");
                    }
                }
            }

            // This will add this error to the model, to be displayed in the <asp-validation-summary="ModelOnly">
            // in the login view.
            ModelState.AddModelError("", "Wrong user name or password!");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "App");
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

                if( user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);

                    if (result.Succeeded)
                    {
                        // claims are well known values that are stored by the app in the token and can be used by the client
                        // or passed back to the server in future requests in order to verify the user or send additional 
                        // user-related infomation.
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),         // the name of the subject (user)

                            // Jti: a unique string that represent this token. Used to prevent re-play attack:
                            // Guid.NewGuid() returns a 128-bit integer (16 bytes) that can be used across all computers and networks 
                            // wherever a unique identifier is required. Such an identifier has a very low probability of being duplicated.
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                            // UniqueName
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        // create the key to encrypt/decrypt the tokens:
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

                        // the signing credentials for the token:
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        // create the actual token:
                        var token = new JwtSecurityToken(
                            _config["Tokens:Issuer"],           // who created the token
                            _config["Tokens:Audience"],         // who uses the token,
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: credentials
                            );

                        // serialize the token and add the expiration time:
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created("", results);

                    }
                }

            }

            return BadRequest();
        }
    }
}
