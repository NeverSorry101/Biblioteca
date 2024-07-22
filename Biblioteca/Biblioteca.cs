using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal class Biblioteca
    {
        public string? Nome { get; set; } = String.Empty;
        public List<MediaItem> Catalogo { get; set; }

        public void AggiungiItem(MediaItem item)
        {
            Catalogo.Add(item);
        }

        public void RimuoviItem(MediaItem item)
        {
            Catalogo.Remove(item);
        }

        public Biblioteca() { 
        }
    }
}
