using Bedas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bedas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Edas edas)
        {
            if (edas.KWH < 8250)
            {
                return Content("Sayın Müşteri, aktif enerji fiyatınız bir yıl boyunca sabit " + edas.KWH + " krs/kWH olacaktır. Üstelik dağıtım şirketinden güvence bedelinizi iade alabileceksiniz.");
            }

            if (edas.AnlasmaKatsayi < 3 || edas.AnlasmaKatsayi > 10)
            {
                return Content("Anlaşma Katsayısını lütfen %3 ile % 10 arasından bir değer olarak giriniz!");
            }

            switch (edas.AboneGrubu)
            {
                case 1:
                    edas.TedasBirimFiyat = 0.534213;
                    edas.Vergi = 1.2744;
                    break;
                case 2:
                    edas.TedasBirimFiyat = 0.536839;
                    edas.Vergi = 1.2744;
                    break;
                case 3:
                    edas.TedasBirimFiyat = 0.542120;
                    edas.Vergi = 1.2744;
                    break;
                case 4:
                    edas.TedasBirimFiyat = 0.498371;
                    edas.Vergi = 1.2036;
                    break;
                case 5:
                    edas.TedasBirimFiyat = 0.489238;
                    edas.Vergi = 1.2036;
                    break;
                case 6:
                    edas.TedasBirimFiyat = 0.490737;
                    edas.Vergi = 1.2036;
                    break;
                default:
                    break;
            }

            edas.FirmaBirimFiyat = 0.420 * (1 + edas.AnlasmaKatsayi / 100);
            edas.YuzdelikIndirim = (edas.FirmaBirimFiyat / edas.TedasBirimFiyat) - 1;
            edas.AylikIndirim = edas.YuzdelikIndirim * edas.KWH * edas.Vergi * edas.TedasBirimFiyat; ;

            return Content("Firma Birim Fiyat: " + edas.FirmaBirimFiyat + "</br>Yüzdelik İndirim: " + edas.YuzdelikIndirim + "</br>Aylık İndirim: " + edas.AylikIndirim);
        }
    }
}