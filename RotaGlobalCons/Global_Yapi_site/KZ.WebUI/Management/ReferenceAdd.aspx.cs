using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class ReferenceAdd : System.Web.UI.Page
    {
        private IReferenceService _referenceService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;
        private IFormControlService _formControlService;

        public ReferenceAdd()
        {
            _referenceService = InstanceFactory.GetInstance<IReferenceService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                var language = _cookieService.GetSessionAdmin();

                //Eğer yüklenecenek bir resim seçilmiş ise haber resmi yükleme işlemini gerçekleştirmektedir.
                if (flpImage.HasFile)
                {
                    string image = "Default.jpg";
                    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                    {
                        string uploadFolder = "";
                        uploadFolder = Server.MapPath("UploadFiles/Reference_Images/");
                        flpImage.SaveAs(uploadFolder + flpImage.FileName);
                        image = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getReferenceImageWidth(), StaticDataTool.getReferenceImageHeight(), "");
                    }
                    else
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }

                    //Reference bilgisi ekleme işlemini gerçekleştirmektedir.
                    _referenceService.Add(new Reference()
                    {
                        Title = txtTitle.Text.Trim(),
                        Image = image,
                        IsStatus = cbStatus.Checked,
                        SequenceNumber = 0,
                        TypeId = (byte)TypeReference.Referans, //Convert.ToByte(ddlTypeList.SelectedValue),
                        LanguageId = language.LanguageId,
                        CreationDate = DateTime.Now
                    });

                    txtTitle.Text = "";
                    cbStatus.Checked = false;
                    //ddlCategoryList.SelectedIndex = 0;

                    ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
                }
                else
                {
                    lblImageError.Text = "Lütfen fotoğraf seçimi yapınız.";
                    lblImageError.Visible = true;
                }
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}