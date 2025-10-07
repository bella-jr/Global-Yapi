using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ProductShort : System.Web.UI.Page
    {
        private IProductService _productService;
        private IMenuService _menuService;
        private IProductMenuService _productMenuService;
        private ICookieService _cookieService;
        private IFormControlService _formControlService;
        private IExpressToolService _expressToolService;

        public ProductShort()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _productMenuService = InstanceFactory.GetInstance<IProductMenuService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
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
                var language = _cookieService.GetSessionAdmin();
                //var otherProducts = _productService.GetPopularProductList(language.LanguageId);
                var menus = _menuService.GetAllType((byte)MenuType.Kategori, language.LanguageId);
                var homeProducts = _productService.GetAll_Home(language.LanguageId);

                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList);

                rptHomeProductList.DataSource = homeProducts;
                rptHomeProductList.DataBind();

                //rptPopularList.DataSource = popularProducts;
                //rptPopularList.DataBind();

                //rptOpportunityList.DataSource = opportunityProducts;
                //rptOpportunityList.DataBind();

                //rptOtherList.DataSource = otherProducts;
                //rptOtherList.DataBind();

            }
            catch
            {
                return;
            }
        }

        protected void ddlMenuList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var products = _productMenuService.GetAll_MenuId(Convert.ToInt32(ddlMenuList.SelectedValue));

            rptCategoryProductList.DataSource = products;
            rptCategoryProductList.DataBind();
        }
    }
}