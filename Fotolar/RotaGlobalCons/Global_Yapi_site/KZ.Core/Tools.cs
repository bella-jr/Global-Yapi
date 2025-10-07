using System;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace KZ.Core
{
    public class Tools
    {
        //Parametre olarak gönderilen değeri şifreleyip geri döndürme işlemi gerçekleştirmektedir.
        public string Encrypt(string data)
        {
            UTF8Encoding encode = new UTF8Encoding();
            byte[] buffer = encode.GetBytes(data);
            SHA384 sha = new SHA384Managed();
            buffer = sha.ComputeHash(buffer);
            return Convert.ToBase64String(buffer);
        }

        //Parametre olarak gönderilen değeri replace edip geri döndürme işlemini gerçekleştirmektedir.
        public static string UrlSeo(string Text)
        {
            string value = Text;
            value = value.Replace("'", "");
            value = value.Replace(" ", "-");
            value = value.Replace("<", "");
            value = value.Replace(">", "");
            value = value.Replace("&", "");
            value = value.Replace("[", "");
            value = value.Replace("]", "");
            value = value.Replace("ı", "i");
            value = value.Replace("ö", "o");
            value = value.Replace("ü", "u");
            value = value.Replace("ş", "s");
            value = value.Replace("ç", "c");
            value = value.Replace("ğ", "g");
            value = value.Replace("İ", "i");
            value = value.Replace("I", "i");
            value = value.Replace("Ö", "o");
            value = value.Replace("Ü", "u");
            value = value.Replace("Ş", "s");
            value = value.Replace("Ç", "c");
            value = value.Replace("Ğ", "g");
            value = value.Replace("!", "");
            value = value.Replace(".", "");
            value = value.Replace("#", "");
            value = value.Replace("?", "");
            value = value.Replace(".", "");
            value = value.Replace("/", "");
            value = value.Replace(":", "");
            value = value.Replace(")", "");
            value = value.Replace("(", "");
            value = value.Replace("+", "");
            value = value.Replace("*", "");
            value = value.Replace("%", "");
            value = value.Replace("&", "");
            value = value.Replace("[", "");
            value = value.Replace("]", "");
            value = value.Replace("{", "");
            value = value.Replace("}", "");
            value = value.Replace("}", "");
            value = value.Replace("$", "");
            value = value.Replace("=", "");
            value = value.Replace("~", "");

            return value.ToLower();
        }

        public void MailSend(string Server, string Account, string Password, bool SSL, int Port, string Address, string Title, string Subject, string Message, string SendMail)
        {
            SmtpClient sc_mail = new SmtpClient();
            sc_mail.Host = Server;
            sc_mail.Credentials = new NetworkCredential(Account, Password);
            sc_mail.EnableSsl = SSL;
            sc_mail.Port = Port;
            MailMessage mesaj = new MailMessage();
            MailAddress fromAddress = new MailAddress(Address, Title);
            mesaj.From = fromAddress;
            mesaj.To.Add(SendMail);
            mesaj.Subject = Subject;
            mesaj.IsBodyHtml = true;
            mesaj.Body = Message;
            sc_mail.Send(mesaj);
        }

        public void MailSend2(string Server, string Account, string Password, bool SSL, int Port, string Address, string Title, string Subject, string Message, string SendMail, FileUpload flp)
        {
            SmtpClient sc_mail = new SmtpClient();
            sc_mail.Host = Server;
            sc_mail.Credentials = new NetworkCredential(Account, Password);
            sc_mail.EnableSsl = SSL;
            sc_mail.Port = Port;
            MailMessage mesaj = new MailMessage();
            MailAddress fromAddress = new MailAddress(Address, Title);
            mesaj.From = fromAddress;
            mesaj.To.Add(SendMail);
            mesaj.Subject = Subject;
            mesaj.IsBodyHtml = true;
            mesaj.Body = Message;

            if (flp.HasFile)
            {
                Attachment a = new Attachment(flp.FileContent, flp.FileName);
                mesaj.Attachments.Add(a);
            }

            sc_mail.Send(mesaj);
        }

        //Parametre olarak gönderilen değer içindeki tüm html etiketlerini temizleme işlemini gerçekleştirmektedir.
        public static string ClearHtml(string source)
        {
            return Regex.Replace(source, @"<[^>]+>|&nbsp;", "");
        }

        //IP adresi bilgisi elde etme işlemini gerçekleştirmektedir.
        public string GetIpAddress()
        {
            try
            {
                string ip = "";
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress addr in localIPs)
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                        ip = addr.ToString();

                return ip;
            }
            catch
            {
                return "";
            }
        }
    }
}
