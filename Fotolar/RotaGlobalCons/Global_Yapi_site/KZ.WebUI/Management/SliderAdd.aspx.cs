using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class SliderAdd : System.Web.UI.Page
    {
        private ISliderService _sliderService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public SliderAdd()
        {
            _sliderService = InstanceFactory.GetInstance<ISliderService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                var slider = new Slider();


                string image = "Default.jpg";
                //if (cbIsVideo.Checked == false)
                //{
                //    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                //    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = "";
                //        uploadFolder = Server.MapPath("UploadFiles/Slider_Images/");
                //        flpImage.SaveAs(uploadFolder + flpImage.FileName);
                //        slider.Image = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getSliderImageWidth(), StaticDataTool.getSliderImageHeight(), "");
                //    }
                //    else
                //    {
                //        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                //        lblImageError.Visible = true;
                //        return;
                //    }
                //}
                //else
                //{
                int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                {
                    string uploadFolder = "";
                    uploadFolder = Server.MapPath("UploadFiles/Slider_Images/");
                    flpImage.SaveAs(uploadFolder + flpImage.FileName);

                    slider.Image = _expressToolService.FileUpload(uploadFolder, flpImage);
                }
                else
                {
                    lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                    lblImageError.Visible = true;
                    return;
                }
                //}


                slider.Title = txtTitle.Text.Trim();
                slider.Title2 = txtTitle2.Text.Trim();
                slider.Title3 = txtTitle3.Text.Trim();
                slider.Title4 = "-"; //txtTitle4.Text.Trim();
                //slider.Link = txtLink.Text.Trim();
                //slider.Link2 = txtLink2.Text.Trim();
                //slider.ButtonTitle = txtButtonTitle.Text.Trim();
                //slider.ButtonTitle2 = txtButtonTitle2.Text.Trim();
                slider.IsStatus = cbStatus.Checked;
                slider.IsExternal = false; //cbIsExternal.Checked,
                slider.IsVideo = false; //cbIsVideo.Checked;
                slider.SequenceNumber = 0;
                slider.LanguageId = _cookieService.GetSessionAdmin().LanguageId;
                slider.DirectionType = "-"; //ddlDirectionType.SelectedItem.Text,
                slider.CreationDate = DateTime.Now;

                _sliderService.Add(slider);

                _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}