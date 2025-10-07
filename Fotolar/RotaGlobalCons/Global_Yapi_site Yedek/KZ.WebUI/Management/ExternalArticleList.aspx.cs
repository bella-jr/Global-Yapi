using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.Models;

namespace KZ.WebUI.Management
{
    public partial class ExternalArticleList : BasePage
    {
        private IExtarnelArticleService _extarnelArticleService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public ExternalArticleList()
        {
            _extarnelArticleService = InstanceFactory.GetInstance<IExtarnelArticleService>();
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
                var articles = _extarnelArticleService.GetAll(cookieAdmin.LanguageId);

                rptExternalArticle.DataSource = articles;
                rptExternalArticle.DataBind();
            }
            catch
            {
                return;
            }
        }


        protected void rptExternalArticle_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var article = _extarnelArticleService.GetById(Convert.ToInt32(e.CommandArgument));

                //Yazıyı silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    _extarnelArticleService.Delete(article);
                }

                //Yazı durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    article.IsStatus = false;
                    _extarnelArticleService.Update(article);
                }

                //Yazı durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    article.IsStatus = true;
                    _extarnelArticleService.Update(article);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void rptExternalArticle_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptExternalArticle);
        }
    }
}