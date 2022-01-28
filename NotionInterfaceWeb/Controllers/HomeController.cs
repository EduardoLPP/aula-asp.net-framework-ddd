using NOTION.Dominio.Servicos;
using NOTION.Infra.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotionInterfaceWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
      
            return View();
        }
        
    }
}