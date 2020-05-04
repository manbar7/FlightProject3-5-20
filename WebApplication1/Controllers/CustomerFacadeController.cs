using ClassLibrary1;
using ClassLibrary1.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CustomerFacadeController : ApiController
    {
        LoginToken<Customer> CustomerLoginToken;
        private Authentications authentication;
        private LoggedInCustomerFacade CustomerFacade;
        public CustomerFacadeController()
        {
            authentication = new Authentications();

        }

        public Authentications GetLoginToken()
        {
            Request.Properties.TryGetValue("CustomerLogin", out object token);
            Request.Properties.TryGetValue("CustomerLogin", out object facade);
            LoginToken<Customer> customerToken = (LoginToken<Customer>)token;
            LoggedInCustomerFacade customerFacade = (LoggedInCustomerFacade)facade;
            authentication.CustomerToken = customerToken;
            authentication.CustomerFacade = customerFacade;
            return authentication;
        }

        [ResponseType(typeof(List<Customer>))]
        [Route("api/customerfacade/GetAllTickets")]
        [HttpGet]
        public IHttpActionResult GetAllTickets()
        {
            GetLoginToken();

            List<Ticket> AllTickets = authentication.AirlineFacade.GetAllTickets(AirlineLoginToken).ToList();
            if (AllTickets.Count == 0)
                return Content(HttpStatusCode.NotAcceptable, "No Tickets Found!");

            else
                return Ok(AllTickets);
        }
    }
}
