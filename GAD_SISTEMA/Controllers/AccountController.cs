namespace GAD_SISTEMA.Controllers
{
    using GAD_SISTEMA.Models;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    public class AccountController : Controller
    {
        private readonly GadSistemaDbContext _context = new GadSistemaDbContext();

        // Acción para mostrar el formulario de inicio de sesión.
        public ActionResult Login()
        {
            return View();
        }

        // Acción POST para procesar el inicio de sesión.
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "El nombre de usuario y la contraseña son obligatorios.";
                return View();
            }

            var user = _context.Users
                .FirstOrDefault(u => u.UserName == username && u.Password == password && u.IsActive);

            if (user != null)
            {
                // Guardar datos del usuario en sesión.
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UserName;
                Session["UsuarioLogin"] = user.UsuarioLogin;
                Session["FotoUsuario"] = user.Foto ?? "~/Content/img/profile-img.jpg";

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Nombre de usuario o contraseña incorrectos.";
            return View();
        }

        [HttpGet]

        // Acción para cerrar sesión.
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}