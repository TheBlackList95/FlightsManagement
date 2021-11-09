using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuiviDesVols.Layers.Data;
using SuiviDesVols.Layers.DatabaseContexts;
using SuiviDesVols.Layers.Repository.Abstractions;
using SuiviDesVols.Models;

namespace SuiviDesVols.Controllers
{
    /// <summary>
    /// This controller is responsible from handling reserved flights by user
    /// </summary>
    [Authorize]
    public class BookedFlightsController : Controller
    {
        #region GLOBAL PROPERTIES
        private readonly UserManager<IdentityUser> userManager;
        private readonly IGenericRepository<Vol> volRepository;
        private readonly IGenericRepository<LigneVol> ligneVolRepository;
        private readonly IGenericRepository<VolOption> volOptionRepository;
        private enum DataAccessState
        {
            UserNotLoggedIn = 0,
            DataNotFound = -1,
            EverythingIsGood = 1
        };
        #endregion

        #region CONSTRUCTORS
        public BookedFlightsController(UserManager<IdentityUser> userManager,
            IGenericRepository<Vol> volRepository,
            IGenericRepository<LigneVol> ligneVolRepository,
            IGenericRepository<VolOption> volOptionRepository)
        {
            this.userManager = userManager;
            this.volRepository = volRepository;
            this.ligneVolRepository = ligneVolRepository;
            this.volOptionRepository = volOptionRepository;
        }     
        #endregion

        #region ACTION METHODS
        /// <summary>
        /// This action method permits user to visualize his reserved flights
        /// </summary>
        /// <returns>ViewResult</returns>
        public IActionResult Index()
        {
            //Get connected user Id via identity framework
            var connectedUserId = userManager.GetUserId(User);

            //Get user reserved flights
            var userBookedFlights = (from a in volRepository.GetAll()
                                    join b in ligneVolRepository.GetAll()
                                    on a.IdLigne equals b.Id
                                    where a.IdUtilisateur.Equals(connectedUserId)
                                    select a).ToList();

            //Handle each flight separately
            var listDataModel = new List<SingleFlightModel>();
            foreach (var item in userBookedFlights)
            {
                var flightLine = ligneVolRepository.GetById(item.IdLigne);
                
                //Get unit price of flight
                double totalPriceToPay = flightLine.PrixUnitaire;

                //Add options total price to unit price
                totalPriceToPay += (item.OptionsChoisies.Sum(p => p.Prix));

                //If user selected "Business" as flight type 
                if (item.ClasseVol.Equals("Business"))
                {
                    //Then we must add 1500dh to unit price
                    totalPriceToPay += +1500;
                }

                //If number of adults is greather than 1
                if (item.NombreAdultes > 1)
                {
                    //Then we should multiply flight unit price by number of adults
                    //Then add the result to unit price
                    totalPriceToPay += (flightLine.PrixUnitaire * item.NombreAdultes);
                }

                //If user enter some childs
                if (item.NombreEnfants > 0)
                {
                    //We multiply the half of unit price by the number of childs
                    //Then add the result to unit price
                    totalPriceToPay += ((flightLine.PrixUnitaire / 2) * item.NombreEnfants);
                }

                //If baggage quantity is greather than what is permited (20Kg)
                if (item.QuantiteBagageEnKg > 20)
                {
                    //Then We get difference of quantity
                    //Then multiply the difference by 50dh
                    ///Then add the result to unit price
                    totalPriceToPay += ((item.QuantiteBagageEnKg - 20) * 50);
                }

                //Insert the data in viewModel
                listDataModel.Add(new SingleFlightModel
                {
                    Id = flightLine.Id,
                    ReservedFlightId = item.Id,
                    AgenceImage = flightLine.Agence.Image,
                    EndAirport = flightLine.AeroportArrivee,
                    UnitPrice = totalPriceToPay,
                    StartDate = flightLine.DateDecollage,
                    EndDate = flightLine.DateAtterrissage,
                });
            }

            //return view with model calculated & prepared
            return View(listDataModel);
        }

