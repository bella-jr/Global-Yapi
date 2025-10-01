using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Core;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class Default : System.Web.UI.Page
    {
        private IUserService _userService;
        private ILanguageService _languageService;
        private ILoginLogService _loginLogService;
        private ICookieService _cookieService;
        private IFormControlService _formControlService;
        Tools tool = new Tools();


        public Default()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _languageService = InstanceFactory.GetInstance<ILanguageService>();
            _loginLogService = InstanceFactory.GetInstance<ILoginLogService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
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
                var sessionAdmin = _cookieService.GetSessionAdmin();
                var language = _languageService.GetAll();

                if (sessionAdmin != null)
                    Response.Redirect("Dashboard");

                _formControlService.GenerateDropdownList(language, ddlLanguage);
            }
            catch
            {
                return;
            }
        }

        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                var user = _userService.GetLoginPanel(txtMail.Text, txtPassword.Text);

                if (user != null)
                {
                    _cookieService.SetSessionAdmin(new CookieAdmin()
                    {
                        Id = user.Id,
                        NameSurname = user.Name + " " + user.Surname,
                        LanguageId = /*(byte)LanguageType.Turkce,*/ Convert.ToByte(ddlLanguage.SelectedValue),
                    }, "adminCookie");

                    _loginLogService.Add(new LoginLog()
                    {
                        Ip = tool.GetIpAddress(),
                        CreationDate = DateTime.Now,
                        UserId = user.Id
                    });

                    Response.Redirect("Dashboard", false);
                }
                else
                {
                    lblMessage.Text = "Mail adresi yada şifre hata vermektedir.";
                    return;
                }
            }
            catch
            {
                lblMessage.Text = "İşleminiz sırasında sistem hatası hata meyda geldi. Lütfen daha sonra tekrar deneyiniz.";
            }
        }
    }
}