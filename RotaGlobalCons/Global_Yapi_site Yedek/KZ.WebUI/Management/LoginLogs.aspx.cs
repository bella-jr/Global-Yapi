using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class LoginLogs : System.Web.UI.Page
    {
        private ILoginLogService _loginLogService;
        public LoginLogs()
        {
            _loginLogService = InstanceFactory.GetInstance<ILoginLogService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        private void LoadData()
        {
            var logs = _loginLogService.GetAll();

            rptLoginLogs.DataSource = logs;
            rptLoginLogs.DataBind();
        }
    }
}