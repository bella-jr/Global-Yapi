using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class PopularProductShort : System.Web.UI.Page
    {
        private IProductService _productService;
        private ICookieService _cookieService;

        public PopularProductShort()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
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
                var sessionAdmin = _cookieService.GetSessionAdmin();
                var products = _productService.GetPopularProductList(sessionAdmin.LanguageId);

                rptPopularProductList.DataSource = products;
                rptPopularProductList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}