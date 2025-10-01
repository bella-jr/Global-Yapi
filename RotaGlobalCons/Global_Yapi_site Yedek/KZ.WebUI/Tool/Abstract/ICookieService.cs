using KZ.WebUI.Models;

namespace KZ.WebUI.Tool.Abstract
{
    public interface ICookieService
    {
        CookieAdmin GetSessionAdmin();

        void SetSessionAdmin(CookieAdmin cookieAdmin, string cookieName);

        void Delete(string cookieName);
    }
}
