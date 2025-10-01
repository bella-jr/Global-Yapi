using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class BlogShortSave : Page
    {
        private IBlogService _blogService;

        protected void Page_Load(object sender, EventArgs e)
        {

            _blogService = InstanceFactory.GetInstance<IBlogService>();

            string response = Request.Form.ToString().Replace("%5b%5d", "[]").Replace("order[]=", "");
            char[] brackets = new char[] { '&' };
            string[] sent = response.Split(brackets);
            int i = 1;
            foreach (string data in sent)
            {
                var blog = _blogService.GetById(Convert.ToInt32(data));
                if (blog != null)
                {
                    blog.SequenceNumber = Convert.ToInt32(i);
                    _blogService.Update(blog);
                }
                i++;
            }
        }
    }
}