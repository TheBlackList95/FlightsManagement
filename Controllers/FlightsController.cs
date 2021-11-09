using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuiviDesVols.Layers.Data;
using SuiviDesVols.Layers.Repository.Abstractions;
using SuiviDesVols.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuiviDesVols.Controllers
{
    /// <summary>
    /// This controller if responsible for handling all things about flights (Lignes vols)
    /// Everyone can access to this controller, except booking part, user must be logged
    /// to the app to make reservation in order to trace his steps and his account
    /// </summary>
    [AllowAnonymous]
    public class FlightsController : Controller
    {
        #region GLOBAL PROPERTIES
        private readonly IGenericRepository<LigneVol> ligneVolRepository;
        private readonly IGenericRepository<Aeroport> aeroportRepository;
        private readonly IGenericRepository<VolOption> volOptionRepository;
        private readonly IGenericRepository<Vol> volRepository;
        private readonly UserManager<IdentityUser> userManager;
        private enum DataAccessState {
            UserNotLoggedIn = 0,
            DataNotFound = -1,
            EverythingIsGood = 1
        }; 
        #endregion

        #region CONSTRUCTORS
        public FlightsController(IGenericRepository<LigneVol> ligneVolRepository,
            IGenericRepository<Aeroport> aeroportRepository,
            IGenericRepository<VolOption> volOptionRepository,
            IGenericRepository<Vol> volRepository,
            UserManager<IdentityUser> userManager)
        {
            this.ligneVolRepository = ligneVolRepository;
            this.aeroportRepository = aeroportRepository;
            this.volOptionRepository = volOptionRepository;
            this.volRepository = volRepository;
            this.userManager = userManager;
        }
        #endregion

        #region ACTION METHODS
        /// <summary>
        /// This action method shows and display all flights provided by travel agences
        /// </summary>
        /// <returns>
        /// ViewResult called "Index" to displat necessary data
        /// </returns>
        public IActionResult Index()
        {
            //Get flight list from memory database to show as list in the view
            var flightsList = ligneVolRepository.GetAll().Select(s => new SingleFlightModel
            {
                Id = s.Id,
                Label = s.Nom,
                AgenceImage = s.Agence.Image,
                UnitPrice = s.PrixUnitaire,
                StartDate = s.DateDecollage,
                EndDate = s.DateAtterrissage,
                VolOptions = s.VolOptions.Select(p => p.Icone).ToList()
            }).ToList();

            //Get airports list to populate search form dropdown lists
            //to make user select airport to search
            var airportsList = aeroportRepository.GetAll().Select(r => new { r.Id, r.Nom }).OrderBy(o => o.Nom).ToList();
            var airportsListItems = new SelectList(airportsList, "Id", "Nom");

            //Fill the view model to hold data and handle it in the view
            var model = new FlightViewModel()
            {
                Flights = flightsList,
                Airports = airportsListItems,
                SearchFlight = null
            };

            //Return view model to view
            return View(model);
        }

        /// <summary>
        /// This action method, permit user to search asynchronousely for flights via search form created
        /// in Index view page
        /// </summary>
        /// <param name="model">SearchFlightModel model to hold data submitted in the form</param>
        /// <returns>
        /// PartialView to refresh just flight list part (Unobtrusive ajax)
        /// </returns>
        [HttpPost]
        public IActionResult GetAvailableFlights([Bind(Prefix = "SearchFlight")] SearchFlightModel model)
        {
            //Get flights list from memmory database
            var flightsList = ligneVolRepository.GetAll().Select(s => new SingleFlightModel
            {
                Id = s.Id,
                Label = s.Nom,
                AgenceImage = s.Agence.Image,
                UnitPrice = s.PrixUnitaire,
                StartDate = s.DateDecollage,
                EndDate = s.DateAtterrissage,
                VolOptions = s.VolOptions.Select(p => p.Icone).ToList(),
                StartAirport = s.AeroportDepart,
                EndAirport = s.AeroportArrivee
            }).ToList();

            //If model is containing data, that means user made a search in the form
            //Then we catch the data to search in memory database
            if (model != null)
            {
                //If user searched by start airport
                if(model.StartAirport != null)
                {
                    //Filter data with selected start airport
                    flightsList = flightsList.Where(p => p.StartAirport.Id == model.StartAirport).ToList();
                }

                //If user searched by end airport
                if(model.EndAirport != null)
                {
                    //Filter data with selected end airport
                    flightsList = flightsList.Where(p => p.EndAirport.Id == model.EndAirport).ToList();
                }

                //if user entered a flight travel date
                if (model.TravelDate != null)
                {
                    //Get flight with searched date
                    flightsList = flightsList.Where(p => p.StartDate.ToString("yyyy-MM-dd").Equals(model.TravelDate)).ToList();
                }
            }

            //Return PartialView to refresh flight list asynchronousely
            return PartialView("Partials/_FlightItem", flightsList);
        }

        /// <summary>
        /// This action method returns reservation flight form to make user book his flight,
        /// showing him flight data.
        /// </summary>
        /// <param name="flightId">The Id of flight stored in the database</param>
        /// <returns>
        /// If all is fine, action method returns PartialView with data, otherwise a json 
        /// object will be returned to handle errors in the view
        /// </returns>
        [Authorize]
        public IActionResult GetPartialReservationForm(Guid flightId)
        {
            //First of all, if user is not connected, then we must reject the operation
            //Otherwise, we handle reservation form to show
            if (User.Identity.IsAuthenticated)
            {
                //Get selected flight by Id
                var flight = ligneVolRepository.GetById(flightId);

                //If flight exists (User can modify the Id from inspect element, that's we i use GUID)
                if (flight != null)
                {
                    //Get list of options stored in database
                    var options = volOptionRepository.GetAll();

                    //Get default flight options provided by agence
                    var flightDefaultOptions = flight.VolOptions.ToList();

                    //Get difference between two list to get just options that are not selected
                    //to show them to user
                    //The idea is : user must not show agence default options, because there is no
                    //need to modify them, we must get just other options that are left and not provided.
                    var restOfOptionsNotChecked = options.Where(el2 => !flightDefaultOptions.Any(el1 => el1.Nom == el2.Nom)).ToList();

                    //Fill view model with data to show in the form
                    var modelObj = new HandleReservationViewModel()
                    {
                        FlightId = flightId,
                        Amenities = restOfOptionsNotChecked
                    };

                    //Return partial view to user
                    return PartialView("Partials/_Reservation", modelObj);
                }
                else
                {
                    //Then the Id is not present in database, then we throw error to the view
                    return Json(new { Success = DataAccessState.DataNotFound });
                }
            }
            else
            {
                //Then user is not logged, thus, we throw message to the user
                return Json(new { Success = DataAccessState.UserNotLoggedIn });
            }
        }

        /// <summary>
        /// This action method permit user to submit and create flight reservation
        /// </summary>
        /// <param name="model">HandleReservationViewModel model data to hold data entered
        /// In the form
        /// </param>
        /// <returns>Json object to show whether operation is succeeded or not</returns>
        [Authorize]
        [HttpPost]
        public IActionResult CreateFlightBooking(HandleReservationViewModel model)
        {
            //Get flight by Id from memory database
            var flightLine = ligneVolRepository.GetById(model.FlightId);

            //If flight is not present, then we jump this condition and throw erro message
            if (flightLine != null)
            {
                //Handle options and features that user selected in the form
                //Search options obbjects in memory database and store them into a memory list
                var flighOptionsList = new List<VolOption>();
                if (model.Amenity != null && model.Amenity.Count > 0)
                {
                    foreach (var amenity in model.Amenity)
                    {
                        var flightOptionObj = volOptionRepository.GetById(amenity);

                        if (flightOptionObj != null)
                        {
                            flighOptionsList.Add(flightOptionObj);
                        }
                    }
                }

                //Create a reserved user flight
                var flightObj = new Vol()
                {
                    Id = Guid.NewGuid(),
                    ClasseVol = model.FlightType,
                    DateVoyage = DateTime.Now,
                    IdLigne = flightLine.Id,
                    LigneVol = flightLine,
                    IdUtilisateur = userManager.GetUserId(User),
                    OptionsChoisies = flighOptionsList,
                    NombreAdultes = model.Teenagers,
                    NombreEnfants = model.Kids,
                    QuantiteBagageEnKg = model.BaggageQuantity
                };

                //Insert reserved flight in memory database
                volRepository.Insert(flightObj);

                //return json object as succeeded operation
                return Json(new { Success = DataAccessState.EverythingIsGood });
            }
            else
            {
                //Return json object as failure reservation operation
                return Json(new { Success = DataAccessState.DataNotFound });
            }
        }     
        #endregion
    }
}
