using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bedas.Models
{
    public class Edas
    {
        public int AboneGrubu { get; set; }
        public int KWH{ get; set; }
        public int AnlasmaKatsayi { get; set; }
        public double AylikIndirim { get; set; }
        public double YuzdelikIndirim { get; set; }
        public double TedasBirimFiyat{ get; set; }
        public double FirmaBirimFiyat { get; set; }
        public double Vergi{ get; set; }




    }
}