using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal interface IMediaAction
    {
        void Prestito(DateTime DataDiPrestito);
        void Prestito();
        void Restituzione(DateTime DataDiRestituzione);
        void Restituzione();

    }
}
