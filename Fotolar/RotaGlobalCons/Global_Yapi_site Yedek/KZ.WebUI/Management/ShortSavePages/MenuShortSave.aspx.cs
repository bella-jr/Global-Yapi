using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class MenuShortSave : System.Web.UI.Page
    {
        private IMenuService _menuService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _menuService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.SequenceNumber = Convert.ToInt32(i);
                    _menuService.Update(menu);
                }
                i++;
            }

            Application.Remove("sahinKirtasiye_HeaderMenu");
            Application.Remove("sahinKirtasiye_MobileMenu");
            Application.Remove("sahinKirtasiye_FooterMenu");
        }
    }
}