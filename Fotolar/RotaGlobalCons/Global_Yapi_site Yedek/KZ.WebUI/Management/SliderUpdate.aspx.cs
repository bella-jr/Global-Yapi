using KZ.WebUI.Tool;
using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class SliderUpdate : System.Web.UI.Page
    {
        private ISliderService _sliderService;
        private IExpressToolService _expressToolService;

        public SliderUpdate()
        {
            _sliderService = InstanceFactory.GetInstance<ISliderService>();
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
                int id = Convert.ToInt32(RouteData.Values["sliderId"]); ;
                var slider = _sliderService.GetById(id);

                ltlImage.Text = "<img src=\"UploadFiles/Slider_Images/" + slider.Image + "\" width=\"150\" />";

                txtTitle.Text = slider.Title;
                txtTitle2.Text = slider.Title2;
                txtTitle3.Text = slider.Title3;
                //txtTitle4.Text = slider.Title4;
                //txtLink.Text = slider.Link;
                //txtButtonTitle.Text = slider.ButtonTitle;
                //txtLink2.Text = slider.Link2;
                //txtButtonTitle2.Text = slider.ButtonTitle2;
                cbStatus.Checked = slider.IsStatus;
                //cbIsExternal.Checked = slider.IsExternal;
                //ddlDirectionType.SelectedValue = slider.DirectionType;
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
                int id = Convert.ToInt32(RouteData.Values["sliderId"]); ;
                var slider = _sliderService.GetById(id);

                //if (cbIsVideo.Checked == false)
                //{
                //    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                //    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = "";
                //        uploadFolder = Server.MapPath("UploadFiles/Slider_Images/");
                //        flpImage.SaveAs(uploadFolder + flpImage.FileName);

                //        _expressToolService.FileDelete(uploadFolder, slider.Image);

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

                        _expressToolService.FileDelete(uploadFolder, slider.Image);

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
                //slider.Title4 = txtTitle4.Text.Trim();
                slider.IsStatus = cbStatus.Checked;
                //slider.IsVideo = cbIsVideo.Checked;
                //slider.IsExternal = cbIsExternal.Checked;
                //slider.Link = txtLink.Text.Trim();
                //slider.Link2 = txtLink2.Text.Trim();
                //slider.ButtonTitle = txtButtonTitle.Text.Trim();
                //slider.ButtonTitle2 = txtButtonTitle2.Text.Trim();
                //slider.DirectionType = ddlDirectionType.SelectedValue;

                _sliderService.Update(slider);

                LoadData();

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}