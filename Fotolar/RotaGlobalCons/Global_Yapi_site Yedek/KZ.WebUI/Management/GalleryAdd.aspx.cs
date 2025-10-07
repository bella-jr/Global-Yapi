using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class GalleryAdd : Page
    {
        private IGalleryService _galleryService;
        private IGalleryImageService _galleryImageService;
        private IExpressToolService _expressToolService;

        public GalleryAdd()
        {
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _galleryImageService = InstanceFactory.GetInstance<IGalleryImageService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void rptGalleryImageList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var galleryImage = _galleryImageService.GetById(Convert.ToInt32(e.CommandArgument));

                if (e.CommandName == "Delete")
                {
                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/"), galleryImage.Image);
                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/Big_"), galleryImage.Image);
                    _galleryImageService.Delete(galleryImage);
                }

                else if (e.CommandName == "CoverImage")
                {
                    _galleryService = InstanceFactory.GetInstance<IGalleryService>();
                    var gallery = _galleryService.GetById(galleryImage.GalleryId);
                    gallery.Image = galleryImage.Image;
                    _galleryService.Update(gallery);
                }

                LoadImages(galleryImage.GalleryId);
            }
            catch
            {
                _expressToolService.ErrorAlertMessage(Page, "#");
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                var gallery = new Gallery()
                {
                    Name = txtTitle.Text.Trim(),
                    Image = "Default.jpg",
                    IsStatus = cbStatus.Checked,
                    CreationDate = DateTime.Now,
                    IsHome = false
            };
                _galleryService.Add(gallery);

                string folder = "", guid = "";
                bool isDefaultImage = false;
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];
                    if (userPostedFile.ContentLength > StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum)
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yükleyebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }

                    folder = Server.MapPath("UploadFiles/Gallery_Images/");
                    userPostedFile.SaveAs(folder + Path.GetFileName(userPostedFile.FileName));

                    guid = Guid.NewGuid().ToString();

                    _expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getGallerySmallImageWidth(), StaticDataTool.getGallerySmallImageHeight(), guid, "");
                    _expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getGalleryBigImageWidth(), StaticDataTool.getGalleryBigImageHeight(), guid, "Big_");

                    _expressToolService.FileDelete(folder, userPostedFile.FileName);

                    _galleryImageService.Add(new GalleryImage()
                    {
                        Image = guid + ".jpg",
                        GalleryId = gallery.Id,
                        SequenceNumber = 0
                    });

                    //Galeriye varsayılan resmi kapak resmi yapma işlemini gerçekleştirmektedir.
                    if (isDefaultImage == false)
                    {
                        var galleryUpdate = _galleryService.GetById(gallery.Id);
                        galleryUpdate.Image = guid + ".jpg";
                        _galleryService.Update(galleryUpdate);
                        isDefaultImage = true;
                    }
                }

                _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);

                LoadImages(gallery.Id);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        void LoadImages(int galleryId)
        {
            var galleryImages = _galleryImageService.GetAll(galleryId);

            rptGalleryImageList.DataSource = _galleryImageService.GetAll(galleryId);
            rptGalleryImageList.DataBind();
        }

    }
}