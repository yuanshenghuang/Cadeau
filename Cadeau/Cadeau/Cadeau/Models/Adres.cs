using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadeau.Models
{
    public class Adres
    {
        public int AdresId { get; set; }

        public string straat { get; set; }

        public int Nummer { get; set; }

        public int PostCode { get; set; }

        public string Gemeente { get; set; }

        public string VolledigeStraat
        {
            get
            {
                return straat + " " + Nummer + "\n" +                   
                       PostCode + " " + Gemeente;
            }
        }
    }
}