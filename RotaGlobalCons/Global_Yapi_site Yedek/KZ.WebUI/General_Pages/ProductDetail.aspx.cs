using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using System;
using System.Web;
using System.Web.UI;

namespace KZ.WebUI.General_Pages
{
    public partial class ProductDetail : BasePage
    {
        private IProductService _productService;
        private IProductImageService _productImageService;
        private IProductPropertyService _productPropertyService;

        public ProductDetail()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _productImageService = InstanceFactory.GetInstance<IProductImageService>();
            _productPropertyService = InstanceFactory.GetInstance<IProductPropertyService>();
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
                var product = _productService.GetById(id);
                var productImages = _productImageService.GetAll(id);
                var productProperties = _productPropertyService.GetAll_Join(id);

                if (product != null && product.IsStatus == false)
                {
                    Response.Redirect("/" + Resources.value.url_Folder, false);
                }

                Page.Title = product.SeoTitle;
                Page.MetaDescription = product.SeoDescription;

                ltlOgTitle.Text = String.Format(@"<meta property=""og:title"" content=""{0}"" />", Page.Title);
                ltlOgDesciprion.Text = String.Format(@"<meta property=""og:description"" content=""{0}"" />", Page.MetaDescription);
                ltlOgSiteName.Text = String.Format(@"<meta property=""og:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlTwitter_Title.Text = String.Format(@"<meta property=""twitter:title"" content=""{0}"" />", Page.Title);
                ltlTwitter_Description.Text = String.Format(@"<meta property=""twitter:description"" content=""{0}"" />", Page.MetaDescription);
                ltlTwitter_Url.Text = String.Format(@"<meta property=""twitter:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                hfImage.Value = product.Image;
                ltlTitle.Text = product.Title;
                ltlDescription.Text = product.Description1;

                rptProductImageList.DataSource = productImages;
                rptProductImageList.DataBind();

                rptPropertyList.DataSource = productProperties;
                rptPropertyList.DataBind();

            }
            catch
            {
                return;
            }
        }
    }
}