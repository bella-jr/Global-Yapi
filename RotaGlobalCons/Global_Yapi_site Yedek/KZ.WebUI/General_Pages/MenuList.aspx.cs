using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.Entity.Enums;
using KZ.Core;
using System.Web;
using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.DependencyResolvers.Ninject;

namespace KZ.WebUI.General_Pages
{
    public partial class MenuList : BasePage
    {
        private IMenuService _menuService;
        private IArticleService _articleService;
        private IGalleryImageService _galleryImageService;
        private IMenuToolService _menuToolService;

        public MenuList()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _articleService = InstanceFactory.GetInstance<IArticleService>();
            _galleryImageService = InstanceFactory.GetInstance<IGalleryImageService>();
            _menuToolService = WebUIInstanceFactory.GetInstance<IMenuToolService>();
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
                var article = _articleService.Get_MenuList(menuId);

                Page.Title = article == null ? menu.Name : article.SeoTitle;
                Page.MetaDescription = article == null ? menu.Name : article.SeoDescription;

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

                if (article != null)
                {
                    if (article.PageTypeId == (byte)TypePage.Menu_Detay)
                    {
                        ltlDescription.Text = article != null && article.IsStatus ? article.Description : "";

                        if (article.GalleryId > 0)
                        {
                            var galleryImage = _galleryImageService.GetAll_UI(article.GalleryId);

                            rptGalleryImageList.DataSource = galleryImage;
                            rptGalleryImageList.DataBind();

                            pnlGallery.Visible = true;
                        }

                    }
                }
            }
            catch
            {
                return;
            }
        }
    }
}