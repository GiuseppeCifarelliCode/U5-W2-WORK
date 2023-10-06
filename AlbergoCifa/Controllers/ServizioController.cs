using AlbergoCifa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbergoCifa.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServizioController : Controller
    {
        public List<Servizio> s = DB.getAllServizi();
        public List<SelectListItem> servizi
        {
            get
            {
                List<SelectListItem> listS = new List<SelectListItem>();
                foreach (Servizio servizio in s)
                {
                    SelectListItem item = new SelectListItem { Text = servizio.Descrizione, Value = servizio.Id.ToString() };
                    listS.Add(item);
                }
                return listS;
            }
        }
        // GET: Servizio
        public ActionResult Index()
        {
            return View(DB.getAllServizi());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Servizio s)
        {
            DB.AddServizio(s.Descrizione, s.Prezzo);
            return RedirectToAction("Index");
        }

        public ActionResult AddServizio(int id)
        {
            TempData["IdPrenotazione"] = DB.getPrenotazioneByIdCamera(id).Id;
            ViewBag.ListaServizi = servizi;
            return View();
        }

        [HttpPost]
        public ActionResult AddServizio(int tipoServizio, RichiestaServizio r)
        {
            if (ModelState.IsValid)
            {
                DB.AddRichiestaServizio(DateTime.Now, r.Quantita, (int)TempData["IdPrenotazione"], tipoServizio);
                return RedirectToAction("Index", "Camera");
            }
            else return View();

        }

        public ActionResult Edit(int id)
        {
            return View(DB.getServizioByIdServizio(id));
        }
        [HttpPost]
        public ActionResult Edit(Servizio s)
        {
            if(ModelState.IsValid)
            {
                DB.editServizio(s.Descrizione, s.Prezzo,s.Id);
                return RedirectToAction("Index");
            } else return View();
        }

        public ActionResult Delete(int id)
        {
            DB.deleteServizio(id);
            return RedirectToAction("Index");
        }
    }
}