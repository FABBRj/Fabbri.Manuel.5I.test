using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Fabbri.Manuel._5i.XMLReadWrite2.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        

        /// <summary>
        /// ///
        /// </summary>

        private string nomeFile = HostingEnvironment.MapPath(@"~/App_Data/Persone.xml");

        public ActionResult Index()
        {
            XElement data = XElement.Load(nomeFile);
            var persone = (from l in data.Elements("Persona") select new Persona(l)).ToList();
            return View(persone);
        }

        public ActionResult XMLReadWrite(int nn = 0)
        {
            var p = new Persone(nomeFile);

            if (nn != 0)
                p.Aggiungi();

            return View(p);
        }

        public ActionResult AddPredefinito()
        {
            var p = new Persone(nomeFile);
            p.Aggiungi();

            return View("XMLReadWrite", p);
        }

        public ActionResult DelSelected()
        {
            var p = new Persone(nomeFile);
            p.Aggiungi();

            return View("XMLReadWrite", p);
        }
    }
}