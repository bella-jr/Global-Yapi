using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class Profile : System.Web.UI.Page
    {
        private IUserService _userService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public Profile()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
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
                var user = _userService.GetById(_cookieService.GetSessionAdmin().Id);

                txtName.Text = user.Name;
                txtSurname.Text = user.Surname;
                txtMail.Text = user.Mail;
            }
            catch
            {
                return;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                var user = _userService.GetById(_cookieService.GetSessionAdmin().Id);

                //Yeni şifre var mı kontrolünü gerçekleştirmektedir.
                if (!String.IsNullOrEmpty(txtPasswordConfirm.Text.Trim()))
                    user.Password = txtPasswordConfirm.Text.Trim();

                //Kullanıcı bilgilerini güncelleme işlemini gerçekleştirmektedir.
                user.Name = txtName.Text.Trim();
                user.Surname = txtSurname.Text.Trim();
                user.Mail = txtMail.Text.Trim();
                user.Password = user.Password;

                _userService.Update(user);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}