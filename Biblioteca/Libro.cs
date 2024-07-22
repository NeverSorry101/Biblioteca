using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Libro: MediaItem 
    { 
        public string ISBN { get; set; } = string.Empty;
        public string? Genere { get; set; } = string.Empty;
        public int? Anno { get; set; } = null;
        public Libro() { }

        public Libro(string titolo, string autore, bool status, DateTime datadiprestito, DateTime datadiconsegna ,  string isbn, string? genere, int? anno ): base (titolo , autore ,  status,  datadiprestito,  datadiconsegna)
        {
            Anno = anno;
            ISBN = isbn;
            Genere = genere;
        }
       
        public override void GetDescrizione()
        {
            base.GetDescrizione();
            Console.WriteLine($"ISBN: {ISBN,-15}\nGenere: {Genere,-15}\nAnno: {Anno,-15}");
        }
    }
}
