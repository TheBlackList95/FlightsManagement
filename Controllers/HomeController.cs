using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SuiviDesVols.Models;

namespace SuiviDesVols.Controllers
{
    /// <summary>
    /// This controller is responsible for handling user authentication and registration
    /// </summary>
    public class HomeController : Controller
    {
        #region GLOBAL PROPERTIES
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        #endregion

        #region CONSTRUCTORS
        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region ACTION METHODS
        /// <summary>
        /// This action method return a view in order to make user login to the app
        /// </summary>
        /// <returns>ViewResult</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        /// <summary>
        /// This action method permits user to submit his login credantials to the app
        /// </summary>
        /// <param name="appUser">appUser model to store Email, Password</param>
        /// <param name="ReturnUrl">ReturnUrl is a link to redirect if user not logged in</param>
        /// <returns>ViewResult</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel appUser, string ReturnUrl)
        {
            //If no errors occured, handle login operation
            if (ModelState.IsValid)
            {
                //Check if user exists in memory database
                var user = await _userManager.FindByNameAsync(appUser.Email);

                //If user exists and his password is correct
                if (user != null)
                {
                    //Sign in user through identity framework 
                    var signInResult = await _signInManager.PasswordSignInAsync(user, appUser.Password, appUser.Remember, false);
                    
                    //If operation succeeded
                    if (signInResult.Succeeded)
                    {
                        //If user not redirected from another page to sign in
                        if(string.IsNullOrEmpty(ReturnUrl))
                        {
                            //rediredt user to flight list page
                            return RedirectToAction("Index", "Flights");
                        }
                        else
                        {
                            //redirect user to previous page just before they sign in
                            return LocalRedirect(ReturnUrl);
                        }
                    }
                }
                else
                {
                    //Add error to modal
                    ModelState.AddModelError("", "Email ou mot passe incorrecte.");
                }
            }
            
            //return view to user
            return View(appUser);
        }

        /// <summary>
        /// This action method permits user to make registration in the app
        /// </summary>
        /// <returns>ViewResult</returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// This action method permits user to submit his data to server to register to the app
        /// </summary>
        /// <param name="appUser">appUser model to store registration data</param>
        /// <returns>ViewResult</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel appUser)
        {
            //If no errors occured, than handle registration
            if (ModelState.IsValid)
            {
                //Fill IdentityUser model
                var user = new IdentityUser
                {
                    Email = appUser.Email,
                    UserName = appUser.Email
                };

                //Register user with password entered in the form
                var result = await _userManager.CreateAsync(user, appUser.Password);

                //If operation succeeded
                if (result.Succeeded)
                {
                    //Sign in user to the application without passing via Login page  
                    var signInResult = await _signInManager.PasswordSignInAsync(user, appUser.Password, false, false);

                    //If user signed in successfully
                    if (signInResult.Succeeded)
                    {
                        //Redirect user to flight list page
                        return RedirectToAction("Index", "Flights");
                    }
                }

                //Get errors if they exist
                foreach (var error in result.Errors)
                {
                    //Add error to modal
                    ModelState.AddModelError("", error.Description);
                }
            }

            //Return view to user
            return View(appUser);
        }

        /// <summary>
        /// Thsi action method permits user to log off and disconnect from the app
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Flights");
        }
        #endregion
    }
}