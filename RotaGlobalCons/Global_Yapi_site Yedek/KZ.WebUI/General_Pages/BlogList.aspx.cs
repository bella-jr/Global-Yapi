using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.General_Pages
{
    public partial class BlogList : BasePage
    {

        private IBlogService _blogService;
        private ISessionService _sessionService;

        public BlogList()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _sessionService = WebUIInstanceFactory.GetInstance<ISessionService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        private void LoadData()
        {
            try
            {
                var language = _sessionService.GetSessionLanguage();
                var blogs = _blogService.GetAll_Active((byte)TypeBlog.Blog, language.LanguageId);

                rptBlogList.DataSource = blogs;
                rptBlogList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}