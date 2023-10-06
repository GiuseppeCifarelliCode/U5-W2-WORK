using AlbergoCifa.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbergoCifa.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CameraController : Controller
    {
        public List<Servizio> s = DB.getAllServizi();
        public List<SelectListItem> servizi
        {
            get
            {
                List<SelectListItem> listS = new List<SelectListItem>();
                foreach(Servizio servizio in s)
                {
                    SelectListItem item = new SelectListItem { Text = servizio.Descrizione, Value = servizio.Id.ToString()};
                    listS.Add(item);
                }
                return listS;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.CamereOccupate = DB.getAllBusyRooms();
            return View(DB.getAllFreeRooms());
        }

        public ActionResult CheckOut(int id)
        {
            Prenotazione p = DB.getPrenotazioneByIdCamera(id);
            ViewBag.ListaServizi = DB.getAllServiziRichiestiByIdPrenotazione(p.Id);
            ViewBag.CostoServizi = RichiestaServizio.CalcolaCostoTotale(DB.getAllServiziRichiestiByIdPrenotazione(p.Id));
            return View(DB.getPrenotazioneByIdCamera(id));
        }

        public ActionResult Paga(int id)
        {
            DB.changePrenotazioneState(id);
            DB.changeCameraState(DB.getPrenotazioneById(id).IdCamera);
            return RedirectToAction("Index");
        }

        public ActionResult Queries()
        {
            return View();
        }
        public ActionResult SearchByCF(string cf)
        {
            List<Prenotazione> p = DB.getPrenotazioniByCF(cf);
            var formattedP = p.Select(s => new
            {
                s.Id,
                DataPrenotazione = s.DataPrenotazione.ToString("yyyy-MM-dd"),
                s.Anno,
                DataInizio = s.DataInizio.ToString("yyyy-MM-dd"),
                DataFine = s.DataFine.ToString("yyyy-MM-dd"),
                s.Caparra,
                s.Tariffa,
                s.MezzaPensione,
                s.PrimaColazione,
                s.IdCliente,
                s.IdCamera
            }).ToList();

            return Json(formattedP, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getTotPrenotazioniPerPensioneCompleta()
        {
            int tot = DB.getTotPrenotazioniPerPensioneCompleta();
            return Json(tot, JsonRequestBehavior.AllowGet);
        }
    }
}