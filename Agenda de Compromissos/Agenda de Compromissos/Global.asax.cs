using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing; //Classe RouteTable (adicionado)
using System.Web.Mvc; //Método de Extensão MapRoute (adicionado)


namespace Agenda_de_Compromissos
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //
            // Cria um roteamento:
            // http://servidor/classeController/metodo
            // exemplo:
            // http://servidor/Produtos/ListagemGeral
            //
            //RouteTable.Routes.MapRoute("Roteamento", "{controller}/{action}");
            //Outro roteamento
            //RouteTable.Routes.MapRoute("RoteamentoComParametro", "{controller}/{action}/{id}");

            RouteTable.Routes.MapRoute(name: "Default",
                                       url: "{controller}/{action}/{id}",
                                       defaults: new { controller = "Agenda", action = "Listagem", id = UrlParameter.Optional }
);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}