using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.Models;

namespace KZ.WebUI.Management
{
    public partial class BlogList : BasePage
    {
        private IBlogService _blogService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;


        public BlogList()
        {
            _blogService = InstanceFactory.GetInstance<IBlogService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();

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
                var cookieAdmin = _cookieService.GetSessionAdmin();
                var blogs = _blogService.GetAll(cookieAdmin.LanguageId);

                rptBlogList.DataSource = blogs;
                rptBlogList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptBlogList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var blog = _blogService.GetById(Convert.ToInt32(e.CommandArgument));

                //Kulüp silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Blog_Images/Small_"), blog.Image);
                    //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Blog_Images/Big_"), blog.Image);

                    _blogService.Delete(blog);
                }

                //Kulüp durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    blog.IsStatus = false;
                    _blogService.Update(blog);
                }

                //Kulüp durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    blog.IsStatus = true;
                    _blogService.Update(blog);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Aktif-Pasif butonlarını ilgili durumlara göre listeleme işlemeini gerçekeştirmektedir.
        protected void rptBlogList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptBlogList);
        }
    }
}