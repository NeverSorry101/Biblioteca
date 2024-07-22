using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Ebook : Libro
    {
        public string? FormatoFile { get; set; } = string.Empty;
        public int? DimensioneFile { get; set; }

        public Ebook() { }

        public Ebook(string titolo, string autore, bool status, DateTime datadiprestito, DateTime datadiconsegna, string ISBN, string Genere, int Anno, string? formatoFile, int? dimensioneFile) : base(titolo, autore, status, datadiprestito, datadiconsegna, ISBN, Genere, Anno)
        {
            FormatoFile = formatoFile;
            DimensioneFile = dimensioneFile;
        }

        //public Ebook(string titolo, string autore, string ISBN, string? formatoFile, int? dimensioneFile) : base(titolo, autore , ISBN)
        //{
        //    FormatoFile = formatoFile;
        //    DimensioneFile = dimensioneFile;
        //}

        public override void GetDescrizione()
        {
            base.GetDescrizione();
            Console.WriteLine($"Formato file: {FormatoFile,-15}\nDimensione file: {DimensioneFile,-15}");
        }

    }

}
