using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;
using KZ.Business.Concrete;
using System.Web;

namespace KZ.WebUI
{
    public partial class Default : BasePage
    {
        private ISliderService _sliderService;
        private IHomePageContentService _homePageContentService;
        private IBlogService _blogService;
        private ICommentService _commentService;
        private IProductService _productService;
        private ISessionService _sessionService;

        public Default()
        {
            _sliderService = InstanceFactory.GetInstance<ISliderService>();
            _homePageContentService = InstanceFactory.GetInstance<IHomePageContentService>();
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _commentService = InstanceFactory.GetInstance<ICommentService>();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _sessionService = WebUIInstanceFactory.GetInstance<ISessionService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                var language = _sessionService.GetSessionLanguage();
                var homePageContent = _homePageContentService.Get(language.LanguageId);
                var sliders = _sliderService.GetAll_UI(language.LanguageId);
                var blogs = _blogService.GetAll_HomeLastTopList(3, language.LanguageId);
                var comments = _commentService.GetList_Home();
                var products = _productService.GetAll_Home(language.LanguageId);

                Page.Title = StaticGeneralSettingManager.GeneralSettingData().SeoTitle;
                Page.MetaDescription = StaticGeneralSettingManager.GeneralSettingData().SeoDescription;

                ltlOgTitle.Text = String.Format(@"<meta property=""og:title"" content=""{0}"" />", Page.Title);
                ltlOgDesciprion.Text = String.Format(@"<meta property=""og:description"" content=""{0}"" />", Page.MetaDescription);
                ltlOgSiteName.Text = String.Format(@"<meta property=""og:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlTwitter_Title.Text = String.Format(@"<meta property=""twitter:title"" content=""{0}"" />", Page.Title);
                ltlTwitter_Description.Text = String.Format(@"<meta property=""twitter:description"" content=""{0}"" />", Page.MetaDescription);
                ltlTwitter_Url.Text = String.Format(@"<meta property=""twitter:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                rptSliderList.DataSource = sliders;
                rptSliderList.DataBind();

                rptBlogList.DataSource = blogs;
                rptBlogList.DataBind();

                rptCommentList.DataSource = comments;
                rptCommentList.DataBind();

                rptProductList.DataSource = products;
                rptProductList.DataBind();

                ltlContent1.Text = homePageContent.Content1;
                ltlContent2.Text = homePageContent.Content2;
                ltlContent3.Text = homePageContent.Content3;

            }
            catch
            {
                return;
            }
        }

    }
}