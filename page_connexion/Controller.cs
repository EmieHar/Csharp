public class AccountController : Controller
{
    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Login(User user)
    {
        // Vérifier les informations de connexion de l'utilisateur ici

        return RedirectToAction("Index", "Home");
    }
}
