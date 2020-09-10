using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Zahlenratspiel_Webseite.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            Random random = new Random();
            int tries = 0;
            int randomNumber = random.Next(1, 100);
            Session.Add("zahl", randomNumber);
            Session.Add("tries", tries);
            return View();
        }

        [HttpPost]
        public ActionResult Index(int eingabe)
        {
            int tries = (int)Session.Contents["tries"];
            int randomnumber = (int)Session.Contents["zahl"];
            if (eingabe < 1)
            {
                ViewBag.ERROR = "Bitte geben sie eine Zahl zwischen 1-100 ein!";
            }
            if (eingabe > 100)
            {
                ViewBag.ERROR = "Bitte geben sie eine Zahl zwischen 1-100 ein!";
            }
            if (eingabe == randomnumber)
            {
                Session.Add("ausgabe", "Yuhuu richtig");
                tries++;
                Session.Contents["tries"] = tries;
            }
            if (eingabe > randomnumber)
            {
                ViewBag.ERROR = "Zahl zu gross!";
                tries++;
                Session.Contents["tries"] = tries;
            }
            if (eingabe < randomnumber)
            {
                ViewBag.ERROR = "Zahl zu klein!";
                tries++;
                Session.Contents["tries"] = tries;
            }
            return View();
        }
    }
}