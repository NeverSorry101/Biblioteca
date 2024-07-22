using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal abstract class MediaItem : IMediaAction
    {
        protected string Titolo { get; set; } = string.Empty;
        protected string Autore { get; set; } = string.Empty;
        protected bool Status { get; set; } = false;

        protected DateTime? DataDiPrestito { get; set; } = null;

        protected DateTime? DataDiRestituzione { get; set; } = null;

        public MediaItem() { }

        public MediaItem(string titolo, string autore, bool status, DateTime datadiprestito, DateTime datadiconsegna)
        {
            Titolo = titolo;
            Autore = autore;
            Status = status;
            DataDiPrestito = datadiprestito;
            DataDiRestituzione = datadiconsegna;
        }

        public virtual void GetDescrizione()
        {
            Console.WriteLine($"Titolo: {Titolo,-15}\nAutore {Autore,-15}");
        }

        public void Prestito(DateTime datadiprestito )
        {
            if (Status) Console.WriteLine("Item non disponibile");
            else
            {
                this.DataDiPrestito = Convert.ToDateTime(Console.ReadLine());
                Status = true;
            }
        }

        public void Prestito()
        {
            DateTime datadiprestito = DateTime.Now;
            if (Status) Console.WriteLine("Item non disponibile");
            else
            {
                this.DataDiPrestito = Convert.ToDateTime(Console.ReadLine());
                Status = true;
            }
        }
        public void Restituzione (DateTime datadiprestito)
        {
            if (!Status) Console.WriteLine("Item non risulta prestato");
            else
            {
                this.DataDiRestituzione = Convert.ToDateTime(Console.ReadLine());
                Status = true;
            }
        }
        public void Restituzione()
        {
            DateTime datadiprestito = DateTime.Now;
            if (!Status) Console.WriteLine("Item non risulta prestato");
            else
            {
                this.DataDiRestituzione = Convert.ToDateTime(Console.ReadLine());
                Status = true;
            }
        }


    }
}
