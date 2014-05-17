using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logika
{
    public class Firma
    {
        public int id { get; set; }

        public string nazwa { get; set; }

        public virtual Adres adres { get; set; }

        public virtual Kontakt kontakt { get; set; }

        public virtual Uzytkownik wlasciciel { get; set; }

        public virtual ICollection<Ocena> oceny { get; set; }

        public virtual ICollection<Komentarz> komentarze { get; set; }
    }
}
