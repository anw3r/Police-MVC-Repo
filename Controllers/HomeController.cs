using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FinalProject.Controllers
{
    //[Authorize(Roles ="user")]
    public class HomeController : Controller
    {
        readonly Model1 cx = new Model1();
        public ActionResult Home()
        {
            #region useless
            //List<SelectListItem> years = new List<SelectListItem>();
            //years.Add(new SelectListItem { Value = "2016", Text = "2016" });
            //years.Add(new SelectListItem { Value = "2017", Text = "2017" });
            //years.Add(new SelectListItem { Value = "2018", Text = "2018" });
            //years.Add(new SelectListItem { Value = "2019", Text = "2019" });
            //years.Add(new SelectListItem { Value = "2020", Text = "2020" });
            //years.Add(new SelectListItem { Value = "2021", Text = "2021" });

            //string[] names = DateTimeFormatInfo.CurrentInfo.MonthNames;

            //ViewBag.Mesi = names;
            //ViewBag.Anni = years;
            #endregion

            List<SelectListItem> search = new List<SelectListItem>
            {
            (new SelectListItem { Value = "1", Text = "Ricerca per Data" }),
           (new SelectListItem { Value = "2", Text = "Lista Autovetture Rubate/Smarrite" }),
            (new SelectListItem { Value = "3", Text = "Lista Oggetti Ritrovati" }),
            (new SelectListItem { Value = "4", Text = "Percentuale ritrovati" })
            };
        ViewBag.search = search;
            return View();
        }

        [AllowAnonymous]
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User u)
        {
            User ToLog = cx.User.Where(user => user.Username == u.Username).Where(pass => pass.Password == u.Password).FirstOrDefault();
            if (ToLog != null)
            {
                FormsAuthentication.SetAuthCookie(ToLog.Username, true);
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.Errore = "Username e/o Password Incorretti";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

        public JsonResult Op1(DateTime m)
        {
            var mese = m.Month;
            var anno = m.Year;
            List<Cuscinetto> dlist = new List<Cuscinetto>();
            var den = cx.Denuncia.Where(denuncia => denuncia.DataDenuncia.Month == mese).Where(denuncia => denuncia.DataDenuncia.Year == anno).ToList();
            foreach (var i in den)
            {
                Cuscinetto c = new Cuscinetto
                {
                    idTrova = i.idTrova.ToString(),
                    NomeOggetto = i.Oggetto.Oggetto1,
                    DataAcca = i.DataAcca,
                    Tipo = i.Tipo,
                    Foto = i.FotoOggetto,
                    DataDenuncia = i.DataDenuncia,
                    Descrizione = i.Descrizione,
                    DataRitrovo = i.DataRitrovo,
                };
                dlist.Add(c);
            }
            return Json(dlist,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Op2()
        {
            List<Denuncia> den = cx.Denuncia.Where(denuncia => denuncia.Oggetto.Oggetto1 == "Autovettura").ToList();
            List<Cuscinetto> dlist = new List<Cuscinetto>();
            foreach (Denuncia i in den)
            {
                Cuscinetto c = new Cuscinetto
                {
                    idTrova = i.idTrova.ToString(),
                    NomeOggetto = i.Oggetto.Oggetto1,
                    DataAcca = i.DataAcca,
                    Tipo = i.Tipo,
                    Foto = i.FotoOggetto,
                    DataDenuncia = i.DataDenuncia,
                    Descrizione = i.Descrizione,
                    DataRitrovo = i.DataRitrovo,
                };
                dlist.Add(c);

            }
            return Json(dlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Op3()
        {
            List<Denuncia> den = cx.Denuncia.Where(denuncia => denuncia.IsTrovato == true).ToList();
            List<Cuscinetto> dlist = new List<Cuscinetto>();
            foreach (Denuncia i in den)
            {
                Cuscinetto c = new Cuscinetto
                {
                    idTrova = i.idTrova.ToString(),
                    NomeOggetto = i.Oggetto.Oggetto1,
                    DataAcca = i.DataAcca,
                    Tipo = i.Tipo,
                    Foto = i.FotoOggetto,
                    DataDenuncia = i.DataDenuncia,
                    Descrizione = i.Descrizione,
                    DataRitrovo = i.DataRitrovo,
                };
                dlist.Add(c);

            }
            return Json(dlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Op4()
        {
            decimal tot=cx.Denuncia.Count();
            decimal trovati = cx.Denuncia.Where(d => d.IsTrovato == true).Count();
            var perc = trovati/tot *100;
            
            return Json((int)perc, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsAlreadySigned(string UserEmailId)
        {

            return Json(IsUserAvailable(UserEmailId));

        }
        public JsonResult IsUserAvailable(string username)
        {
            //username = "anwar";
            //bool stato;
            
            //if(cx.User.Where(u => u.Username == username).FirstOrDefault() != null)
            //{
            //    stato = true;
            //}
            //else
            //{
            //    stato= false;
            //}
            
            return Json(true,JsonRequestBehavior.AllowGet);
       
        }

        public ActionResult Error404()
        {

            return View();
        }
    }
}