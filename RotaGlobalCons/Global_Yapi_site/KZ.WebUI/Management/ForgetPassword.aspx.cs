using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        private IUserService _userService;
        Random rnd = new Random();
        private IExpressToolService _expressToolService;
        private ICookieService _cookieservice;
        private IMailService _mailService;

        public ForgetPassword()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieservice = WebUIInstanceFactory.GetInstance<ICookieService>();
            _mailService = WebUIInstanceFactory.GetInstance<IMailService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                if (_cookieservice.GetSessionAdmin() != null)
                    Response.Redirect("Dashboard");
        }

        protected void btnSendPassword_OnClick(object sender, EventArgs e)
        {
            try
            {
                var user = _userService.GetForgetPassword(txtMail.Text, (byte)TypeUser.Admin);
                if (user != null)
                {
                    string password = rnd.Next(10000, 100000).ToString();

                    bool result = _mailService.ForgetPassword_MailSend(user, _expressToolService, (byte)LanguageType.Turkce, password, true, "Şifremi Unuttum ?", StaticDataTool.getSiteAddress() + "/management");
                    if (result)
                    {
                        user.Password = password;
                        _userService.Update(user);
                        lblMessage.Text = "Yeni şifreniz mail hesabınıza gönderilmiştir. Lütfen spam/gereksiz klasörünü kontrol etmeyi unutmayınız";
                    }
                    else
                    {
                        lblMessage.Text =
                            "Şifre sıfırlama talebiniz sırasında hata meydana gelmiştir. Lütfen daha sonra tekrar deneyiniz.";
                        return;
                    }
                }
                else
                {
                    lblMessage.Text = "Sistemde kayıtlı böyle bir mail adresi bulunmamaktadır.";
                    return;
                }
            }
            catch
            {
                lblMessage.Text =
                    "Şifre sıfırlama talebiniz sırasında hata meydana gelmiştir. Lütfen daha sonra tekrar deneyiniz.";
                return;
            }
        }
    }
}