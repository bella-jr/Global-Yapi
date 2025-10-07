using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class BlogShort : Page
    {
        private ICookieService _cookieService;
        private IBlogService _blogService;

        public BlogShort()
        {
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _blogService = InstanceFactory.GetInstance<IBlogService>();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData((byte)TypeBlog.Blog);
        }

        private void LoadData(byte typeId)
        {
            try
            {
                var cookieAdmin = _cookieService.GetSessionAdmin();
                var blogs = _blogService.GetAll_Active(typeId, cookieAdmin.LanguageId);

                rptBlogList.DataSource = blogs;
                rptBlogList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void ddlType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(Convert.ToByte(ddlType.SelectedValue));
        }
    }
}