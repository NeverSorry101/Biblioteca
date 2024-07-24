using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_db_manager.Interfacce;

namespace Biblioteca_db_manager.Classi
{
    internal abstract class MediaItem: Sql_actions // IMediaAction
    {   
        public int Id_MediaItem {  get; set; }
        public string Titolo { get; set; } = string.Empty;
        public string Autore { get; set; } = string.Empty;
        public bool Status { get; set; } = false;

        public int? DataDiPrestito { get; set; } = null;

        public int? DataDiRestituzione { get; set; } = null;

        public MediaItem() { }

        public MediaItem(string titolo, string autore, bool status, int? datadiprestito, int? datadiconsegna)
        {
            Titolo = titolo;
            Autore = autore;
            Status = status;
            DataDiPrestito = datadiprestito;
            DataDiRestituzione = datadiconsegna;
        }



       
    }


    
}
