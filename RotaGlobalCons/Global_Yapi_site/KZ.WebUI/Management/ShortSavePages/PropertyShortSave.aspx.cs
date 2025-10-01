using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class PropertyShortSave : Page
    {
        private IPropertyService _propertyService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _propertyService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.SequenceNumber = Convert.ToInt32(i);
                    _propertyService.Update(menu);
                }
                i++;
            }
        }
    }
}