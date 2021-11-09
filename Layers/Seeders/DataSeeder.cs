using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SuiviDesVols.Layers.Data;
using SuiviDesVols.Layers.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SuiviDesVols.Layers.Seeders
{
    /// <summary>
    /// This class is reponsible for filling and inserting needed dummy data for out web application.
    /// We use here EntityFramework InMemory database, it's more professional.
    /// It acts like a real database but in memory, it's a new entityFremwork evolution in .net core.
    /// </summary>
    public class DataSeeder
    {
        /// <summary>
        /// This method is a static method to generate data into memory database to use them in our web application
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                try
                {
                    #region INSERT AGENCES
                    //Memory objects for agences
                    var ajiTravelObj = new Agence()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Aji travel",
                        Image = "aji_travel.png",
                        Description = "Vacancia est une agence de voyage enligne basée au Maroc. elle combine le service de "
                                    + "qualité d'une agence de rue et les prix cassés d' un site enligne, L’ agence choisit "
                                    + "pour vous les meilleurs deals possibles et casse les prix sur beaucoup de destinations "
                                    + "dont Istanbul /Turquie, Paris/France et Malaisie....., ainsi que sur une palette d’hôtels "
                                    + "au Maroc, nous contractons des deals intéressants avec la majorités des hôtels et des compagnies aériennes "
                    };

                    var idealTravelObj = new Agence()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Idéal Travel Morocco",
                        Image = "ideal_travel_morocco.png",
                        Description = "Ideal Travel Morocco est une agence de voyage marocaine basée à Marrakech. "
                                    + "Entre découverte du pays sous toutes ses facettes (paysages, culture, mode de vie, activités…), "
                                    + "confort et authenticité, nous mettons tout en œuvre pour parfaire votre voyage au cœur du Maroc, "
                                    + "notre terre d’accueil. Sécurité, accompagnement de qualité et confort sont nos préoccupations principales."
                    };

                    var ryadToursObj = new Agence()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Ryad Tours",
                        Image = "ryad_tours.png",
                        Description = "Ryad Tours est une agence de voyage basée à Rabat est Casablanca , L’agence est spécialite "
                                    + "dans Haj et Omra choisit pour vous les meilleurs deals possibles et casse les prix sur beaucoup "
                                    + "de destinations dont Istanbul /Turquie, Paris/France et Malaisie….., ainsi que sur une palette "
                                    + "d’hôtels au Maroc, nous contractons des deals intéressants avec la majorités des hôtels et des "
                                    + "compagnies aériennes."
                    };

                    var treeCameliTourObj = new Agence()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Tree Cameli Tour",
                        Image = "tree_cameli_tour.png",
                        Description = "Nos agences de Marrakech et Agadir vous offrent une vaste gamme de services, avec un souci "
                                    + "particulier pour l’efficacité et la qualité. Notre équipe de professionnels vous accueille en "
                                    + "Français, Anglais, Allemand, Espagnole et Italien. Nous organisons des séjours touristiques et "
                                    + "professionnels(différents événements et rencontres) pour individuels et groupes.Tree Cameli Tours "
                                    + "se charge de la réservation d’hôtels de toutes catégories.Nous réservons aussi des transferts privés, "
                                    + "circuits, restaurants, musées…… Nous fournissons des guides professionnels en différentes langues. "
                                    + "De nombreux tour - opérateurs et agences nous font déjà confiance, pour les individuels et les groupes, "
                                    + "qu’il s’agisse de tourisme culturel, découverte, aventure, Trekking ou d’affaires."
                    };

                    context.Agences.Add(ajiTravelObj);
                    context.Agences.Add(idealTravelObj);
                    context.Agences.Add(ryadToursObj);
                    context.Agences.Add(treeCameliTourObj);
                    #endregion

                    #region INSERT CITIES
                    //Memory objects for cities
                    var casablancaCityObj = new Ville() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Casablanca" 
                    };

                    var rabatCityObj = new Ville() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Rabat" 
                    };

                    var marrakechCityObj = new Ville() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Marrakech" 
                    };

                    var parisCityObj = new Ville() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Paris" 
                    };

                    var niceCityObj = new Ville() { 
                        Id = Guid.NewGuid(),
                        Nom = "Nice" 
                    };

                    var toulouseCityObj = new Ville() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Toulouse" 
                    };

                    var lyonCityObj = new Ville() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Lyon" 
                    };

                    context.Villes.Add(casablancaCityObj);
                    context.Villes.Add(rabatCityObj);
                    context.Villes.Add(marrakechCityObj);
                    context.Villes.Add(parisCityObj);
                    context.Villes.Add(niceCityObj);
                    context.Villes.Add(toulouseCityObj);
                    context.Villes.Add(lyonCityObj);
                    #endregion

                    #region INSERT FLIGHT OPTIONS
                    //Memory objects for flight options
                    var option1 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Wifi",
                        Icone = "soap-icon-wifi",
                        Prix = 150
                    };

                    var option2 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Télévision",
                        Icone = "soap-icon-television",
                        Prix = 90
                    };

                    var option3 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Jeux",
                        Icone = "soap-icon-joystick",
                        Prix = 220
                    };

                    var option4 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Café",
                        Icone = "soap-icon-coffee",
                        Prix = 50
                    };

                    var option5 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Nourriture",
                        Icone = "soap-icon-food",
                        Prix = 370
                    };

                    var option6 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Boisson",
                        Icone = "soap-icon-juice",
                        Prix = 45
                    };

                    var option7 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Confort",
                        Icone = "soap-icon-comfort",
                        Prix = 500
                    };

                    var option8 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Magazines",
                        Icone = "soap-icon-magazine",
                        Prix = 120
                    };

                    var option9 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Divertissement",
                        Icone = "soap-icon-entertainment",
                        Prix = 420
                    };

                    var option10= new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Climatisation",
                        Icone = "soap-icon-aircon",
                        Prix = 100
                    };

                    var option11 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Vins",
                        Icone = "soap-icon-winebar",
                        Prix = 700
                    };

                    var option12 = new VolOption()
                    {
                        Id = Guid.NewGuid(),
                        Nom = "Achats",
                        Icone = "soap-icon-shopping",
                        Prix = 300
                    };

                    context.VolOptions.Add(option1);
                    context.VolOptions.Add(option2);
                    context.VolOptions.Add(option3);
                    context.VolOptions.Add(option4);
                    context.VolOptions.Add(option5);
                    context.VolOptions.Add(option6);
                    context.VolOptions.Add(option7);
                    context.VolOptions.Add(option8);
                    context.VolOptions.Add(option9);
                    context.VolOptions.Add(option10);
                    context.VolOptions.Add(option11);
                    context.VolOptions.Add(option12);
                    #endregion

                    #region INSERT AIRPORTS
                    //Memory objects for airports
                    var casablancaAirportObj = new Aeroport() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport Mohammed V - Casablanca", 
                        Latitude = 33.36993, 
                        Longitude = -7.58589, 
                        Ville = casablancaCityObj,
                    };

                    var MarrakecAirporthObj = new Aeroport() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport de Marrakech - Menara", 
                        Latitude = 31.60181, 
                        Longitude = -8.02444, 
                        Ville = marrakechCityObj 
                    };

                    var RabatAirportObj = new Aeroport() {
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport international Rabat - Salé", 
                        Latitude = 34.05045, 
                        Longitude = -6.74950, 
                        Ville = rabatCityObj 
                    };

                    var parisAirportObj = new Aeroport() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport de Paris – Charles de Gaulle", 
                        Latitude = 49.00986, 
                        Longitude = 2.54799, 
                        Ville = parisCityObj 
                    };

                    var niceAirportObj = new Aeroport() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport de Nice – Côte d’Azur", 
                        Latitude = 43.65987, 
                        Longitude = 7.21483, 
                        Ville = niceCityObj 
                    };

                    var lyonAirportObj = new Aeroport() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport de Lyon – Saint Exupéry", 
                        Latitude = 45.72345, 
                        Longitude = 5.08872, 
                        Ville = lyonCityObj 
                    };

                    var toulouseAirportObj = new Aeroport() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Aéroport de Toulouse – Blagnac", 
                        Latitude = 43.62949, 
                        Longitude = 1.36771, 
                        Ville = toulouseCityObj 
                    };

                    context.Aeroports.Add(casablancaAirportObj);
                    context.Aeroports.Add(MarrakecAirporthObj);
                    context.Aeroports.Add(RabatAirportObj);
                    context.Aeroports.Add(parisAirportObj);
                    context.Aeroports.Add(niceAirportObj);
                    context.Aeroports.Add(lyonAirportObj);
                    context.Aeroports.Add(toulouseAirportObj);
                    #endregion

                    #region INSERT AIRPLANES
                    //Memory objects for airplanes
                    var marocAirplaneObj = new Avion() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Boeing 737", 
                        ConsommationLitrePar100Km = 2.8, 
                        NbPassagerMax = 750, 
                        EffortDecollage = 5.3 
                    };

                    var franceAirplaneObj = new Avion() { 
                        Id = Guid.NewGuid(), 
                        Nom = "Airbus 535", 
                        ConsommationLitrePar100Km = 3, 
                        NbPassagerMax = 600, 
                        EffortDecollage = 4.2 
                    };

                    context.Avions.Add(marocAirplaneObj);
                    context.Avions.Add(franceAirplaneObj);
                    #endregion

                    #region INSERT FLIGHTS
                    //Memory list for flights
                    var volList = new List<LigneVol>()
                    {
                        new LigneVol() { 
                            Id = Guid.NewGuid(), 
                            AeroportDepart = casablancaAirportObj, 
                            AeroportArrivee = parisAirportObj, 
                            Nom = "Casablanca à Paris", 
                            Avion = marocAirplaneObj, 
                            PrixUnitaire = 1500,
                            DateDecollage = DateTime.ParseExact("01-12-2021 17:15", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("01-12-2021 19:30", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option3, option4, option5, option6, option7, option8},
                            Agence = ajiTravelObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = MarrakecAirporthObj,
                            AeroportArrivee = niceAirportObj,
                            Nom = "Marrakech à Nice",
                            Avion = marocAirplaneObj,
                            PrixUnitaire = 650,
                            DateDecollage = DateTime.ParseExact("05-12-2021 10:30", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("05-12-2021 13:25", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option4, option6, option8},
                            Agence = idealTravelObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = RabatAirportObj,
                            AeroportArrivee = parisAirportObj,
                            Nom = "Rabat à Paris",
                            Avion = marocAirplaneObj,
                            PrixUnitaire = 980,
                            DateDecollage = DateTime.ParseExact("03-12-2021 06:00", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("03-12-2021 08:20", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option1, option2, option3},
                            Agence = ryadToursObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = MarrakecAirporthObj,
                            AeroportArrivee = toulouseAirportObj,
                            Nom = "Marrakech à Toulouse",
                            Avion = marocAirplaneObj,
                            PrixUnitaire = 750,
                            DateDecollage = DateTime.ParseExact("03-12-2021 13:15", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("03-12-2021 15:45", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){ option2, option3, option4, option5, option6},
                            Agence = treeCameliTourObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = RabatAirportObj,
                            AeroportArrivee = lyonAirportObj,
                            Nom = "Rabat à Lyon",
                            Avion = marocAirplaneObj,
                            PrixUnitaire = 2600,
                            DateDecollage = DateTime.ParseExact("06-12-2021 10:45", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("06-12-2021 12:00", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option1, option2, option3, option4, option5, option6, option7, option8},
                            Agence = idealTravelObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = niceAirportObj,
                            AeroportArrivee = casablancaAirportObj,
                            Nom = "Nice à Casablanca",
                            Avion = franceAirplaneObj,
                            PrixUnitaire = 1250,
                             DateDecollage = DateTime.ParseExact("06-12-2021 16:25", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("06-12-2021 18:00", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option1, option2, option3, option4, option5},
                            Agence = ajiTravelObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = toulouseAirportObj,
                            AeroportArrivee = MarrakecAirporthObj,
                            Nom = "Toulouse à Marrakech",
                            Avion = franceAirplaneObj,
                            PrixUnitaire = 1300,
                             DateDecollage = DateTime.ParseExact("06-12-2021 21:05", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("06-12-2021 23:25", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option1, option2, option3, option4, option5, option6, option7, option8},
                            Agence = treeCameliTourObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = lyonAirportObj,
                            AeroportArrivee = casablancaAirportObj,
                            Nom = "Lyon à Casablanca",
                            Avion = franceAirplaneObj,
                            PrixUnitaire = 570,
                            DateDecollage = DateTime.ParseExact("08-12-2021 09:00", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("08-12-2021 11:30", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option3, option4, option6},
                            Agence = treeCameliTourObj
                        },

                        new LigneVol() {
                            Id = Guid.NewGuid(),
                            AeroportDepart = MarrakecAirporthObj,
                            AeroportArrivee = lyonAirportObj,
                            Nom = "Marrakech à Lyon",
                            Avion = marocAirplaneObj,
                            PrixUnitaire = 3000,
                            DateDecollage = DateTime.ParseExact("10-12-2021 12:15", "dd-MM-yyyy HH:mm", null),
                            DateAtterrissage = DateTime.ParseExact("10-12-2021 14:30", "dd-MM-yyyy HH:mm", null),
                            VolOptions = new List<VolOption>(){option1, option2, option3, option4, option5, option6},
                            Agence = ryadToursObj
                        }
                    };

                    context.LigneVols.AddRange(volList);
                    #endregion

                    #region SAVE OBJECTS TO MEMORY ENTITYFRAMEWORK DATABASE
                    context.SaveChanges();
                    #endregion
                }
                catch (Exception ex)
                {
                   throw new Exception(ex.Message);
                }
            }
        }
    }
}