        /// <summary>
        /// Thi action method permits user to edit his reserved flight
        /// </summary>
        /// <param name="reservedFlightId">The id of reserved flight</param>
        /// <returns>
        /// PartialView if everything is fine, otherwiser Json object will be 
        /// returned as problem somewhere diuring handling operation
        /// </returns>
        public IActionResult EditReservation(Guid reservedFlightId)
        {
            //If user is autehnticated, handle edit reservation
            if (User.Identity.IsAuthenticated)
            {
                //Get selected booked flight
                var flight = volRepository.GetById(reservedFlightId);

                //if flight exists in memory database 
                if (flight != null)
                {
                    //Get list of option stored in memory database
                    var FlightOtions = volOptionRepository.GetAll();

                    //Get default flight options provided by travel agence
                    var flightLineOptions = flight.LigneVol.VolOptions.ToList();

                    //Add options provided by agence in memory list to show them to user
                    //But he can't modify them just to visualize them
                    List<EditAmenitiesModel> listAmenities = new List<EditAmenitiesModel>();
                    foreach (var flightLineOption in flightLineOptions)
                    {
                        //Add option to the memory list
                        listAmenities.Add(new EditAmenitiesModel 
                        {
                            VolOption = flightLineOption, //Option object
                            IsChecked = false, //False: to make option unchecked in the view
                            IsIncluded = true //True : Already provided, can't be altered (Disabled)
                        });
                    }

                    //Get the rest of options left, user can here check or uncked whaterver option he wants
                    var restOfOptionsNotChecked = FlightOtions.Where(el2 => !flightLineOptions.Any(el1 => el1.Nom == el2.Nom)).ToList();

                    //Loop through the rest of options
                    foreach (var option in restOfOptionsNotChecked)
                    {
                        //Search option in the list of options choosen by user
                        var choosenOption = flight.OptionsChoisies.SingleOrDefault(p => p.Id == option.Id);
                        
                        //If option exists, then it's choosen by user
                        var isOptionChecked = false;
                        if(choosenOption != null)
                        {
                            //Make option checked true, means it will be shown as checked in the view
                            isOptionChecked = true;
                        }

                        //Add option into the memory list
                        listAmenities.Add(new EditAmenitiesModel 
                        {
                            VolOption = option,
                            IsChecked = isOptionChecked,
                            IsIncluded = false 
                        });
                    }

                    //Prepare object to handle in the view
                    var modelObj = new HandleReservationViewModel()
                    {
                        FlightId = reservedFlightId,
                        FlightType = flight.ClasseVol,
                        Teenagers = flight.NombreAdultes,
                        Kids = flight.NombreEnfants,
                        BaggageQuantity = flight.QuantiteBagageEnKg,
                        EditAmenities = listAmenities
                    };

                    //return parial view to user as modal form
                    return PartialView("Partials/_Reservation", modelObj);
                }
                else
                {
                    //Return json object indicating that selected flight not found in memory database
                    return Json(new { Success = DataAccessState.DataNotFound });
                }
            }
            else
            {
                //Return json object indicating that user is not logged in to the app
                return Json(new { Success = DataAccessState.UserNotLoggedIn });
            }
        }

        /// <summary>
        /// This action method permits user to submit his updated flight data to server
        /// </summary>
        /// <param name="model">Model to store updated flight data</param>
        /// <returns>Json object</returns>
        [HttpPost]
        public IActionResult UpdateReservation(HandleReservationViewModel model)
        {
            //Get rserved flight by Id
            var flight = volRepository.GetById(model.FlightId);

            //if user exists in database
            if (flight != null)
            {
                //Get checked flight options list
                var flighOptionsList = new List<VolOption>();
                if (model.Amenity != null && model.Amenity.Count > 0)
                {
                    foreach (var amenity in model.Amenity)
                    {
                        //Get option object from memory database
                        var flightOptionObj = volOptionRepository.GetById(amenity);

                        //if option exists in memory database
                        if (flightOptionObj != null)
                        {
                            //Add option the memory list
                            flighOptionsList.Add(flightOptionObj);
                        }
                    }
                }
                
                //Get the rest of data submitted in the form
                flight.OptionsChoisies = flighOptionsList;
                flight.ClasseVol = model.FlightType;
                flight.NombreAdultes = model.Teenagers;
                flight.NombreEnfants = model.Kids;
                flight.QuantiteBagageEnKg = model.BaggageQuantity;

                //Update reserved flight
                volRepository.Update(flight);

                //Return json object indicating that update operation is succeeded
                return Json(new { Success = DataAccessState.EverythingIsGood });
            }
            else
            {
                //Return json object indicating that flight is not exists in database
                return Json(new { Success = DataAccessState.DataNotFound });
            }
        }

