using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agenda_de_Compromissos.App_Helpers
{
    public class RotinasWeb
    {
        public static DateTime dateTimeStringParaDateTime(string data, string hora)
        {
            if(string.IsNullOrEmpty(data) || string.IsNullOrEmpty(hora))
            {
                return DateTime.MinValue;
            }

            DateTime d;
            if(DateTime.TryParse(data + ' ' + hora, out d))
            {
                return d;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
    }
}