using IDane;
using IKomunikacja;
using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailMesages
{
    public class MailMessages : IMessageBus
    {
        public IZbiorDanych dane { get; set; }
        public MailMessages(IZbiorDanych dane)
        {
            this.dane = dane;
        }
        public async static Task<bool> WyslijMail(string subject, string to, string message)
        {
            return await Task.Run(new Func<bool>(() =>
            {
                try
                {
                    SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                    var mail = new MailMessage();
                    mail.From = new MailAddress("toptenfirma.toptenfirma@o2.pl");
                    mail.To.Add(to);
                    mail.Subject = subject;
                    mail.IsBodyHtml = false;
                    mail.Body = message;
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(@"toptenfirma.toptenfirma@o2.pl", @"sadsadsa234rwegdg23423ewasg43t23rqwaffm566t3sevw4t4t#R#TGR$@wegdg23423ewasg43t23rqwaffmESfvsfs");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }));
        }

        public void WyslijWiadomoscDoWszystkich(string wiadomosc)
        {
            foreach (var uzytkownik in dane.Uzytkownicy.Wczytaj())
            {
                WyslijWiadomoscDoUzytkownika(wiadomosc, uzytkownik);
            }
        }

        public void WyslijWiadomoscDoUzytkownika(string wiadomosc, Uzytkownik uzytkownik)
        {
            if (uzytkownik.mail != null && uzytkownik.mail != string.Empty)
            {
                WyslijMail("Wiadomosc Top10Firma", uzytkownik.mail, wiadomosc);
            }
        }

        public void FirmaZostalaUtworzona(Logika.Firma firma)
        {
            foreach (var uzytkownik in dane.Uzytkownicy.Wczytaj())
            {
                if (uzytkownik.mail != null && uzytkownik.mail != string.Empty)
                {
                    WyslijMail("Nowa Firma w servisie Top10Firma", uzytkownik.mail, "W servisie pojawiła się nowa firma " + firma.nazwa + "!");
                }
            }
        }

        public void TwojFirmaZostalaOceniona(Uzytkownik uzytkownik)
        {
            if (uzytkownik.mail != null && uzytkownik.mail != string.Empty && uzytkownik.firma != null)
            {
                WyslijMail("Nowa ocena twojej firmy w servisie Top10Firma", uzytkownik.mail, "Firma " + uzytkownik.firma.nazwa + " zyskała nową ocene.");
            }
        }



        public void TwojaFirmaZostalaZakomentowana(Uzytkownik uzytkownik, string komentarz)
        {
            if (uzytkownik.mail != null && uzytkownik.mail != string.Empty && uzytkownik.firma != null)
            {
                WyslijMail("komentarz w servisie Top10Firma", uzytkownik.mail, komentarz);
            }
        }
    }
}
