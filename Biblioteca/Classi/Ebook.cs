using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca_db_manager.Classi.Enumeratori;

namespace Biblioteca_db_manager.Classi
{
    internal class Ebook : Libro
    {
        public string? FormatoFile { get; set; } = string.Empty;
        public int? DimensioneFile { get; set; }

        public Ebook() { }

        public Ebook(string titolo, string autore, bool status, int datadiprestito, int datadiconsegna, string ISBN, Generi Genere, int Anno, string? formatoFile, int? dimensioneFile) : base(titolo, autore, status, datadiprestito, datadiconsegna, ISBN, Genere, Anno)
        {
            FormatoFile = formatoFile;
            DimensioneFile = dimensioneFile;
        }



    }

}
