using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.Models;

namespace KZ.WebUI.Management
{
    public partial class ArticleList : BasePage
    {
        private IArticleService _articleService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public ArticleList()
        {
            _articleService = InstanceFactory.GetInstance<IArticleService>();
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
                var articles = _articleService.GetAll(cookieAdmin.LanguageId);

                rptArticleList.DataSource = articles;
                rptArticleList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptArticleList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var article = _articleService.Get_MenuList(Convert.ToInt32(e.CommandArgument));

                //Yazıyı silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    _articleService.Delete(article);
                    LoadData();
                    _expressToolService.SuccessAlertMessage(Page, "#");
                }

                //Yazı durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    article.IsStatus = false;
                    _articleService.Update(article);
                    LoadData();
                }

                //Yazı durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    article.IsStatus = true;
                    _articleService.Update(article);
                    LoadData();
                }
            }
            catch
            {
                _expressToolService.ErrorAlertMessage(Page, "#");
            }
        }

        //Aktif-Pasif butonlarını ilgili durumlara göre listeleme işlemeini gerçekeştirmektedir.
        protected void rptArticleList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptArticleList);
        }
    }
}