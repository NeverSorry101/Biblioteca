using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_db_manager.Classi
{
    internal class Enumeratori
    {
        public enum Generi
        {
            Fantascienza, Storico, Romantico, Thriller, Giallo, Biografico, Fantasy, Narrativa, Classici, Horror, Saggistica, Filosofia
        }

        public enum  Formato
        {
            PDF, EPUB, AZW, MP3, MP4
        }
        public enum Azioni
        {
            Insert , Delete , Prestito , Consegna
        }
    }
}
