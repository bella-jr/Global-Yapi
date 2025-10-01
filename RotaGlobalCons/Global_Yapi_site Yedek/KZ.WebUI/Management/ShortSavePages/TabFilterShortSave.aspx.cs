using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class TabFilterShortSave : Page
    {
        private ITabFilterService _tabFilterService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _tabFilterService = InstanceFactory.GetInstance<ITabFilterService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _tabFilterService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.SequenceNumber = Convert.ToInt32(i);
                    _tabFilterService.Update(menu);
                }
                i++;
            }
        }
    }
}