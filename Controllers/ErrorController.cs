using GeoCoordinatePortable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuiviDesVols.Layers.Data;
using SuiviDesVols.Layers.DatabaseContexts;
using SuiviDesVols.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuiviDesVols.Controllers
{
    /// <summary>
    /// This controller is responsible for handling exceptions & errors occured
    /// during surfing in the application 
    /// </summary>
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        /// <summary>
        /// This action method permit user to visualize a standard page of error
        /// </summary>
        /// <returns>ViewResult</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
