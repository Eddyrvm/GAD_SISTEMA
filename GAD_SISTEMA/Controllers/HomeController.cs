using System.Web.Mvc;

namespace GAD_SISTEMA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Obtener el nombre de usuario desde la sesión.
            var usuariologin = Session["UsuarioLogin"]?.ToString();

            // Pasar el nombre de usuario a la vista mediante ViewBag.
            ViewBag.UsuarioLogin = usuariologin;

            return View();
        }

    }
}