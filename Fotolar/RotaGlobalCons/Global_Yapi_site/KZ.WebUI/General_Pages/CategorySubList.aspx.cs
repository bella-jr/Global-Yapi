using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Core;
using KZ.Entity.Enums;
using KZ.WebUI.Models;
using System;
using System.Web;
using System.Web.UI;

namespace KZ.WebUI.General_Pages
{
    public partial class CategorySubList : BasePage
    {
        private IMenuService _menuService;
        private IArticleService _articleService;

        public CategorySubList()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _articleService = InstanceFactory.GetInstance<IArticleService>();
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
                var subMenus = _menuService.GetAll_SubList(menuId);
                var mainMenu = _menuService.GetById(menu.MainMenuId);
                var article = _articleService.Get_MenuList(menuId);

                Page.Title = menu.Name;
                Page.MetaDescription = menu.Name;
                Page.MetaKeywords = menu.SeoDescription;

                ltlOgTitle.Text = String.Format(@"<meta property=""og:title"" content=""{0}"" />", Page.Title);
                ltlOgDesciprion.Text = String.Format(@"<meta property=""og:description"" content=""{0}"" />", Page.MetaDescription);
                ltlOgSiteName.Text = String.Format(@"<meta property=""og:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlTwitter_Title.Text = String.Format(@"<meta property=""twitter:title"" content=""{0}"" />", Page.Title);
                ltlTwitter_Description.Text = String.Format(@"<meta property=""twitter:description"" content=""{0}"" />", Page.MetaDescription);
                ltlTwitter_Url.Text = String.Format(@"<meta property=""twitter:url"" content=""{0}"" />", HttpContext.Current.Request.Url.AbsoluteUri);

                ltlMenuName.Text = menu.Name;
                //ltlDescription.Text = article == null ? " " : article.Description;

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

                rptSubCategoryList.DataSource = subMenus;
                rptSubCategoryList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}