using System;
using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.UserControl
{
    public partial class ucPageSeo : System.Web.UI.UserControl
    {
        private ISeoPageService _seoPageService;

        public ucPageSeo()
        {
            _seoPageService = InstanceFactory.GetInstance<ISeoPageService>();
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
                var data = _seoPageService.GetByUrl(HttpContext.Current.Request.RawUrl);

                if (data != null)
                {
                    Page.Title = String.Format("{0}", data.SeoTitle);
                    Page.MetaDescription = data.SeoDescription;
                    Page.MetaKeywords = data.SeoKeywords;

                    ltlOgTitle.Text = String.Format(@"<meta property=""og:title"" content=""{0}"" />", Page.Title);
                    //ltlOgImage.Text = String.Format(@"<meta property=""og:image"" content=""{0}"" />", StaticDataTool.getSiteAddress() + "/site_files/images/social_cover.jpg");
                    ltlOgDesciprion.Text = String.Format(@"<meta property=""og:description"" content=""{0}"" />", Page.MetaDescription);
                    ltlOgSiteName.Text = String.Format(@"<meta property=""og:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                    ltlTwitter_Title.Text = String.Format(@"<meta property=""twitter:title"" content=""{0}"" />", Page.Title);
                    ltlTwitter_Description.Text = String.Format(@"<meta property=""twitter:description"" content=""{0}"" />", Page.MetaDescription);
                    ltlTwitter_Url.Text = String.Format(@"<meta property=""twitter:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);
                }
            }
            catch
            {
                return;
            }
        }
    }
}