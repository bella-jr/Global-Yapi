using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ArticleUpdate : System.Web.UI.Page
    {
        private IArticleService _articleService;
        private IMenuService _menuService;
        private IGalleryService _galleryService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICkEditorService _ckEditorService;
        private ICookieService _cookiService;

        public ArticleUpdate()
        {
            _articleService = InstanceFactory.GetInstance<IArticleService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
            _cookiService = WebUIInstanceFactory.GetInstance<ICookieService>();
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
                int menuId = Convert.ToInt32(RouteData.Values["menuId"]);
                var cookieAdmin = _cookiService.GetSessionAdmin();
                var menus = _menuService.GetAll(cookieAdmin.LanguageId);
                var galleries = _galleryService.GetAll_UIControl();
                var article = _articleService.Get_MenuList(menuId);


                ddlMenuList.Items.Add(new ListItem() { Text = "Üst Menü Yok", Value = "0" });
                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList);
                //_formControlService.DropDownMenuLoad(_menuService.GetAllType((byte)MenuType.Menu, _sessionService.GetSessionAdmin().LanguageId), 0, 0, ddlMenuList);
                _formControlService.GenerateDropdownList(galleries, ddlGallery);


                if (article != null)
                {
                    txtTitle.Text = article.Title;
                    ckeDescription.Text = article.Description;
                    ddlMenuList.SelectedValue = article.MenuId.ToString();
                    ddlGallery.SelectedValue = article.GalleryId.ToString();
                    //ddlPageTypleList.SelectedValue = article.PageTypeId.ToString();
                    cbStatus.Checked = article.IsStatus;
                    txtSeoTitle.Text = article.SeoTitle;
                    txtSeoDescription.Text = article.SeoDescription;
                    txtSeoKeyword.Text = article.SeoKeywords;
                }


                Session["UyeInfo"] = 1;
                _ckEditorService.StandartAyarlar(ckeDescription, "/Management/UploadFiles/Editor_Files/");
            }
            catch
            {
                return;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int menuId = Convert.ToInt32(RouteData.Values["menuId"]);
                var menu = _menuService.GetById(Convert.ToInt32(ddlMenuList.SelectedValue));
                if (menu.IsExternal)
                {
                    lblMessage.Text = "Harici linke sahip bir menüye yazı eklenemez. Lütfen farklı bir menü seçiniz.";
                    return;
                }

                if (menu.TypeId == (byte)MenuType.Kategori)
                {
                    lblMessage.Text = "Lütfen kategori olmayan menü seçimiz yapınız.";
                    return;
                }

                lblMessage.Text = "";

                var controlArticle = _articleService.Get_MenuList(Convert.ToInt32(ddlMenuList.SelectedValue));
                var article = _articleService.Get_MenuList(menuId);

                if (controlArticle == null || article.MenuId == Convert.ToInt32(ddlMenuList.SelectedValue))
                {
                    article.Title = txtTitle.Text.Trim();
                    article.Description = ckeDescription.Text.Trim();
                    article.IsStatus = cbStatus.Checked;
                    article.MenuId = Convert.ToInt32(ddlMenuList.SelectedValue);
                    article.GalleryId = Convert.ToInt32(ddlGallery.SelectedValue);
                    //article.PageTypeId = Convert.ToByte(ddlPageTypleList.SelectedValue);
                    article.SeoTitle = txtSeoTitle.Text.Trim();
                    article.SeoDescription = txtSeoDescription.Text.Trim();
                    article.SeoKeywords = txtSeoKeyword.Text.Trim();

                    _articleService.Update(article);

                    LoadData();

                    ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");

                }
                else
                {
                    lblMessage.Text = "Uyarı ! Daha önceden seçmiş olduğunuz menüye yazı eklenmiştir. Lütfen farklı bir menü seçimi yapınız.";
                    return;
                }
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}