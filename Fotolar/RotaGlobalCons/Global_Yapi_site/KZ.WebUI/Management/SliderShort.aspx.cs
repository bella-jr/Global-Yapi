using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class SliderShort : System.Web.UI.Page
    {
        private ISliderService _sliderService;
        private ICookieService _cookieService;

        public SliderShort()
        {
            _sliderService = InstanceFactory.GetInstance<ISliderService>();
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
                var sliders = _sliderService.GetAll(cookieAdmin.LanguageId);

                rptSliderList.DataSource = sliders;
                rptSliderList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}