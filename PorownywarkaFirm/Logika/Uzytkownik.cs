using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logika
{
    public class Uzytkownik : IdentityUser
    {
        public virtual Firma firma { get; set; }

        public virtual ICollection<Ocena> oceny_firm { get; set; }

        public virtual ICollection<Komentarz> wystawione_komentarze { get; set; }

        public virtual ICollection<Komentarz> ocenione_komentarze { get; set; }
    }
}
