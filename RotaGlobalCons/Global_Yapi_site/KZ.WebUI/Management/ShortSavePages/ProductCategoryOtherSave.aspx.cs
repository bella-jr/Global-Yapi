using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using System;

namespace KZ.WebUI.Management.ShortSavePages
{
    public partial class ProductCategoryOtherSave : System.Web.UI.Page
    {
        private IProductMenuService _productMenuService;

        protected void Page_Load(object sender, EventArgs e)
        {
            _productMenuService = InstanceFactory.GetInstance<IProductMenuService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var product = _productMenuService.GetByIdOne(Convert.ToInt32(data));
                if (product != null)
                {
                    product.SequenceNumber = Convert.ToInt32(i);
                    _productMenuService.Update(product);
                }
                i++;
            }
        }
    }
}