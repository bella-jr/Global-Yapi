using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;
using System;
using System.Web;

namespace KZ.WebUI.Management
{
    public partial class PopupManagement : System.Web.UI.Page
    {
        private IPopupService _popupService;
        private ICookieService _cookieService;
        private IExpressToolService _expressToolService;


        public PopupManagement()
        {
            _popupService = InstanceFactory.GetInstance<IPopupService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
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
                var cookieAdmin = _cookieService.GetSessionAdmin();
                var popup = _popupService.GetById(cookieAdmin.LanguageId);

                ltlImage.Text = "<img src=\"UploadFiles/Popup_Images/" + popup.Image + "\" width=\"20%\" />";
                txtStartDate.Text = popup.StartDate.Date.ToString("yyyy-MM-dd");
                txtEndDate.Text = popup.EndDate.Date.ToString("yyyy-MM-dd");
                cbStatus.Checked = popup.IsStatus;
                cbDateLimited.Checked = popup.IsDateLimited;
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
                var cookieAdmin = _cookieService.GetSessionAdmin();
                var popup = _popupService.GetById(cookieAdmin.LanguageId);

                //Eğer yüklenecenek bir resim seçilmiş ise haber resmi yükleme işlemini gerçekleştirmektedir.
                if (flpImage.HasFile)
                {
                    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                    {
                        string uploadFolder = "";
                        uploadFolder = Server.MapPath("UploadFiles/Popup_Images/");
                        flpImage.SaveAs(uploadFolder + flpImage.FileName);

                        _expressToolService.FileDelete(uploadFolder, popup.Image);

                        popup.Image = _expressToolService.ImageUpload(uploadFolder, flpImage, "", "", "");
                    }
                    else
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }
                }

                popup.StartDate = Convert.ToDateTime(txtStartDate.Text.Trim());
                popup.EndDate = Convert.ToDateTime(txtEndDate.Text.Trim());
                popup.IsStatus = cbStatus.Checked;
                popup.IsDateLimited = cbDateLimited.Checked;

                _popupService.Update(popup);

                _expressToolService.SuccessAlertMessage(Page, HttpContext.Current.Request.RawUrl);
            }
            catch
            {
                _expressToolService.ErrorAlertMessage(Page, "#");
            }
        }
    }
}