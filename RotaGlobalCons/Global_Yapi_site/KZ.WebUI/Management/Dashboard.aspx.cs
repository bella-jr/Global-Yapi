using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class Dashboard : Page
    {
        private IArticleService _articleService;
        private ILoginLogService _loginLogService;
        private IUserService _userService;
        private ICookieService _cookieService;

        public Dashboard()
        {
            _articleService = InstanceFactory.GetInstance<IArticleService>();
            _loginLogService = InstanceFactory.GetInstance<ILoginLogService>();
            _userService = InstanceFactory.GetInstance<IUserService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
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
                var language = _cookieService.GetSessionAdmin();
                var loginLogs = _loginLogService.GetAll();

                ltlTotalArticleCount.Text = _articleService.GetAll(language.LanguageId).Count.ToString();
                ltlTotalAdmin.Text = _userService.GetCount((byte)TypeUser.Admin).ToString();

                rptLoginLogs.DataSource = loginLogs;
                rptLoginLogs.DataBind();

            }
            catch
            {
                return;
            }
        }
    }
}