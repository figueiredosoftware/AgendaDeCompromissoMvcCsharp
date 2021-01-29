using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda_de_Compromissos.Models
{
    public class Agenda
    {
        public int AgendaId { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

        //Retorna uma string com erros se houver
        public List<string> Validar()
        {
            List<string> listaErros = new List<string>();

            if(DataHora == DateTime.MinValue || DataHora == null)
            {
                listaErros.Add("Data Inválida");
            }

            if(string.IsNullOrEmpty(Descricao) || Descricao.Trim().Length == 0)
            {
                listaErros.Add("Descrição não pode ser vazia");
            }

            return listaErros;
        }
    }
}