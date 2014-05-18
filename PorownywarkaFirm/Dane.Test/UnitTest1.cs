using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IDane;
using System.Linq;
using Logika;

namespace Dane.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Uzytkownik_w_bazie()
        {
            using (IZbiorDanych dane = new ZbiorDanych())
            {
                int ilosc_przed = dane.Uzytkownicy.Wczytaj().Count();

                dane.Uzytkownicy.Zapisz(new Uzytkownik());

                int ilosc_po = dane.Uzytkownicy.Wczytaj().Count();

                Assert.Equals(ilosc_przed + 1, ilosc_po);
            }
        }
    }
}
