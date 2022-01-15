using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    [Authorize]
    public class CittadinoController : Controller
    {
        readonly Model1 cx = new Model1();
        // GET: Cittadino
        public ActionResult Home()
        {
            return View(cx.Cittadino.ToList());
        }


        // GET: Cittadino/Create
        public ActionResult NewCittadino()
        {
            List<SelectListItem> docs = new List<SelectListItem>{
            (new SelectListItem { Value = "Carta d'Identità", Text = "Carta d'Identità" }),
            (new SelectListItem { Value = "Permesso di Soggiorno", Text = "Permesso di Soggiorno" }),
            (new SelectListItem { Value = "Patente", Text = "Patente" }),
            (new SelectListItem { Value = "Passaporto", Text = "Passaporto" })};
            ViewBag.doc = docs;
            var cities = System.TimeZoneInfo.GetSystemTimeZones().ToList();
            ViewBag.city = cities;
            return View();
        }

        // POST: Cittadino/Create
        [HttpPost]
        public ActionResult NewCittadino(Cittadino cit)
        {
            try
            {
                cx.Cittadino.Add(cit);
                cx.SaveChanges();

                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

       
        // GET: Cittadino/Details/5
        public ActionResult Dettagli(int id)
        {
            Cittadino c= cx.Cittadino.Find(id);
            return View(c);
        }

        // GET: Cittadino/Edit/5
        public ActionResult Modifica(int id)
        {
            List<SelectListItem> docs = new List<SelectListItem>{
            (new SelectListItem { Value = "Carta d'Identità", Text = "Carta d'Identità" }),
            (new SelectListItem { Value = "Permesso di Soggiorno", Text = "Permesso di Soggiorno" }),
            (new SelectListItem { Value = "Patente", Text = "Patente" }),
            (new SelectListItem { Value = "Passaporto", Text = "Passaporto" })};
            ViewBag.doc = docs;
            var cities = System.TimeZoneInfo.GetSystemTimeZones().ToList();
            ViewBag.city = cities;
            Cittadino c = cx.Cittadino.Find(id);
            return View(c);
        }

        // POST: Cittadino/Edit/5
        [HttpPost]
        public ActionResult Modifica(int id, Cittadino cit)
        {
            try
            {
                cit.idCittadino = id;
                cx.Entry(cit).State = System.Data.Entity.EntityState.Modified;
                cx.SaveChanges();
                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NewAgente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAgente(User u)
        {
            cx.User.Add(u);
            cx.SaveChanges();
            return View();
        }



    //// GET: Cittadino/Delete/5
    //public ActionResult Delete(int id)
    //{
    //    return View();
    //}

    //// POST: Cittadino/Delete/5
    //[HttpPost]
    //public ActionResult Delete(int id, FormCollection collection)
    //{
    //    try
    //    {
    //        // TODO: Add delete logic here

    //        return RedirectToAction("Index");
    //    }
    //    catch
    //    {
    //        return View();
    //    }
    //}
}
}
