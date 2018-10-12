using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerAccounting.Models;

namespace CustomerAccounting.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ClientsDbContext())
            {
                var clients = context.Clients.ToList();
                return View(clients);
            }

        }

        public ActionResult Delete(int id)
        {
            using (var context = new ClientsDbContext())
            {
                var client = context.Clients.SingleOrDefault(q => q.Id == id);

                if (client == null) return HttpNotFound();

                context.Clients.Remove(client);
                context.SaveChanges();

                var clients = context.Clients.ToList();
                return PartialView("_ClientList", clients);
            }
        }

        [HttpPost]
        public ActionResult Invoice(int id)
        {
            Client client;
            using (var context = new ClientsDbContext())
                client = context.Clients.SingleOrDefault(q => q.Id == id);

            if (client == null) return HttpNotFound();

            var fileName = client.Name + ".txt";
            var fullPath = Path.Combine(Server.MapPath("~/temp"), fileName);

            var content = String.Format("{{ ID = \"{0}\", Name = \"{1}\", Description = \"{2}\", Age = \"{3}\", Date = \"{4}\" }}",
                client.Id, client.Name, client.Description, client.Age, client.Date.ToShortDateString());

            var file = new FileInfo(fullPath);
            file.Directory?.Create();
            System.IO.File.WriteAllText(file.FullName, content);

            return Json(new { filename = fileName });
        }

        [HttpGet]
        public ActionResult Download(string filename)
        {
            var fullPath = Path.Combine(Server.MapPath("~/temp"), filename);
            return File(fullPath, "text/plain", filename);
        }

    }
}