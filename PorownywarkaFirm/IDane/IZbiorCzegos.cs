using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDane
{
    public interface IZbiorCzegos<T>
    {
        void Zapisz(T obj);

        void Popraw(T obj);
        
        void Usun(T obj);
        
        IEnumerable<T> Wczytaj();
    }
}
