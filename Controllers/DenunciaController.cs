using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    [Authorize]
    public class DenunciaController : Controller
    {
        readonly Model1 cx = new Model1();
        // GET: Denuncia
        public ActionResult Home()
        { 
            return View(cx.Denuncia.ToList());
        }
        public ActionResult CardHome()
        { 
            return View(cx.Denuncia.ToList());
        }

        // GET: Denuncia/Details/5
        public ActionResult Details(int id)
        {
            return View(cx.Denuncia.Find(id));
        }

        // GET: Denuncia/Create
        public ActionResult Create()
        {
            List<SelectListItem> TypeList = new List<SelectListItem>{
            (new SelectListItem { Value = "Furto", Text = "Furto" }),
            (new SelectListItem { Value = "Smarrimento", Text = "Smarrimento" })};
            ViewBag.Type = TypeList;
            ViewBag.Cit = cx.Cittadino.ToList();
            ViewBag.Ogg = cx.Oggetto.ToList();
            ViewBag.Ag = cx.User.ToList();
            return View();
        }

        // POST: Denuncia/Create
        [HttpPost]
        public ActionResult Create(Denuncia d, HttpPostedFileBase ProdImg)
        {
            try
            {
                if (ProdImg != null)
                {
                    string pathDisk = Server.MapPath("~/IMGs");
                    ProdImg.SaveAs(Path.Combine(pathDisk, ProdImg.FileName));
                }
                d.FotoOggetto = ProdImg.FileName;
                d.IsTrovato = false;
                cx.Denuncia.Add(d);
                cx.SaveChanges();
                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Denuncia/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> TypeList = new List<SelectListItem> {
            new SelectListItem { Value = "Furto", Text = "Furto" },
            new SelectListItem { Value = "Smarrimento", Text = "Smarrimento" }
        };
            ViewBag.Type = TypeList;
            ViewBag.Cit = cx.Cittadino.ToList();
            ViewBag.Ogg = cx.Oggetto.ToList();
            ViewBag.Ag = cx.User.ToList();

            Denuncia d= cx.Denuncia.Find(id);
            return View(d);
        }

        // POST: Denuncia/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, Denuncia d, HttpPostedFileBase ProdImg)
        public ActionResult Edit(int id,Denuncia d, HttpPostedFileBase ProdImg)
        {
            try
            {
                Denuncia d2 = d;
                d2.idDenuncia = id;
                if (ProdImg != null)
                {
                    string pathDisk = Server.MapPath("~/IMGs");
                    ProdImg.SaveAs(Path.Combine(pathDisk, ProdImg.FileName));
                }
                d2.FotoOggetto = ProdImg.FileName;
                cx.Entry(d2).State = System.Data.Entity.EntityState.Modified;
                cx.SaveChanges();
                return RedirectToAction("Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Denuncia/Trovato/5
        public ActionResult Trovato(int id)
        {
            //List<Cittadino> cit = cx.Cittadino.ToList();
            //foreach (Cittadino i in cit)
            //{
            //    i.Nome = i.Nome + " " + i.Cognome;
            //}

            ViewBag.Cit = cx.Cittadino.Select(c => c.idCittadino + c.Nome + " " + c.Cognome).ToList();
            return View(cx.Denuncia.Find(id));
        }

        // POST: Denuncia/Trovato/5
        [HttpPost]
        public ActionResult Trovato([Bind(Include = "idDenuncia,DataRitrovo, idTrova")] int id, Denuncia d)
        
        {
            //try
            //{
            Denuncia d2 = cx.Denuncia.Find(id);
           
            d2.IsTrovato = true;
            d2.DataRitrovo = d.DataRitrovo;
            d2.idTrova = d.idTrova;
            
            cx.Entry(d2).State = EntityState.Modified;
            cx.SaveChanges();
            return RedirectToAction("Home");
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
