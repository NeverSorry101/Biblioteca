using Biblioteca_db_manager.Classi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_db_manager.Interfacce
{
    internal interface IMediaAction
    {
        static void Prestito(int id_item, int DataDiPrestito) { }
        static void Prestito(int id_item) { }
        static void Restituzione(int id_item, int DataDiRestituzione) { }
        static void Restituzione(int id_item) { }
        static void Insert(Libro item) { }
        static void Insert(Audiobook item) { }
        static void Insert(Ebook item) { }
        public static void Update(int id_item , Libro item ) { } 
        public static void Update(int id_item , Audiobook item ) { } 
        public static void Update(int id_item , Ebook item ) { } 
 
    }
}
