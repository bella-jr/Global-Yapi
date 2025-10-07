using System;
using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class GeneralSettingUpdate : System.Web.UI.Page
    {
        private IGeneralSettingService _generalSettingService;
        private IExpressToolService _expressToolService;

        public GeneralSettingUpdate()
        {
            _generalSettingService = InstanceFactory.GetInstance<IGeneralSettingService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        //Genel ayar bilgilerini listeleme işlemini gerçekleştirmektedir.
        private void LoadData()
        {
            try
            {
                var setting = _generalSettingService.GetAll();

                //ltlLogo.Text = "<img src=\"UploadFiles/Logo/" + setting.Logo + "\" />";
                txtAddress.Text = setting.Address;
                //txtAddress2.Text = setting.Address2;
                txtPhone.Text = setting.Phone;
                //txtPhone2.Text = setting.Phone2;
                //txtPhone3.Text = setting.Phone3;
                //txtPhone4.Text = setting.Phone4;
                //txtFax.Text = setting.Fax;
                txtMail.Text = setting.Mail;
                //txtMail2.Text = setting.Mail2;
                txtWhatsapp.Text = setting.Whatsapp;
                //txtWhatsapp2.Text = setting.Whatsapp2;
                txtFacebook.Text = setting.Facebook;
                txtTwitter.Text = setting.Twitter;
                //txtLinkedin.Text = setting.Linkedin;
                //txtGooglePlus.Text = setting.Google_Plus;
                txtInstagram.Text = setting.Instagram;
                //txtYoutube.Text = setting.Youtube;
                //txtPinterest.Text = setting.Pinterest;
                ckeHtmlCode.Text = setting.Code;
                ckeMaps.Text = setting.Maps;
                txtSeoTitle.Text = setting.SeoTitle;
                txtSeoDescription.Text = setting.SeoDescription;
                //txtSeoKeyword.Text = setting.SeoKeyword;
                //chkPaymentDescription.Text = setting.PaymentDescription;
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
                var setting = _generalSettingService.GetAll();

                //Eğer yüklenecenek bir logo seçilmiş ise yükleme işlemini gerçekleştirmektedir.
                //if (flpLogo.HasFile)
                //{
                //    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Logo/"), setting.Logo);

                //    int fileSize = Convert.ToInt32(flpLogo.PostedFile.ContentLength);
                //    if (fileSize <= 5242880) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = Server.MapPath("UploadFiles/Logo/");

                //        flpLogo.SaveAs(uploadFolder + flpLogo.FileName);
                //        string UploadImageName = _expressToolService.ImageUpload(uploadFolder, flpLogo, "200", "95", "", "png");
                //        setting.Logo = UploadImageName;
                //    }
                //    else
                //    {
                //        ltlErrorMessage.Text = "Maksimum 5 mb büyüklüğünde dosya yüklebilirsiniz.";
                //        return;
                //    }
                //}
                //////////////////////////////////////////////////////////////////////////////////////////////////////

                //Genel ayar bilgilerini güncelleme işlemini gerçekleştirmektedir.

                setting.Address = txtAddress.Text.Trim();
                //setting.Address2 = txtAddress2.Text.Trim();
                setting.Phone = txtPhone.Text.Trim();
                //setting.Phone2 = txtPhone2.Text.Trim();
                //setting.Phone3 = txtPhone3.Text.Trim();
                //setting.Phone4 = txtPhone4.Text.Trim();
                //setting.Fax = txtFax.Text.Trim();
                setting.Mail = txtMail.Text.Trim();
                //setting.Mail2 = txtMail2.Text.Trim();
                setting.Whatsapp = txtWhatsapp.Text.Trim();
                //setting.Whatsapp2 = txtWhatsapp2.Text.Trim();
                setting.Facebook = txtFacebook.Text.Trim();
                setting.Twitter = txtTwitter.Text.Trim();
                //setting.Linkedin = txtLinkedin.Text.Trim();
                //setting.Google_Plus = txtGooglePlus.Text.Trim();
                setting.Instagram = txtInstagram.Text.Trim();
                //setting.Youtube = txtYoutube.Text.Trim();
                //setting.Pinterest = txtPinterest.Text.Trim();
                setting.Code = ckeHtmlCode.Text.Trim();
                setting.Maps = ckeMaps.Text.Trim();
                setting.SeoTitle = txtSeoTitle.Text;
                setting.SeoDescription = txtSeoDescription.Text;
                //setting.SeoKeyword = txtSeoKeyword.Text;
                //setting.PaymentDescription = chkPaymentDescription.Text;

                HttpContext.Current.Application["generalSettingData"] = setting;

                _generalSettingService.Update(setting);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}