using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool;
using System;
using System.Web;

namespace KZ.WebUI.General_Pages
{
    public partial class BlogDetail : BasePage
    {

        private IBlogService _blogService;
        private IGalleryImageService _galleryImageService;
        public BlogDetail()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _galleryImageService = InstanceFactory.GetInstance<IGalleryImageService>();
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
                int id = Convert.ToInt32(RouteData.Values["id"].ToString());
                var blog = _blogService.GetById(id);

                if (blog != null && blog.IsStatus == false)
                {
                    Response.Redirect("/" + Resources.value.url_Folder + Resources.value.url_Blog, false);
                }

                Page.Title = blog.SeoTitle;
                Page.MetaDescription = blog.SeoDescription;

                ltlOgTitle.Text = String.Format(@"<meta property=""og:title"" content=""{0}"" />", blog.Title);
                ltlOgImage.Text = String.Format(@"<meta property=""og:image"" content=""{0}"" />", StaticDataTool.getSiteAddress() + "/Management/UploadFiles/Blog_Images/" + blog.Image);
                ltlOgDesciprion.Text = String.Format(@"<meta property=""og:description"" content=""{0}"" />", blog.SeoDescription);
                ltlOgSiteName.Text = String.Format(@"<meta property=""og:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlTwitter_Title.Text = String.Format(@"<meta property=""twitter:title"" content=""{0}"" />", blog.Title);
                ltlTwitter_Description.Text = String.Format(@"<meta property=""twitter:description"" content=""{0}"" />", blog.SeoDescription);
                ltlTwitter_Url.Text = String.Format(@"<meta property=""twitter:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                //hfImage.Value = blog.Image;
                ltlTitle.Text = blog.Title;
                ltlDescription.Text = blog.Description;

                if (blog.GalleryId != 0)
                {
                    var galleryImages = _galleryImageService.GetAll_UI(blog.GalleryId);

                    rptGalleryImageList.DataSource = galleryImages;
                    rptGalleryImageList.DataBind();
                }
            }
            catch
            {
                return;
            }
        }
    }
}