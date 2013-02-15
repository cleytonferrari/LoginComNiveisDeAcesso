using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Site.Areas.w7painel.Helpers;
using Site.Areas.w7painel.Models;
using Site.Areas.w7painel.Models.ViewModel;
using Site.Models;

namespace Site.Areas.w7painel.Controllers
{
    public class GrupoController : Controller
    {
        private SiteContext db = new SiteContext();

        [Seguranca]
        public ViewResult Index()
        {
            return View(db.Grupos.Include(x => x.Permissoes).ToList());
        }

        [Seguranca]
        public ViewResult Details(int id)
        {
            var grupo = db.Grupos.Include(x => x.Permissoes).Include(x => x.Permissoes.Select(y => y.Plugin)).FirstOrDefault(x => x.Id == id);
            return View(grupo);
        }

        [Seguranca]
        public ActionResult Create()
        {
            var grupo = new Grupo() { Permissoes = new Collection<Permissao>() };
            PopularPermissoesAssociadas(grupo);
            return View();
        }

        [HttpPost]
        [Seguranca]
        public ActionResult Create([Bind(Exclude = "Permissoes")]Grupo grupo, string[] permissoesSelecionadas)
        {
            grupo.Permissoes = new List<Permissao>();
            if (ModelState.IsValid)
            {
                AtualizarPermissoesNoGrupo(permissoesSelecionadas, grupo);
                db.Grupos.Add(grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            AtualizarPermissoesNoGrupo(permissoesSelecionadas, grupo);
            return View(grupo);
        }

        private void PopularPermissoesAssociadas(Grupo grupo)
        {
            var todasPermissoes = db.Permissoes.ToList();
            var permissoesGrupo = new HashSet<int>(grupo.Permissoes.Select(c => c.Id));
            var viewModel = new List<PermissoesAssociadasAoGrupo>();
            foreach (var permissao in todasPermissoes)
            {
                viewModel.Add(new PermissoesAssociadasAoGrupo
                {
                    Permissao = permissao,
                    Associado = permissoesGrupo.Contains(permissao.Id)
                });
            }
            ViewBag.Permissoes = viewModel;
            ViewBag.Plugins = db.Plugins.ToList();
        }

        private void AtualizarPermissoesNoGrupo(string[] permissoesSelecionadas, Grupo grupoParaAtualizar)
        {
            if (permissoesSelecionadas == null)
            {
                grupoParaAtualizar.Permissoes = new List<Permissao>();
                return;
            }

            var permissoesSelecionadasHS = new HashSet<string>(permissoesSelecionadas);
            var permissoesDoGrupo = new HashSet<int>(grupoParaAtualizar.Permissoes.Select(c => c.Id));
            foreach (var permissao in db.Permissoes)
            {
                if (permissoesSelecionadasHS.Contains(permissao.Id.ToString()))
                {
                    if (!permissoesDoGrupo.Contains(permissao.Id))
                        grupoParaAtualizar.Permissoes.Add(permissao);
                }
                else
                {
                    if (permissoesDoGrupo.Contains(permissao.Id))
                        grupoParaAtualizar.Permissoes.Remove(permissao);
                }
            }
        }


        [Seguranca]
        public ActionResult Edit(int id)
        {
            var grupo = db.Grupos.Include(x => x.Permissoes).FirstOrDefault(x => x.Id == id);
            PopularPermissoesAssociadas(grupo);
            return View(grupo);
        }

        [HttpPost]
        [Seguranca]
        public ActionResult Edit([Bind(Exclude = "Permissoes")]Grupo grupo, string[] permissoesSelecionadas)
        {
            var grupoParaAtualizar = db.Grupos.Include(x => x.Permissoes).Single(x => x.Id == grupo.Id);

            if (ModelState.IsValid)
            {
                AtualizarPermissoesNoGrupo(permissoesSelecionadas, grupoParaAtualizar);
                grupoParaAtualizar.Nome = grupo.Nome;
                db.Entry(grupoParaAtualizar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopularPermissoesAssociadas(grupo);
            return View(grupo);
        }

        [Seguranca]
        public ActionResult Delete(int id)
        {
            var grupo = db.Grupos.Include(x => x.Permissoes).Include(x => x.Permissoes.Select(y => y.Plugin)).FirstOrDefault(x => x.Id == id);
           
            return View(grupo);
        }

        [HttpPost, ActionName("Delete")]
        [Seguranca]
        public ActionResult DeleteConfirmed(int id)
        {
            var grupo = db.Grupos.Find(id);
            db.Grupos.Remove(grupo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}