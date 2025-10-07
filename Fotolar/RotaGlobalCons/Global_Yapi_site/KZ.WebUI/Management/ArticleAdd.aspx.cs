using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ArticleAdd : System.Web.UI.Page
    {
        private IArticleService _articleService;
        private IMenuService _menuService;
        private IGalleryService _galleryService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICkEditorService _ckEditorService;
        private ICookieService _cookieService;

        public ArticleAdd()
        {
            _articleService = InstanceFactory.GetInstance<IArticleService>();
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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
                var cookieAdmin = _cookieService.GetSessionAdmin();
                var menus = _menuService.GetAll(cookieAdmin.LanguageId);
                var galleries = _galleryService.GetAll_UIControl();

                ddlMenuList.Items.Add(new ListItem() { Text = "Üst Menü Yok", Value = "0" });

                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList);
                _formControlService.GenerateDropdownList(galleries, ddlGallery);

                Session["UyeInfo"] = 1;
                _ckEditorService.StandartAyarlar(ckeDescription, "/Management/UploadFiles/Editor_Files/");

                txtSeoTitle.Text += "";
                txtSeoDescription.Text += "";
                txtSeoKeyword.Text += "";
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
                int menuId = Convert.ToInt32(ddlMenuList.SelectedValue);

                var menu = _menuService.GetById(menuId);
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

                if (_articleService.Get_MenuList(menuId) == null)
                {
                    _articleService.Add(new Article()
                    {
                        Title = txtTitle.Text.Trim(),
                        Description = ckeDescription.Text.Trim(),
                        IsStatus = cbStatus.Checked,
                        MenuId = menuId,
                        GalleryId = Convert.ToInt32(ddlGallery.SelectedValue),
                        LanguageId = _cookieService.GetSessionAdmin().LanguageId,
                        PageTypeId = (byte)TypePage.Menu_Detay, //Convert.ToByte(ddlPageTypleList.SelectedValue),
                        SeoTitle = txtSeoTitle.Text.Trim(),
                        SeoDescription = txtSeoDescription.Text.Trim(),
                        SeoKeywords = txtSeoKeyword.Text.Trim(),
                        CreationDate = DateTime.Now
                    });

                    _expressToolService.SuccessAlertMessage(Page, "ArticleAdd");
                }
                else
                {
                    lblMessage.Text = "Uyarı ! Daha önceden seçmiş olduğunuz menüye yazı eklenmiştir. Lütfen farklı bir menü seçimi yapınız.";
                    return;
                }

                _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}