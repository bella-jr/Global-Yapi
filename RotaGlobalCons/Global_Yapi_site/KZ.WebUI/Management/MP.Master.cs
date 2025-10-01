using System;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System.Web;

namespace KZ.WebUI.Management
{
    public partial class MP : System.Web.UI.MasterPage
    {
        private ICookieService _cookieService;

        public MP()
        {
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetValue();
        }

        private void GetValue()
        {
            try
            {
                var sessionAdmin = _cookieService.GetSessionAdmin();

                if (sessionAdmin == null)
                    Response.Redirect("/Management", false);


                hfUserId.Value = "Profile-" + sessionAdmin.Id;
                ltlNameSurname.Text = HttpContext.Current.Server.UrlDecode(sessionAdmin.NameSurname);

                if (sessionAdmin.LanguageId == (byte)LanguageType.Turkce)
                    ltlLanguageName.Text = "Türkçe";

                if (sessionAdmin.LanguageId == (byte)LanguageType.Ingilizce)
                    ltlLanguageName.Text = "İngilizce";
            }
            catch
            {
                Response.Redirect("/Management");
            }
        }

        protected void lnkLogOut_OnClick(object sender, EventArgs e)
        {
            _cookieService.Delete("adminCookie");
            Response.Redirect("/Management");
        }
    }
}