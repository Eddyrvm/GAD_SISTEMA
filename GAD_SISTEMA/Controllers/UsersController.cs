using GAD_SISTEMA.Models;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;

namespace GAD_SISTEMA.Controllers
{
    public class UsersController : Controller
    {
        private readonly GadSistemaDbContext _context = new GadSistemaDbContext();
        // GET: Users

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                string tempFilePath = null;

                // Manejo de la imagen subida
                if (user.FotoFile != null && user.FotoFile.ContentLength > 0)
                {
                    string folderPath = Server.MapPath("~/ImageContent/Users");

                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    // Guardar temporalmente con un nombre genérico
                    string tempFileName = Path.GetRandomFileName() + Path.GetExtension(user.FotoFile.FileName);
                    tempFilePath = Path.Combine(folderPath, tempFileName);

                    user.FotoFile.SaveAs(tempFilePath);
                }

                _context.Users.Add(user);
                _context.SaveChanges();

                // Actualizar el nombre del archivo con el ID generado por la base de datos
                if (tempFilePath != null)
                {
                    string fileName = $"imagen_{user.UserId}.jpg";
                    string newFilePath = Path.Combine(Server.MapPath("~/ImageContent/Users"), fileName);

                    // Renombrar la imagen al ID del usuario
                    System.IO.File.Move(tempFilePath, newFilePath);
                    user.Foto = $"/ImageContent/Users/{fileName}";

                    // Guardar los cambios en la base de datos
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                }

                // Mensaje de éxito
                TempData["SuccessMessage"] = "El usuario ha sido creado exitosamente.";

                // Redirigir al índice después de la creación exitosa
                return RedirectToAction("Index");
            }

            return View(user);
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