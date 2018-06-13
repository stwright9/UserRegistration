using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserRegistration.Views;

namespace UserRegistration.Controllers
{
    public class RegistrationFormController : Controller
    {
        [HttpGet]
        public ActionResult RegistrationForm()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.States = GetListOfStates();
            return View(userInfo);
        }

        [HttpPost]
        public ActionResult RegistrationForm(UserInfo userInfo)
        {
            userInfo.Country = "United States";
            using (UserRegdbEntities dataModel = new UserRegdbEntities())
            {
                dataModel.UserInfoes.Add(userInfo);
                dataModel.SaveChanges();
            }

            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }

        private IEnumerable<SelectListItem> GetListOfStates()
        {
            Dictionary<string, string> states = GetStates();
            List<SelectListItem> statesList = new List<SelectListItem>();

            foreach (var i in states)
            {
                statesList.Add(new SelectListItem
                {
                    Value = i.Value,
                    Text = i.Key
                });
            }
            return statesList;
        }

        private Dictionary<string, string> GetStates()
        {
            Dictionary<string, string> states = new Dictionary<string, string>();

            states.Add("AL", "Alabama");
            states.Add("AK", "Alaska");
            states.Add("AZ", "Arizona");
            states.Add("AR", "Arkansas");
            states.Add("CA", "California");
            states.Add("CO", "Colorado");
            states.Add("CT", "Connecticut");
            states.Add("DE", "Delaware");
            states.Add("DC", "District of Columbia");
            states.Add("FL", "Florida");
            states.Add("GA", "Georgia");
            states.Add("HI", "Hawaii");
            states.Add("ID", "Idaho");
            states.Add("IL", "Illinois");
            states.Add("IN", "Indiana");
            states.Add("IA", "Iowa");
            states.Add("KS", "Kansas");
            states.Add("KY", "Kentucky");
            states.Add("LA", "Louisiana");
            states.Add("ME", "Maine");
            states.Add("MD", "Maryland");
            states.Add("MA", "Massachusetts");
            states.Add("MI", "Michigan");
            states.Add("MN", "Minnesota");
            states.Add("MS", "Mississippi");
            states.Add("MO", "Missouri");
            states.Add("MT", "Montana");
            states.Add("NE", "Nebraska");
            states.Add("NV", "Nevada");
            states.Add("NH", "New Hampshire");
            states.Add("NJ", "New Jersey");
            states.Add("NM", "New Mexico");
            states.Add("NY", "New York");
            states.Add("NC", "North Carolina");
            states.Add("ND", "North Dakota");
            states.Add("OH", "Ohio");
            states.Add("OK", "Oklahoma");
            states.Add("OR", "Oregon");
            states.Add("PA", "Pennsylvania");
            states.Add("RI", "Rhode Island");
            states.Add("SC", "South Carolina");
            states.Add("SD", "South Dakota");
            states.Add("TN", "Tennessee");
            states.Add("TX", "Texas");
            states.Add("UT", "Utah");
            states.Add("VT", "Vermont");
            states.Add("VA", "Virginia");
            states.Add("WA", "Washington");
            states.Add("WV", "West Virginia");
            states.Add("WI", "Wisconsin");
            states.Add("WY", "Wyoming");

            return states;
        }
    }
}