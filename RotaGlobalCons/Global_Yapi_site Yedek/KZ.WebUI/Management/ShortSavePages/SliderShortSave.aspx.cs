using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class SliderShortSave : System.Web.UI.Page
    {
        private ISliderService _sliderService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _sliderService = InstanceFactory.GetInstance<ISliderService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _sliderService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.SequenceNumber = Convert.ToInt32(i);
                    _sliderService.Update(menu);
                }
                i++;
            }
        }
    }
}