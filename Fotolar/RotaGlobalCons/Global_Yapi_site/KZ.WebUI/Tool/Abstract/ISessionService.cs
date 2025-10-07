using KZ.WebUI.Models;

namespace KZ.WebUI.Tool.Abstract
{
    public interface ISessionService
    {
        void SetSessionUser(SessionUser sessionUser);

        void SetAdminSessionUser(SessionAdmin sessionAdmin);

        SessionAdmin GetSessionAdmin();

        SessionUser GetSessionUser();

        SessionLanguage GetSessionLanguage();

        void SetSessionLanguage(SessionLanguage sessionLanguage);

        void SessionRemove(string sessionName);
    }
}
