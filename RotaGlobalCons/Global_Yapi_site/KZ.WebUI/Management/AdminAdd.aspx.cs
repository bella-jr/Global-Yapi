using System;
using System.Configuration;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class AdminAdd : System.Web.UI.Page
    {
        private IUserService _userService;
        private IExpressToolService _expressToolService;
        private IMailService _mailService;

        public AdminAdd()
        {
            _userService = InstanceFactory.GetInstance<IUserService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _mailService = WebUIInstanceFactory.GetInstance<IMailService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Aynı mail adresi var mı ? Kontrolü gerçekleştirilmektedir. Eğer yok ise true değeri döndürmektedir.
                if (_userService.MailControl(txtMail.Text))
                {
                    lblMailMessage.Visible = false;

                    //Admin ekleme işlemini gerçekleştirmektedir.
                    var user = new User()
                    {
                        Name = txtName.Text,
                        Surname = txtSurname.Text,
                        Mail = txtMail.Text,
                        IsMailVerify = true,
                        IsStatus = cbStatus.Checked,
                        IsView = true,
                        Password = txtPasswordConfirm.Text,
                        TypeId = (byte)TypeUser.Admin,
                        CreationDate = DateTime.Now
                    };
                    _userService.Add(user);

                    if (cbMailNotification.Checked)
                        _mailService.AddNewAdminInformation_MailSend(user, _expressToolService, txtPasswordConfirm.Text.Trim(), ConfigurationManager.AppSettings["SiteAddress"] + "/Management");

                    _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);

                    ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
                }
                else
                {
                    lblMailMessage.Text = "Bu mail adresi kullanılmaktadır";
                    lblMailMessage.Visible = true;
                }
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}