using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    [Authorize]
    public class OggettoController : Controller
    {
        readonly Model1 cx = new Model1();
        // GET: Oggetto
        public ActionResult Home()
        {
            return View(cx.Oggetto.ToList());

        }

        // GET: Oggetto/Details/5
        public ActionResult Details(int id)
        {
            return View(cx.Oggetto.Find(id));
        }

        // GET: Oggetto/Create
        public ActionResult NewOggetto()
        {
            return View();
        }

        // POST: Oggetto/Create
        [HttpPost]
        public ActionResult NewOggetto(Oggetto og)
        {
            try
            {
                cx.Oggetto.Add(og);
                cx.SaveChanges();

                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Oggetto/Edit/5
        public ActionResult Edit(int id)
        {
            Oggetto o = cx.Oggetto.Find(id);
            return View(o);
        }

        // POST: Oggetto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Oggetto o)
        {
            try
            {
                // TODO: Add update logic here
                cx.Entry(o).State = System.Data.Entity.EntityState.Modified;
                cx.SaveChanges();
                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult PerTipo(string nome)
        {
            try
            {
                List<Denuncia> d = cx.Denuncia.Where(t => t.Oggetto.Oggetto1 == nome).ToList();
                if(d.Count > 0)
                {
                    return View(d);
                }
                else
                {
                    return RedirectToAction("Error404","Home");
                }
            }
            catch
            {
                return RedirectToAction("Error404", "Home");
            }
        }
        
    }
}
