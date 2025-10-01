using System;
using System.IO;
using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class BlogAdd : System.Web.UI.Page
    {
        private IGalleryService _galleryService;
        private IFormControlService _formControlService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;
        private ICookieService _cookieService;
        private IBlogService _blogService;

        public BlogAdd()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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
                var galleries = _galleryService.GetAll_UIControl();

                _ckEditorService.StandartAyarlar(ckeDescription, "/Management/UploadFiles/Editor_Files/");
                _formControlService.GenerateDropdownList(galleries, ddlGallery);

                
            }
            catch
            {
                return;
            }
        }

        //Otomatik olarak yazı başlığını replace edip link haline getirmektedir.
        //protected void txtTitle_OnTextChanged(object sender, EventArgs e)
        //{
        //    txtLink.Text = Tools.UrlSeo(txtTitle.Text.Trim());
        //    txtLink.Enabled = true;
        //}

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                //Eğer yüklenecenek bir resim seçilmiş ise haber resmi yükleme işlemini gerçekleştirmektedir.
                //if (flpImage.HasFile)
                //{
                //    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                //    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = "", UploadImageName = "";
                //        uploadFolder = Server.MapPath("UploadFiles/Blog_Images/");
                //        flpImage.SaveAs(uploadFolder + flpImage.FileName);
                //        UploadImageName = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getBlogImageWidth(), StaticDataTool.getBlogImageHeight(), "");
                //        image = UploadImageName;
                //    }
                //    else
                //    {
                //        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                //        lblImageError.Visible = true;
                //        return;
                //    }
                //}


                string image = "Default.jpg", folder = "", guid = "";
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];

                    if (userPostedFile.ContentLength == 0)
                        break;

                    if (userPostedFile.ContentLength > StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum)
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yükleyebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }

                    folder = Server.MapPath("UploadFiles/Blog_Images/");
                    userPostedFile.SaveAs(folder + Path.GetFileName(userPostedFile.FileName));

                    guid = Guid.NewGuid().ToString();

                    _expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getBlogImageSmallWidth(), StaticDataTool.getBlogImageSmallHeight(), guid, "Small_");
                    //_expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getBlogImageWidth(), StaticDataTool.getBlogImageHeight(), guid, "Big_");

                    image = guid + ".jpg";
                }

                //Haber bilgisi ekleme işlemini gerçekleştirmektedir.
                _blogService.Add(new Blog()
                {
                    Title = txtTitle.Text.Trim(),
                    Description = ckeDescription.Text.Trim(),
                    Image = image,
                    IsStatus = cbStatus.Checked,
                    IsDetail = true,
                    BlogTypeId = (byte)TypeBlog.Blog,
                    GalleryId = Convert.ToInt32(ddlGallery.SelectedValue),
                    LanguageId = _cookieService.GetSessionAdmin().LanguageId,
                    Link = "#",
                    SequenceNumber = 0,
                    SeoTitle = txtSeoTitle.Text.Trim(),
                    SeoDescription = txtSeoDescription.Text.Trim(),
                    SeoKeywords = txtSeoKeyword.Text.Trim(),
                    CreationDate = DateTime.Now
                });

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