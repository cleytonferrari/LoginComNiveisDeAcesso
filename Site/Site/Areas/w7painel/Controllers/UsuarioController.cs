using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Site.Areas.w7painel.Helpers;
using Site.Areas.w7painel.Models;
using Site.Models;

namespace Site.Areas.w7painel.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /w7painel/Usuario/
        private readonly SiteContext db = new SiteContext();

        [Seguranca]
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Seguranca]
        public ActionResult Index()
        {

            return View(db.Usuarios.Include("Grupo").ToList());
        }

        //
        // GET: /w7painel/Usuarios/Details/5
        [Seguranca]
        public ViewResult Details(int id)
        {
            Usuario usuario = db.Usuarios.Include("Grupo").FirstOrDefault(x => x.Id == id);
            return View(usuario);
        }

        //
        // GET: /w7painel/Usuarios/Create
        [Seguranca]
        public ActionResult Create()
        {
            ViewBag.Grupos = new SelectList(db.Grupos.ToList(), "Id", "Nome");
            return View();
        }

        //
        // POST: /w7painel/Usuarios/Create

        [HttpPost]
        [Seguranca]
        public ActionResult Create(Usuario usuario)
        {
            ViewBag.Grupos = new SelectList(db.Grupos.ToList(), "Id", "Nome");
            if (ModelState.IsValid)
            {
                usuario.Grupo = db.Grupos.ToList().FirstOrDefault(x => x.Id == usuario.Grupo.Id);
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /w7painel/Usuarios/Edit/5
        [Seguranca]
        public ActionResult Edit(int id)
        {
            ViewBag.Grupos = new SelectList(db.Grupos.ToList(), "Id", "Nome");
            Usuario usuario = db.Usuarios.Include("Grupo").FirstOrDefault(x => x.Id == id);
            return View(usuario);
        }

        //
        // POST: /w7painel/Usuarios/Edit/5

        [HttpPost]
        [Seguranca]
        public ActionResult Edit(Usuario usuario)
        {
            ViewBag.Grupos = new SelectList(db.Grupos.ToList(), "Id", "Nome");
            if (ModelState.IsValid)
            {
                var user = db.Usuarios.Find(usuario.Id);
                user.Login = usuario.Login;
                user.Nome = usuario.Nome;
                user.Pass = usuario.Pass;
                user.Email = usuario.Email;

                user.Grupo = db.Grupos.ToList().FirstOrDefault(x => x.Id == usuario.Grupo.Id);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /w7painel/Usuarios/Delete/5
        [Seguranca]
        public ActionResult Delete(int id)
        {
            Usuario usuario = db.Usuarios.Include("Grupo").FirstOrDefault(x => x.Id == id);
            return View(usuario);
        }

        //
        // POST: /w7painel/Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [Seguranca]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Seguranca]
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
