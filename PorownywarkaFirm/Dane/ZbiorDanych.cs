using IDane;
using Logika;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public class ZbiorDanych : DbContext, IZbiorDanych
    {
        public ZbiorDanych()
            : base("Dane.ZbiorDanych")
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ZbiorDanych>());
        }

        public DbSet<Adres> DBAdresy { get; set; }
        public DbSet<Firma> DBFirmy { get; set; }
        public DbSet<Komentarz> DBKomentarze { get; set; }
        public DbSet<Kontakt> DBKontakty { get; set; }
        public DbSet<Ocena> DBOceny { get; set; }
        public DbSet<Uzytkownik> DBUzytkownicy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).Property(p => p.Name).IsRequired();
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(u => new { u.UserId, u.LoginProvider, u.ProviderKey });

            modelBuilder.Entity<Uzytkownik>().HasKey(n => n.Id);
            modelBuilder.Entity<Adres>().HasKey(n => n.id);
            modelBuilder.Entity<Kontakt>().HasKey(n => n.id);
            modelBuilder.Entity<Ocena>().HasKey(n => n.id);
            modelBuilder.Entity<Komentarz>().HasKey(n => n.id);
            modelBuilder.Entity<Firma>().HasKey(n => n.id);

            modelBuilder.Entity<Adres>().HasRequired(n => n.firma).WithOptional(n => n.adres);

            modelBuilder.Entity<Kontakt>().HasRequired(n => n.firma).WithOptional(n => n.kontakt);

            modelBuilder.Entity<Ocena>().HasRequired(n => n.uzytkownik).WithMany(n => n.oceny_firm);
            modelBuilder.Entity<Ocena>().HasRequired(n => n.firma).WithMany(n => n.oceny);
          
            modelBuilder.Entity<Uzytkownik>().HasOptional(n => n.firma).WithOptionalPrincipal(n => n.wlasciciel);
            modelBuilder.Entity<Uzytkownik>().HasMany(n => n.ocenione_komentarze).WithMany(n => n.uzytkownicy_korzy_ocenili);
            modelBuilder.Entity<Uzytkownik>().HasMany(n => n.wystawione_komentarze).WithRequired(n => n.wlasciciel).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Komentarz>().HasRequired(n => n.firma).WithMany(n => n.komentarze);
        }

        #region pomocnik
        public IZbiorAdresow Adresy { get { return this as IZbiorAdresow; } }
        public IZbiorFirm Firmy { get { return this as IZbiorFirm; } }
        public IZbiorKomentarzy Komentarze { get { return this as IZbiorKomentarzy; } }
        public IZbiorKontaktow Kontakty { get { return this as IZbiorKontaktow; } }
        public IZbiorOcen Oceny { get { return this as IZbiorOcen; } }
        public IZbiorUzytkownikow Uzytkownicy { get { return this as IZbiorUzytkownikow; } }
        #endregion

        #region DBContext
        public object DBContext
        {
            get { return this; }
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorAdresow
        public void Zapisz(Logika.Adres obj)
        {
            this.DBAdresy.Add(obj);
            this.SaveChanges();
        }

        public void Popraw(Logika.Adres obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Usun(Logika.Adres obj)
        {
            this.DBAdresy.Remove(obj);
            this.SaveChanges();
            //  this.Set<this.DBAdresy>().Remove(obj);
        }

        IEnumerable<Logika.Adres> IZbiorAdresow.Wczytaj()
        {
            var listaUzytkownikow = from p in this.DBAdresy select p;
            return listaUzytkownikow.AsEnumerable();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorFirm
        public void Zapisz(Logika.Firma obj)
        {
            this.DBFirmy.Add(obj);
            this.SaveChanges();
        }

        public void Popraw(Logika.Firma obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Usun(Logika.Firma obj)
        {
            this.DBFirmy.Remove(obj);
            this.SaveChanges();
        }

        IEnumerable<Logika.Firma> IZbiorFirm.Wczytaj()
        {
            var listaFirm = from p in this.DBFirmy select p;
            return listaFirm.AsEnumerable();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorKomentarzy

        public void Zapisz(Logika.Komentarz obj)
        {
            this.DBKomentarze.Add(obj);
            this.SaveChanges();
        }

        public void Popraw(Logika.Komentarz obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Usun(Logika.Komentarz obj)
        {
            this.DBKomentarze.Remove(obj);
            this.SaveChanges();
        }

        IEnumerable<Logika.Komentarz> IZbiorKomentarzy.Wczytaj()
        {
            var listaKomentarzy = from p in this.DBKomentarze select p;
            return listaKomentarzy.AsEnumerable();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorKontaktow
        public void Zapisz(Logika.Kontakt obj)
        {
            this.DBKontakty.Add(obj);
            this.SaveChanges();
        }

        public void Popraw(Logika.Kontakt obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Usun(Logika.Kontakt obj)
        {
            this.DBKontakty.Remove(obj);
            this.SaveChanges();
        }

        IEnumerable<Logika.Kontakt> IZbiorKontaktow.Wczytaj()
        {
            var listaKontaktow = from p in this.DBKontakty select p;
            return listaKontaktow.AsEnumerable();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->ZbiorOcen
        public void Zapisz(Logika.Ocena obj)
        {
            this.DBOceny.Add(obj);
            this.SaveChanges();
        }

        public void Popraw(Logika.Ocena obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Usun(Logika.Ocena obj)
        {
            this.DBOceny.Remove(obj);
            this.SaveChanges();
        }

        IEnumerable<Logika.Ocena> IZbiorOcen.Wczytaj()
        {
            var listaOcen = from p in this.DBOceny select p;
            return listaOcen.AsEnumerable();
        }
        #endregion

        // TODO implement
        #region IZbiorDanych->Uzytkownikow
        public void Zapisz(Logika.Uzytkownik obj)
        {
            this.DBUzytkownicy.Add(obj);
            this.SaveChanges();
        }

        public void Popraw(Logika.Uzytkownik obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void Usun(Logika.Uzytkownik obj)
        {
            this.DBUzytkownicy.Remove(obj);
            this.SaveChanges();
        }

        IEnumerable<Logika.Uzytkownik> IZbiorUzytkownikow.Wczytaj()
        {
            var listaUzytkownikow = from p in this.DBUzytkownicy select p;
            return listaUzytkownikow.AsEnumerable();
        }
        #endregion
    }
}
