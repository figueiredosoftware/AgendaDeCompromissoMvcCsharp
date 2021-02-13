using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Agenda_de_Compromissos.Db;
using Agenda_de_Compromissos.Models;
using Agenda_de_Compromissos.App_Helpers;

namespace Agenda_de_Compromissos.Controllers
{
    public class AgendaController : Controller
    {
        //INCLUSÃO
        [HttpGet]
        public ViewResult Incluir()
        {
            var compromissoPadrao = new AgendaViewModel();
            return View(compromissoPadrao);
        }

        [HttpPost]
        public ActionResult Incluir(AgendaViewModel agendaForm)
        {
            var agenda = new Agenda();
            agenda.DataHora = RotinasWeb.dateTimeStringParaDateTime(agendaForm.Data, agendaForm.Hora);
            agenda.Descricao = agendaForm.Descricao;
            var erros = agenda.Validar();
            if (erros.Count == 0)
            {
                var db = new AgendaDb();
                db.Compromissos.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("IncluirOK", "Agenda");
            }
            else
            {
                ViewBag.Erros = erros;
                return View(agendaForm);
            }
        }

        [HttpGet]
        public ViewResult IncluirOK()
        {
            return View();
        }

        //LISTAGEM
        [HttpGet]
        public ViewResult Listagem()
        {
            var db = new AgendaDb();
            var query = from c in db.Compromissos orderby c.DataHora descending select c;
            var lista = query.ToList();

            var listaAgendaViewModel = new List<AgendaViewModel>();
            foreach(var d in lista)
            {
                listaAgendaViewModel.Add(new AgendaViewModel()
                {
                    AgendaId = d.AgendaId,
                    Descricao = d.Descricao,
                    Data = d.DataHora.ToString("ddd dd/MM/yyyy"),
                    Hora = d.DataHora.ToShortTimeString()
                });
            }
            return View(listaAgendaViewModel);
        }

        //ALTERAR
        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var db = new AgendaDb();
            var compromisso = (from c in db.Compromissos where c.AgendaId == id select c).FirstOrDefault();
            if(compromisso == null)
            {
                return RedirectToAction("Listagem", "Agenda");
            }
            else
            {
                var agendaViewModel = new AgendaViewModel()
                {
                    AgendaId = compromisso.AgendaId,
                    Data = compromisso.DataHora.ToShortDateString(),
                    Hora = compromisso.DataHora.ToShortTimeString(),
                    Descricao = compromisso.Descricao
                };
                return View(agendaViewModel);
            }
        }

        [HttpPost]
        public ActionResult Alterar(AgendaViewModel agendaViewModel)
        {
            var db = new AgendaDb();
            var compromisso = (from c in db.Compromissos where c.AgendaId == agendaViewModel.AgendaId select c).FirstOrDefault();

            if(compromisso == null)
            {
                return RedirectToAction("Listagem", "Agenda");
            }
            else
            {
                compromisso.Descricao = agendaViewModel.Descricao;
                compromisso.DataHora = RotinasWeb.dateTimeStringParaDateTime(agendaViewModel.Data, agendaViewModel.Hora);
                var erros = compromisso.Validar();

                if(erros.Count > 0)
                {
                    ViewBag.Erros = erros;
                    return View(agendaViewModel);
                }
                else
                {
                    db.Compromissos.Add(compromisso);
                    db.SaveChanges();
                    return RedirectToAction("Listagem", "Agenda");
                }
            }
        }

        [HttpGet]
        public ActionResult Excluir(int id)
        {
            var db = new AgendaDb();
            var compromisso = (from c in db.Compromissos where c.AgendaId == id select c).FirstOrDefault();

            if(compromisso != null)
            {
                db.Compromissos.Remove(compromisso);
                db.SaveChanges();
            }
            return RedirectToAction("Listagem", "Agenda");
        }
    }
}