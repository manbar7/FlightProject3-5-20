﻿using ClassLibrary1;
using ClassLibrary1.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class AnonymousFacadeController : ApiController
    {

        private AnonymousUserFacade AnonymousFacade;

        public AnonymousFacadeController()
        {
            AnonymousFacade = new AnonymousUserFacade();
        }
        // GET api/anonymousfacade
        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/getallflights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            List<Flight> AllFlights = AnonymousFacade.GetAllFlights().ToList();
            if (AllFlights.Count == 0)
                return NotFound();
            
            else
                return Ok(AllFlights);
        }

        [ResponseType(typeof(List<AirlineCompany>))]
        [Route("api/anonymousfacade/getallairlinecompanies")]
        [HttpGet]
        public IHttpActionResult GetAllAirlineCompanies()
        {
            List<AirlineCompany>AllAirlineCompanies = AnonymousFacade.GetAllAirlineCompanies().ToList();         
                if (AllAirlineCompanies.Count == 0)
                    return NotFound();

                else
                    return Ok(AllAirlineCompanies);

        }

        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/getallflightsvacancy")]
        [HttpGet]
        public IHttpActionResult GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> AllFlightsVacancy = AnonymousFacade.GetAllFlightsVacancy();
            if (AllFlightsVacancy.Count == 0)
                return NotFound();

            else
           
                return Ok(AllFlightsVacancy.ToList());
            
        }

        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/flights/{id}")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int id)
        {
            Flight flight = AnonymousFacade.GetFlightById(id);
            if (flight == null)
                return NotFound();
            else
                return Ok(flight);

        }

          [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/flights/{origincountry}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByOriginCountry(int countryCode)
        {
            List<Flight> flightsByOriginCountry = AnonymousFacade.GetFlightsByOriginCountry(countryCode).ToList();
            if (flightsByOriginCountry.Count == 0)
                return NotFound();
            else
                return Ok(flightsByOriginCountry);

        }

        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/flights/{destinationcountry}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDestinationCountry(int countryCode)
        {
            List<Flight> flightsByDestinationCountry = AnonymousFacade.GetFlightsByDestinationCountry(countryCode).ToList();
            if (flightsByDestinationCountry.Count == 0)
                return NotFound();
            else
                return Ok(flightsByDestinationCountry);

        }

        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/flights/{departuredate}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDepatrureDate(DateTime departureDate)
        {
            List<Flight> flightsByDepartureDate = AnonymousFacade.GetFlightsByDepatrureDate(departureDate).ToList();
            if (flightsByDepartureDate.Count == 0)
                return NotFound();
            else
                return Ok(flightsByDepartureDate);

        }

        [ResponseType(typeof(List<Flight>))]
        [Route("api/anonymousfacade/flights/{landingdate}")]
        [HttpGet]
        public IHttpActionResult GetFlightsByLandingDate(DateTime landingDate)
        {
            List<Flight> flightsByLandingDate = AnonymousFacade.GetFlightsByLandingDate(landingDate).ToList();
            if (flightsByLandingDate.Count == 0)
                return NotFound();
            else
                return Ok(flightsByLandingDate);

        }

      
    }
}
