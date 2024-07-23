using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_db_manager.Classi
{
    internal class Libro : MediaItem
    {
        public string ISBN { get; set; } = string.Empty;
        public Enumeratori.Generi? Genere { get; set; }
        public int? Anno { get; set; } = null;
        public Libro() { }

        public Libro(string titolo, string autore, bool status, int? datadiprestito, int? datadiconsegna, string isbn, Enumeratori.Generi? genere, int? anno) : base(titolo, autore, status, datadiprestito, datadiconsegna)
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

        public static  void Insert()
        {

        }
    }
}
