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
        public virtual Firma firma {get; set;}
    }
}
