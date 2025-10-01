using System.Web;
using KZ.Entity.Enums;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Tool.Concrete
{
    internal class SessionManager : ISessionService
    {
        public void SetSessionUser(SessionUser sessionUser)
        {
            HttpContext.Current.Session["SessionUser"] = sessionUser;
        }

        public void SetAdminSessionUser(SessionAdmin sessionAdmin)
        {
            HttpContext.Current.Session["SessionAdmin"] = sessionAdmin;
        }

        public SessionAdmin GetSessionAdmin()
        {
            return HttpContext.Current.Session["SessionAdmin"] as SessionAdmin;
        }

        public SessionUser GetSessionUser()
        {
            return HttpContext.Current.Session["SessionUser"] as SessionUser;
        }

        public SessionLanguage GetSessionLanguage()
        {
            string folder = HttpContext.Current.Request.Url.AbsoluteUri;

            if (HttpContext.Current.Session["Language"] == null)
                SetSessionLanguage(new SessionLanguage() { LanguageId = (byte)LanguageType.Turkce, Culture = "tr-TR" });

            string url = StaticDataTool.getSiteAddress();

            //TODO: Url'den ingilizce ve türkçe olarak gelirse para birimini ona göre ayarlayacak.
            if (folder.Contains(url + "/tr"))
            {
                SetSessionLanguage(new SessionLanguage() { LanguageId = (byte)LanguageType.Turkce, Culture = "tr-TR" });
            }

            if (folder.Contains(url + "/en"))
            {
                SetSessionLanguage(new SessionLanguage() { LanguageId = (byte)LanguageType.Ingilizce, Culture = "en-US" });
            }

            if (folder.Contains(url + "/hu"))
            {
                SetSessionLanguage(new SessionLanguage() { LanguageId = (byte)LanguageType.Macarca, Culture = "hu-HU" });
            }

            return HttpContext.Current.Session["Language"] as SessionLanguage;
        }

        public void SetSessionLanguage(SessionLanguage sessionLanguage)
        {
            HttpContext.Current.Session["Language"] = sessionLanguage;
        }

        public void SessionRemove(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }
    }
}