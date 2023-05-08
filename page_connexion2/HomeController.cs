using System.Web.Mvc;

namespace MonProjet.Controllers
{
    public class HomeController : Controller
    {
        // Action pour la page d'accueil
        public ActionResult Index()
        {
            // Affichage de la vue Index.cshtml
            return View();
        }
    }
}
