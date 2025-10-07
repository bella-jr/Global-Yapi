using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using System;

namespace KZ.WebUI.Management.ShortSavePages
{
    public partial class GalleryShortSave : System.Web.UI.Page
    {
        private IGalleryService _galleryService;
        protected void Page_Load(object sender, EventArgs e)
        {
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var menu = _galleryService.GetById(Convert.ToInt32(data));
                if (menu != null)
                {
                    menu.SequenceNumber = Convert.ToInt32(i);
                    _galleryService.Update(menu);
                }
                i++;
            }
        }
    }
}