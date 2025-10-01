using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management.ShortSavePages
{
    public partial class PopularProductShortSave : System.Web.UI.Page
    {
        private IProductService _productService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _productService = InstanceFactory.GetInstance<IProductService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _productService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.PopularSequenceNumber = Convert.ToInt32(i);

                    _productService.Update(menu);
                }
                i++;
            }
        }
    }
}