using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class ReferenceUpdate : System.Web.UI.Page
    {
        private IReferenceService _referenceService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;
        private IFormControlService _formControlService;

        public ReferenceUpdate()
        {
            _referenceService = InstanceFactory.GetInstance<IReferenceService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
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
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var language = _cookieService.GetSessionAdmin();

                var reference = _referenceService.GetById(id);
                ltlImage.Text = "<img src=\"UploadFiles/Reference_Images/" + reference.Image + "\" width=\"150\" />";

                txtTitle.Text = reference.Title;
                cbStatus.Checked = reference.IsStatus;
                
                //ddlTypeList.SelectedValue = reference.TypeId.ToString();
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
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var reference = _referenceService.GetById(id);

                //Eğer yüklenecenek bir resim seçilmiş ise haber resmi yükleme işlemini gerçekleştirmektedir.
                if (flpImage.HasFile)
                {
                    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                    {
                        string uploadFolder = "";
                        uploadFolder = Server.MapPath("UploadFiles/Reference_Images/");
                        flpImage.SaveAs(uploadFolder + flpImage.FileName);

                        _expressToolService.FileDelete(uploadFolder, reference.Image);

                        reference.Image = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getReferenceImageWidth(), StaticDataTool.getReferenceImageHeight(), "");
                    }
                    else
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }
                }

                reference.Title = txtTitle.Text.Trim();
                reference.IsStatus = cbStatus.Checked;
                reference.TypeId = (byte)TypeReference.Referans; //Convert.ToByte(ddlTypeList.SelectedValue);

                _referenceService.Update(reference);

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