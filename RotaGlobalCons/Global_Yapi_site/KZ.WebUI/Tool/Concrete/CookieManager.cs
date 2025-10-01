using KZ.WebUI.Tool.Abstract;
using System;
using System.Web;
using KZ.WebUI.Models;

namespace KZ.WebUI.Tool.Concrete
{
    public class CookieManager : ICookieService
    {
        public CookieAdmin GetSessionAdmin()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["adminCookie"];

            if (cookie == null)
                return null;

            return new CookieAdmin()
            {
                Id = Convert.ToInt32(cookie.Values[0]),
                NameSurname = cookie.Values[1],
                LanguageId = Convert.ToByte(cookie.Values[2])
            };
        }

        public void SetSessionAdmin(CookieAdmin cookieAdmin, string cookieName)
        {
            HttpContext.Current.Response.Cookies.Clear();

            HttpCookie cerez = new HttpCookie(cookieName);
            cerez["Id"] = cookieAdmin.Id.ToString();
            cerez["NameSurname"] = HttpContext.Current.Server.UrlEncode(cookieAdmin.NameSurname);
            cerez["LanguageId"] = cookieAdmin.LanguageId.ToString();

            cerez.Expires = DateTime.Now.AddDays(1);

            HttpContext.Current.Response.Cookies.Add(cerez);
        }

        public void Delete(string cookieName)
        {
            HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddDays(-1);
        }
    }
}