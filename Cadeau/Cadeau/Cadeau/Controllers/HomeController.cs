using Cadeau.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cadeau.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext db = new ProductContext();

        [HttpGet]
        public ActionResult Index()
        {
            List<Product> list = new List<Product>();
            list = db.Products
                    .Where(x => x.IsSelected == false)
                    .ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(FormCollection formcollection,string priceRange)
        {
            string[] range = priceRange.Split('-');
           
            int hoeveelCharBeginPrice = range[0].Length;
           
            int hoeveelCharEndPrice = range[1].Length;

            int beginPrice =Convert.ToInt32( range[0].Substring(1, hoeveelCharBeginPrice-2));
            int endPrice =Convert.ToInt32( range[1].Substring(2, hoeveelCharEndPrice-2));

            List<Product> list1 = new List<Product>();
            List<Product> list2 = new List<Product>();
            List<Product> list3 = new List<Product>();
            list3 = db.Products
                    .Where(x => x.IsSelected == false &&  x.Prijs >= beginPrice && x.Prijs <= endPrice )                    
                    .ToList();


            if(formcollection["id"] !=null)
            {
                string[] ids = formcollection["id"].Split(new char[] { ',' });
                foreach (string item in ids)
                {
                    var product = this.db.Products.Find(int.Parse(item));
                    list1.Add(product);
                }
                foreach (var item in list1)
                {
                    item.IsSelected = true;
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    list2.Add(item);
                }
                TempData["SelectedProducts"] = list2;
                return RedirectToAction("Bevestigen");
            }
           
            return View(list3);
        }

        [HttpGet]
        public ActionResult Bevestigen()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Bevestigen(string email)
        {
            if(email == "")
            {
                ViewBag.ErrorText = "email moet ingevuld zijn.";               
            }
            else
            {
                List<Product> list = TempData["SelectedProducts"] as List<Product>;

                var body = "<p>Email From: {0} ({1})</p> <p>Message:</p> <p>{2}</p>";
                var FromName = "Hana Patros";
                var Message = "Uw geselecteerde producten zijn : "+ "<br />";
                foreach(var item in list)
                {
                    Message += item.Adres.VolledigeStraat + "<br />" +
                               item.Titel + " " + item.Winkel + " " + item.Merk +  "<br />";
                }
               
                var message = new MailMessage();
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress("yuansheng@live.be");
                message.Subject = "Bestelling";
                message.Body = string.Format(body, FromName, email, Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "yuansheng@live.be",  // replace with valid value
                        Password = "Ysh261183"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.scarlet.be";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    smtp.Send(message);                    
                }
                return RedirectToAction("Index");               
            }
            return View();
        }
    }
}
