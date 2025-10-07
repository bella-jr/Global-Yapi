using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class MenuShort : System.Web.UI.Page
    {
        private IMenuService _menuService;
        private ICookieService _cookieService;
        private IFormControlService _formControlService;

        public MenuShort()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
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
                var headerMenus = _menuService.GetAll_UIMenuList(0, language.LanguageId);
                //var headerMenusLeft = _menuService.GetAll_LeftMenuList(language.LanguageId);
                //var headerMenusRight = _menuService.GetAll_RightMenuList(language.LanguageId);
                var footerMenu = _menuService.GetAll_FooterList(language.LanguageId);
                var menus = _menuService.GetAll(language.LanguageId);

                ddlMenuList.Items.Add(new ListItem() { Text = "Üst Menü Yok", Value = "0" });
                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList);

                var homeCategory = _menuService.GetAll_HomeMenuList(language.LanguageId);
                var homeCategory2 = _menuService.GetAll_HomeMenuList2(language.LanguageId);
                //var accordioonMenu = _menuService.GetAll_AccordionList(language.LanguageId);
                //var sidebarMenu = _menuService.GetAll_SidebarList(language.LanguageId);

                rptHeaderMenuList.DataSource = headerMenus;
                rptHeaderMenuList.DataBind();

                rptFooterList.DataSource = footerMenu;
                rptFooterList.DataBind();

                //rptHomeCategoryList.DataSource = homeCategory;
                //rptHomeCategoryList.DataBind();

                //rptHomeCategoryList2.DataSource = homeCategory2;
                //rptHomeCategoryList2.DataBind();

                //rptAccordionList.DataSource = accordioonMenu;
                //rptAccordionList.DataBind();

                //rptSidebarList.DataSource = sidebarMenu;
                //rptSidebarList.DataBind();

                //rptHeaderMenuListLeft.DataSource = headerMenusLeft;
                //rptHeaderMenuListLeft.DataBind();

                //rptHeaderMenuListRight.DataSource = headerMenusRight;
                //rptHeaderMenuListRight.DataBind();


            }
            catch
            {
                return;
            }
        }

        protected void ddlMenuList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ddlMenuList.SelectedValue);
            var submenus = _menuService.GetAll_SubList(id);

            rptSubMenuList.DataSource = submenus;
            rptSubMenuList.DataBind();
        }
    }
}