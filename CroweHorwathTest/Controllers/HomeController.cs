using System.Web.Mvc;
using System.Web.Configuration;
using CroweHorwathTest.Models;

namespace CroweHorwathTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            string outputApplication = WebConfigurationManager.AppSettings["OutputApplication"];

            Output output = new Output();

            OutputService service;

            switch (outputApplication)
            {
                case "CONSOLE":
                    service = new OutputService(new ConsoleOutput());
                    break;

                case "DATABASE":
                    service = new OutputService(new DatabaseOutput());
                    break;

                default:
                    {                        
                        service = new OutputService(new ScreenOutput());
                        break;
                    }
            }

            service.ProcessOutput(output);

            ViewBag.Output = output;
            return View();
        }


       

    }
}
