using System;
using System.IO;
using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class BlogUpdate : System.Web.UI.Page
    {
        private IBlogService _blogService;
        private IGalleryService _galleryService;
        private IFormControlService _formControlService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;



        public BlogUpdate()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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

                int id = Convert.ToInt32(RouteData.Values["blogId"]);
                var blog = _blogService.GetById(id);
                var galleries = _galleryService.GetAll_UIControl();

                _formControlService.GenerateDropdownList(galleries, ddlGallery);

                ltlImage.Text = "<img src=\"UploadFiles/Blog_Images/Small_" + blog.Image + "\" width=\"150\" />";
                lnkImageDelete.Visible = blog.Image == "Default.jpg" ? false : true;

                txtTitle.Text = blog.Title;
                //txtLink.Text = blog.Link;
                ckeDescription.Text = blog.Description;
                cbStatus.Checked = blog.IsStatus;
                // ddlType.SelectedValue = blog.BlogTypeId.ToString();
                ddlGallery.SelectedValue = blog.GalleryId.ToString();
                txtSeoTitle.Text = blog.SeoTitle;
                txtSeoDescription.Text = blog.SeoDescription;
                txtSeoKeyword.Text = blog.SeoKeywords;

                Session["UyeInfo"] = 1;
                _ckEditorService.StandartAyarlar(ckeDescription, "/Management/UploadFiles/Editor_Files/");
            }
            catch
            {
                return;
            }
        }

        //Otomatik olarak yazı başlığını replace edip link haline getirmektedir.
        //protected void txtLink_OnTextChanged(object sender, EventArgs e)
        //{
        //    txtLink.Text = Tools.UrlSeo(txtLink.Text.Trim());
        //    txtLink.Enabled = true;
        //}

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(RouteData.Values["blogId"]);
                var blog = _blogService.GetById(id);

                //Eğer yüklenecenek bir resim seçilmiş ise haber resmi yükleme işlemini gerçekleştirmektedir.
                //if (flpImage.HasFile)
                //{
                //    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                //    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = "", UploadImageName = "";
                //        uploadFolder = Server.MapPath("UploadFiles/Blog_Images/");
                //        flpImage.SaveAs(uploadFolder + flpImage.FileName);

                //        _expressToolService.FileDelete(uploadFolder, blog.Image);

                //        UploadImageName = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getBlogImageWidth(), StaticDataTool.getBlogImageHeight(), "");
                //        blog.Image = UploadImageName;
                //    }
                //    else
                //    {
                //        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                //        lblImageError.Visible = true;
                //        return;
                //    }
                //}

                string folder = "", guid = "";
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

                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Blog_Images/Small_"), blog.Image);
                    //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Blog_Images/Big_"), blog.Image);

                    blog.Image = guid + ".jpg";
                }

                //Haber bilgisi ekleme işlemini gerçekleştirmektedir.
                blog.Title = txtTitle.Text.Trim();
                blog.Description = ckeDescription.Text.Trim();
                blog.IsStatus = cbStatus.Checked;
                blog.IsDetail = true;
                //blog.BlogTypeId = Convert.ToInt32(ddlType.SelectedValue);
                blog.GalleryId = Convert.ToInt32(ddlGallery.SelectedValue);
                blog.SeoTitle = txtSeoTitle.Text.Trim();
                blog.SeoDescription = txtSeoDescription.Text.Trim();
                blog.SeoKeywords = txtSeoKeyword.Text.Trim();

                _blogService.Update(blog);

                LoadData();

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }



        protected void lnkImageDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(RouteData.Values["blogId"]);
                var blog = _blogService.GetById(id);

                _expressToolService.FileDelete(Server.MapPath("UploadFiles/Blog_Images/Small_"), blog.Image);
                _expressToolService.FileDelete(Server.MapPath("UploadFiles/Blog_Images/Big_"), blog.Image);

                blog.Image = "Default.jpg";
                _blogService.Update(blog);

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