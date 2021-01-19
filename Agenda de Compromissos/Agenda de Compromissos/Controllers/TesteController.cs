using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agenda_de_Compromissos.Controllers
{
    public class TesteController : Controller
    {
        public string Metodo01()
        {
            return "Teste MVC : " + DateTime.Now.ToLongDateString();
        }

        public ViewResult Metodo02()
        {
            return View();
        }


    }
}