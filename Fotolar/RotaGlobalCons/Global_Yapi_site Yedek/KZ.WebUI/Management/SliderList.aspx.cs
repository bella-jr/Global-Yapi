using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class SliderList : System.Web.UI.Page
    {
        private ISliderService _sliderService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public SliderList()
        {
            _sliderService = InstanceFactory.GetInstance<ISliderService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
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

        protected void rptSliderList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var slider = _sliderService.GetById(Convert.ToInt32(e.CommandArgument));

                //Slider silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {

                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Slider_Images/"), slider.Image);
                    _sliderService.Delete(slider);
                }

                //Slider durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    slider.IsStatus = false;
                    _sliderService.Update(slider);
                }

                //Slider durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    slider.IsStatus = true;
                    _sliderService.Update(slider);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void rptSliderList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptSliderList);
        }
    }
}