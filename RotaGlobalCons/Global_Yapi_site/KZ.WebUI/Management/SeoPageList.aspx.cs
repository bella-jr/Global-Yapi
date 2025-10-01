using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class SeoPageList : Page
    {
        private ISeoPageService _seoPageService;

        public SeoPageList()
        {
            _seoPageService = InstanceFactory.GetInstance<ISeoPageService>();
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
                rptSeoPageList.DataSource = _seoPageService.GetAll();
                rptSeoPageList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}