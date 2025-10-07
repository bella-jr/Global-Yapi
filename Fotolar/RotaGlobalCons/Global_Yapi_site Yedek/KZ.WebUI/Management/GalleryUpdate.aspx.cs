using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class GalleryUpdate : Page
    {
        private IGalleryService _galleryService;
        private IGalleryImageService _galleryImageService;
        private IExpressToolService _expressToolService;

        public GalleryUpdate()
        {
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _galleryImageService = InstanceFactory.GetInstance<IGalleryImageService>();
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
                int galleryId = Convert.ToInt32(RouteData.Values["galleryId"]);
                var gallery = _galleryService.GetById(galleryId);
                var galleryImages = _galleryImageService.GetAll(galleryId);

                txtTitle.Text = gallery.Name;
                cbStatus.Checked = gallery.IsStatus;
                //cbIsHome.Checked = gallery.IsHome;

                rptGalleryImageList.DataSource = galleryImages;
                rptGalleryImageList.DataBind();
            }
            catch
            {
                return;
            }
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

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int galleryId = Convert.ToInt32(RouteData.Values["galleryId"]);
                var gallery = _galleryService.GetById(galleryId);

                gallery.Name = txtTitle.Text.Trim();
                gallery.IsStatus = cbStatus.Checked;
                //gallery.IsHome = cbIsHome.Checked;
                _galleryService.Update(gallery);

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
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void btnAllDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(RouteData.Values["galleryId"]);
                var galleryImages = _galleryImageService.GetAll(id);
                if (galleryImages.Count > 0)
                {
                    foreach (var item in galleryImages)
                    {
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/"), item.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/Big_"), item.Image);
                        _galleryImageService.Delete(item);
                    }
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void btnSelectedAllDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in rptGalleryImageList.Items)
                {
                    HtmlInputCheckBox chkDisplayTitle = (HtmlInputCheckBox)item.FindControl("chkDisplayTitle");
                    if (chkDisplayTitle.Checked)
                    {
                        var galleryImage = _galleryImageService.GetById(Convert.ToInt32(chkDisplayTitle.Value));
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/"), galleryImage.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/Big_"), galleryImage.Image);
                        _galleryImageService.Delete(galleryImage);
                    }
                }

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