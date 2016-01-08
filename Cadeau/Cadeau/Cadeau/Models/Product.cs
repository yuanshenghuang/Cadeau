using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cadeau.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name="Productnaam")]
        public string Titel { get; set; }

        [Required]
        public string Winkel { get; set; }

        [Required]
        public string Merk { get; set; }

        [Required]
        public Decimal Prijs { get; set; }

        [Display(Name="Uitgekozen")]
        public bool IsSelected { get; set; }

        [Display(Name="Adres")]
        public int AdresId { get; set; }

        public virtual Adres Adres { get; set; }
    }
}