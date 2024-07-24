using Biblioteca_db_manager.Classi;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Biblioteca_db_manager.Classi.Enumeratori;

namespace Biblioteca_db_manager
{
    internal class Audiobook: Libro
    {
        public TimeSpan? Durata { get; set; }

        public string?  Narratore { get; set; }

        public Audiobook () { }

        public Audiobook(string titolo, string autore, bool status, int datadiprestito, int datadiconsegna, string ISBN, Generi Genere, int Anno, TimeSpan? durata, string? narratore  ) :base (titolo, autore, status,  datadiprestito, datadiconsegna , ISBN, Genere, Anno)
        {
            Durata = durata;
            Narratore = narratore;
        }

    }
}
