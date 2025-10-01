using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class SeoPageUpdate : Page
    {
        private ISeoPageService _seoPageService;
        private IExpressToolService _expressToolService;

        public SeoPageUpdate()
        {
            _seoPageService = InstanceFactory.GetInstance<ISeoPageService>();
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
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var seo = _seoPageService.GetById(id);
                if (seo != null)
                {
                    ltlPageUrl.Text = "<a target=\"_blank\" href=\"" + seo.Url + "\" >" + seo.Url + "</a>";
                    txtTitle.Text = seo.SeoTitle;
                    txtDescription.Text = seo.SeoDescription;
                    //txtKeywords.Text = seo.SeoKeywords;
                }
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
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var seo = _seoPageService.GetById(id);

                seo.SeoTitle = txtTitle.Text.Trim();
                seo.SeoDescription = txtDescription.Text.Trim();
                seo.SeoKeywords = "-"; //txtKeywords.Text.Trim();

                _seoPageService.Update(seo);

                _expressToolService.SuccessAlertMessage(Page, "SeoPageList");
            }
            catch
            {
                _expressToolService.ErrorAlertMessage(Page, "#");
            }
        }
    }
}