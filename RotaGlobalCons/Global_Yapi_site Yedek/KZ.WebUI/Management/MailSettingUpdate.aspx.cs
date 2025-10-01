using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class MailSettingUpdate : System.Web.UI.Page
    {
        private IMailSettingService _mailSettingService;
        private IExpressToolService _expressToolService;

        public MailSettingUpdate()
        {
            _mailSettingService = InstanceFactory.GetInstance<IMailSettingService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        //Mail ayarları bilgilerini listeleme işlemini gerçekleştirmektedir.
        private void LoadData()
        {
            var setting = _mailSettingService.GetAll_Panel();

            txtServer.Text = setting.Server;
            txtPort.Text = setting.Port.ToString();
            cbSSL.Checked = setting.Ssl;
            txtMail.Text = setting.Account;
            txtPassword.Text = setting.Password;
            txtTitle.Text = setting.Title;
            txtContactMail.Text = setting.ContactMail;
            //txtOrderMail.Text = setting.OrderMail;
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Mail ayarları bilgilerini güncelleme işlemini gerçekleştirmektedir.
                var setting = new MailSetting()
                {
                    Id = 1,
                    Server = txtServer.Text.Trim(),
                    Port = Convert.ToInt32(txtPort.Text.Trim()),
                    Ssl = cbSSL.Checked,
                    Account = txtMail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Address = txtMail.Text.Trim(),
                    Title = txtTitle.Text.Trim(),
                    ContactMail = txtContactMail.Text.Trim(),
                    OrderMail = "-" //txtOrderMail.Text.Trim()
                };

                _mailSettingService.Update(setting);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}