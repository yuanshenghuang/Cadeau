using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cadeau.Models
{
    public class InitialData : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var AdresList = new List<Adres>
            {
                new Adres
                {
                     AdresId=1,
                     straat= "meir",
                     Nummer=55,
                     PostCode =2000,
                     Gemeente = "Antwerpen"
                },
                new Adres
                {
                     AdresId=2,
                     straat= "meir",
                     Nummer=155,
                     PostCode =2000,
                     Gemeente = "Antwerpen"
                },
                new Adres
                {
                     AdresId=3,
                     straat= "antwerpen zuid",
                     Nummer=15,
                     PostCode =2018,
                     Gemeente = "Antwerpen"
                }
            };

            AdresList.ForEach(s => context.Adres.Add(s));
            context.SaveChanges();


            var ProductList = new List<Product>
            {
                new Product
                {
                     AdresId = 1,
                     ProductId=1,
                     Titel = "schoen",
                     Merk= "addidas",
                     Prijs = 40,
                     Winkel="shoe Discount",
                     IsSelected= false
                },
                new Product
                {
                     AdresId = 2,
                     ProductId=2,
                     Titel = "jas",
                     Merk= "zara",
                     Prijs = 140,
                     Winkel="zara",
                     IsSelected= false
                },
                 new Product
                {
                     AdresId = 3,
                     ProductId=3,
                     Titel = "Cava",
                     Merk= "Cava",
                     Prijs = 15,
                     Winkel="Colryt",
                     IsSelected= false
                }
            };

            ProductList.ForEach(s => context.Products.Add(s));
            context.SaveChanges();


            

        }
    }
}