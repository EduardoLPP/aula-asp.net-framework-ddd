using NOTION.Dominio.Servicos;
using NOTION.Infra.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotionInterfaceWeb.Controllers
{
    public class ListaDeTarefasController : Controller
    { 
   
        private ServicoDeListaDeTarefas ServicoDeListaDeTarefas { get; set; }
        
        public ListaDeTarefasController()
        {
            this.ServicoDeListaDeTarefas = FabricaGenericaNotion.Crie<ServicoDeListaDeTarefas>();
        }
        
        [ChildActionOnly]
        public ActionResult Index()
        {
            var listaDeTarefas = this.ServicoDeListaDeTarefas.ObtenhaTodasAsTarefas();
            return View(listaDeTarefas);
        }
    }
} 