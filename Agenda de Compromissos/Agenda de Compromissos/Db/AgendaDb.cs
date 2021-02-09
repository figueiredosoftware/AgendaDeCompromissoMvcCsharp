using Agenda_de_Compromissos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Agenda_de_Compromissos.Db
{
    public class AgendaDb : DbContext
    {
        private const string conexao1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Alessandro\Projetos\Projetos Versionados\AgendaDeCompromissoMvcCsharp\Agenda de Compromissos\Agenda de Compromissos\App_Data\AgendaDb.mdf';Integrated Security=True";
        private const string conexao2 = @"Data Source=LAPTOP-GN8IVRU3\SQLEXPRESS;Initial Catalog=AgendaDb;User ID=sa;Password=xuip35";

        public AgendaDb() : base(conexao1)
        {
        }

        public DbSet<Agenda> Compromissos { get; set; }
    }
}