using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Audiobook: Libro
    {
        public TimeSpan? Durata { get; set; }

        public string?  Narratore { get; set; }

        public Audiobook () { }

        public Audiobook(string titolo, string autore, bool status, DateTime datadiprestito, DateTime datadiconsegna, string ISBN, string Genere, int Anno, TimeSpan? durata, string? narratore  ) :base (titolo, autore, status,  datadiprestito, datadiconsegna , ISBN, Genere, Anno)
        {
            Durata = durata;
            Narratore = narratore;
        }

        public override void GetDescrizione()
        {
            base.GetDescrizione();
            Console.WriteLine($"Durata: {Durata,-15}\nNarratore: {Narratore,-15}"););
        }
    }
}
