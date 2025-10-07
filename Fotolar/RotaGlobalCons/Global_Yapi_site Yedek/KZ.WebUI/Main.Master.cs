using System;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
namespace KZ.WebUI
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private IMenuToolService _menuToolService;
        private ISessionService _sessionService;

        public Main()
        {
            _menuToolService = WebUIInstanceFactory.GetInstance<IMenuToolService>();
            _sessionService = WebUIInstanceFactory.GetInstance<ISessionService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();

        }

        private void LoadData()
        {
            try
            {
                var language = _sessionService.GetSessionLanguage();


                string headerMenus = _menuToolService.Header_GenerateMenu(language.LanguageId);
                string footerMenus = _menuToolService.FooterMenuList(language.LanguageId);
                string footerMenus2 = _menuToolService.FooterMenuList2(language.LanguageId);

                ltlHeaderMenuList.Text = headerMenus;
                ltlFooterMenuList.Text = footerMenus;
                ltlFooterMenuList2.Text = footerMenus2;
            }
            catch
            {
                return;
            }
        }
    }
}