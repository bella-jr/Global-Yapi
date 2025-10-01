using System;
using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class AdminUpdate : System.Web.UI.Page
    {
        private IUserService _userService;
        private IExpressToolService _expressToolService;

        public AdminUpdate()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
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
                int id = Convert.ToInt32(RouteData.Values["userId"]);
                var user = _userService.GetById(id);

                txtName.Text = user.Name;
                txtSurname.Text = user.Surname;
                txtMail.Text = user.Mail;
                cbStatus.Checked = user.IsStatus;
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
                int id = Convert.ToInt32(RouteData.Values["userId"]);
                var user = _userService.GetById(id);

                //Yeni şifre var mı kontrolünü gerçekleştirmektedir.
                if (!String.IsNullOrEmpty(txtPasswordConfirm.Text.Trim()))
                    user.Password = txtPasswordConfirm.Text.Trim();

                //Kullanıcı bilgilerini güncelleme işlemini gerçekleştirmektedir.
                user.Name = txtName.Text.Trim();
                user.Surname = txtSurname.Text.Trim();
                user.Mail = txtMail.Text.Trim();
                user.Password = user.Password;
                user.IsStatus = cbStatus.Checked;

                _userService.Update(user);

                _expressToolService.SuccessAlertMessage(Page, HttpContext.Current.Request.RawUrl);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");

            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}