        /// <summary>
        /// This action method permits user to visualize the details of his reserved flight
        /// </summary>
        /// <param name="flightId">The Id of reserved flight selected</param>
        /// <param name="totalFlightTime">The total flight time</param>
        /// <param name="totalPriceToPay">The total price to pay</param>
        /// <returns></returns>
        public IActionResult Details(Guid flightId, TimeSpan totalFlightTime, double totalPriceToPay)
        {
            //Get selected flight from database by Id
            var flight = ligneVolRepository.GetById(flightId);

            //if flight exists in database
            if(flight != null)
            {
                //Get flight properties data
                var startAirportObj = flight.AeroportDepart;
                var endAirportObj = flight.AeroportArrivee;
                var airplaneObj = flight.Avion;
                var agency = flight.Agence;

                //Calculate the number of kilometers bewteen start airport & end one
                var startLocation = new GeoCoordinate(startAirportObj.Latitude, startAirportObj.Longitude);
                var endLocation = new GeoCoordinate(endAirportObj.Latitude, endAirportObj.Longitude);
                var distanceBetweenAirports = (startLocation.GetDistanceTo(endLocation)) / 1000;

                //Calculate the kerosen quantity needed for this flight
                var airplaneKerosenQuantity = ((airplaneObj.ConsommationLitrePar100Km * distanceBetweenAirports / 100) 
                                              + airplaneObj.EffortDecollage);

                //Get list of flight options
                List<AmenityModel> listAmenities = new List<AmenityModel>();
                foreach (var item in volOptionRepository.GetAll())
                {
                    //Get options object from database
                    var volOptionobj = flight.VolOptions.SingleOrDefault(p => p.Id == item.Id);

                    //if flight option exists, then we must check it in the view, otherwise
                    //We must unchcked it in the view
                    var defaultClassStyle = "non-active-amenity";
                    if (volOptionobj != null)
                    {
                        defaultClassStyle = "active-amenity";
                    }

                    //Add option object to the memory list
                    listAmenities.Add(new AmenityModel()
                    {
                        VolOption = item,
                        IsChecked = defaultClassStyle
                    });
                }

                //prepare view model with needed data to hanle in details view
                var modelObj = new FlightDetailsViewModel()
                {
                    FlightType = flight.Vols.FirstOrDefault().ClasseVol,
                    BasicPrice = flight.PrixUnitaire,
                    TotalPrice = totalPriceToPay,
                    NbChildren = flight.Vols.FirstOrDefault().NombreEnfants,
                    NbAdults = flight.Vols.FirstOrDefault().NombreAdultes,
                    QuantityBaggageInKg = flight.Vols.FirstOrDefault().QuantiteBagageEnKg,
                    FligthName = flight.Nom,
                    StartAirportName = startAirportObj.Nom,
                    EndAirportName = endAirportObj.Nom,
                    CompleteFlightTime = totalFlightTime,
                    FlightTakeOffDate = flight.DateDecollage,
                    FlightLandingDate = flight.DateAtterrissage,
                    DistanceBetweenAirports = Math.Round(distanceBetweenAirports, 2),
                    Amenities = listAmenities,
                    AgencyName = agency.Nom,
                    AirplaneName = airplaneObj.Nom,
                    AirplaneConsumption = airplaneObj.ConsommationLitrePar100Km,
                    AirplaneNbPassengers = airplaneObj.NbPassagerMax,
                    AirplaneTakeOffPower = airplaneObj.EffortDecollage,
                    AirplaneKerosenQuantity = Math.Round(airplaneKerosenQuantity, 2),
                    AgencyDescription = agency.Description,
                    AgencyImage = agency.Image
                };

                //return details view with necessary view model data
                return View(modelObj);
            }
            else
            {
                //Redirect user to erro page
                return RedirectToAction("Error", "Index");
            }
        }     
        #endregion
    }
}
