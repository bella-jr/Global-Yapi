using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.Entity.Enums;
using KZ.Core;
using System.Web;

namespace KZ.WebUI.General_Pages
{
    public partial class CategoryList : BasePage
    {
        private IMenuService _menuService;
        private IProductMenuService _productMenuService;

        public CategoryList()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _productMenuService = InstanceFactory.GetInstance<IProductMenuService>();
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
                int menuId = Convert.ToInt32(RouteData.Values["id"]);
                var menu = _menuService.GetById(menuId);
                var mainMenu = _menuService.GetById(menu.MainMenuId);
                var products = _productMenuService.GetAll_MenuId(menuId);

                Page.Title = menu.Name;
                Page.MetaDescription = menu.Name;

                ltlOgTitle.Text = String.Format(@"<meta property=""og:title"" content=""{0}"" />", Page.Title);
                ltlOgDesciprion.Text = String.Format(@"<meta property=""og:description"" content=""{0}"" />", Page.MetaDescription);
                ltlOgSiteName.Text = String.Format(@"<meta property=""og:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlTwitter_Title.Text = String.Format(@"<meta property=""twitter:title"" content=""{0}"" />", Page.Title);
                ltlTwitter_Description.Text = String.Format(@"<meta property=""twitter:description"" content=""{0}"" />", Page.MetaDescription);
                ltlTwitter_Url.Text = String.Format(@"<meta property=""twitter:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlMenuName.Text = menu.Name;

                if (mainMenu != null)
                {
                    if (mainMenu.IsExternal)
                        ltlMainMenu.Text = String.Format(@"<li><a title=""{1}"" href=""{0}"">{1}</a></li>", mainMenu.Link, mainMenu.Name);
                    else
                    {
                        if (mainMenu.IsSubMenuListView)
                        {
                            ltlMainMenu.Text = String.Format(@"<li><a title=""{4}"" href=""/{0}{1}/{2}/{3}"">{4}</a></li>", Resources.value.url_Folder, Resources.value.url_Kategoriler, Tools.UrlSeo(mainMenu.Name), mainMenu.Id, mainMenu.Name);
                        }
                        else
                        {
                            if (mainMenu.TypeId == (byte)MenuType.Kategori)
                            {
                                ltlMainMenu.Text = String.Format(@"<li><a title=""{4}"" href=""/{0}{1}/{2}/{3}"">{4}</a></li>", Resources.value.url_Folder, Resources.value.url_Kategori, Tools.UrlSeo(mainMenu.Name), mainMenu.Id, mainMenu.Name);
                            }
                            else
                            {
                                ltlMainMenu.Text = String.Format(@"<li><a title=""{4}"" href=""/{0}{1}/{2}/{3}"">{4}</a></li>", Resources.value.url_Folder, Resources.value.url_Menu, Tools.UrlSeo(mainMenu.Name), mainMenu.Id, mainMenu.Name);
                            }
                        }
                    }
                }

                rptProductList.DataSource = products;
                rptProductList.DataBind();


            }
            catch
            {
                return;
            }
        }
    }
}