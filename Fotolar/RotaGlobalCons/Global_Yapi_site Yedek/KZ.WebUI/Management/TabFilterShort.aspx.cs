using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class TabFilterShort : Page
    {
        private ITabFilterService _tabFilterService;
        private ICookieService _cookieService;

        public TabFilterShort()
        {
            _tabFilterService = InstanceFactory.GetInstance<ITabFilterService>();
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
                var tabFilters = _tabFilterService.GetAll(cookieAdmin.LanguageId);

                rptTabFilterList.DataSource = tabFilters;
                rptTabFilterList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}