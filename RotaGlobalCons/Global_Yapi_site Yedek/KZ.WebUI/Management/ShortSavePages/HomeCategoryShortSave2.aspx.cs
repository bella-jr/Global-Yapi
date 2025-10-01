using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using System;

namespace KZ.WebUI.Management.ShortSavePages
{
    public partial class HomeCategoryShortSave2 : System.Web.UI.Page
    {
        private IMenuService _iMenuService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _iMenuService = InstanceFactory.GetInstance<IMenuService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _iMenuService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.HomeSequenceNumber2 = Convert.ToInt32(i);
                    _iMenuService.Update(menu);
                }
                i++;
            }
        }
    }
}