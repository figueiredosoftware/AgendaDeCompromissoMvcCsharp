using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda_de_Compromissos.Models
{
    public class AgendaViewModel
    {
        public int AgendaId { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }

        public AgendaViewModel()
        {
            Data = DateTime.Now.ToShortDateString();
            Hora = DateTime.Now.ToShortTimeString();
        }
    }
}