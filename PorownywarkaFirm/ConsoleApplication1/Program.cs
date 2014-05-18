using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;
using Logika;
using IDane;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ZbiorDanych con = new ZbiorDanych();
            int a = 0;
            do
            {
                Console.WriteLine("1-dodaj");
                Console.WriteLine("2-update");
                Console.WriteLine("3-delete");
                Console.WriteLine("4-showAll");
                Console.WriteLine("5-exit");
                a=Convert.ToInt32( Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Adres adr= new Adres();
                        adr.id = Convert.ToInt32(Console.ReadLine());
                        adr.miasto = Console.ReadLine();
                        con.Zapisz(adr);
                        break;
                    case 2:
                        break;
                    case 4:
                        var lis= (con as IZbiorCzegos<Adres>).Wczytaj();
                        foreach (var i in lis) Console.WriteLine(i.miasto);
                        break;
                }

            }
            while (a != 5);
        }
    }
}
