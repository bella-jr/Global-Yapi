using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class GalleryList : Page
    {
        private IArticleService _articleService;
        private IExtarnelArticleService _extarnelArticleService;
        private IGalleryService _galleryService;
        private IGalleryImageService _galleryImageService;
        private IExpressToolService _expressToolService;
        private IBlogService _blogService;
        private ICookieService _cookieService;

        public GalleryList()
        {
            _articleService = InstanceFactory.GetInstance<IArticleService>();
            _extarnelArticleService = InstanceFactory.GetInstance<IExtarnelArticleService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _galleryImageService = InstanceFactory.GetInstance<IGalleryImageService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _blogService = InstanceFactory.GetInstance<IBlogService>();
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
                var galleries = _galleryService.GetAll();

                rptGalleryList.DataSource = galleries;
                rptGalleryList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptGalleryList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var gallery = _galleryService.GetById(Convert.ToInt32(e.CommandArgument));

                if (e.CommandName == "Delete")
                {
                    var galleryImages = _galleryImageService.GetAll(gallery.Id);
                    var article = _articleService.GetAll_GalleryId(gallery.Id);
                    var language = _cookieService.GetSessionAdmin();
                    var extarnelArticle = _extarnelArticleService.GetAll_GalleryId(gallery.Id, language.LanguageId);
                    var blog = _blogService.GetAll_GalleryIdList(gallery.Id, language.LanguageId);

                    foreach (var item in galleryImages)
                    {
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/"), item.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Gallery_Images/Big_"), item.Image);
                        _galleryImageService.Delete(item);
                    }

                    //Galeri silirse ona ait olan yazıları otomatik olarak güncellemektedir.
                    foreach (var item in article)
                    {
                        item.GalleryId = 0;
                        _articleService.Update(item);
                    }

                    //Galeri silirse ona ait olan yazıları otomatik olarak güncellemektedir.
                    foreach (var item in extarnelArticle)
                    {
                        item.GalleryId = 0;
                        _extarnelArticleService.Update(item);
                    }

                    //Galeri silirse ona ait olan blog yazılarını otomatik olarak güncellemektedir.
                    foreach (var item in blog)
                    {
                        item.GalleryId = 0;
                        _blogService.Update(item);
                    }

                    _galleryService.Delete(gallery);
                }

                else if (e.CommandName == "Active")
                {
                    gallery.IsStatus = false;
                    _galleryService.Update(gallery);
                }


                //else if (e.CommandName == "HomeActive")
                //{
                //    gallery.IsHome = false;
                //    _galleryService.Update(gallery);
                //}

                else if (e.CommandName == "Pasive")
                {
                    gallery.IsStatus = true;
                    _galleryService.Update(gallery);
                }

                //else if (e.CommandName == "HomePasive")
                //{
                //    gallery.IsHome = true;
                //    _galleryService.Update(gallery);
                //}

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Aktif-Pasif butonlarını ilgili durumlara göre listeleme işlemeini gerçekeştirmektedir.
        protected void rptGalleryList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptGalleryList);
            //_expressToolService.Status("hfHome", "btnHomeActive", "btnHomePasive", e, rptGalleryList);
        }
    }
}