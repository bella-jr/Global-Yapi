using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;
using System.Web.UI.WebControls;

namespace KZ.WebUI.Management
{
    public partial class SssList : System.Web.UI.Page
    {
        private ISssService _sssService;
        private ICookieService _cookieService;
        private IExpressToolService _expressToolService;

        public SssList()
        {
            _sssService = InstanceFactory.GetInstance<ISssService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
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
                var ssss = _sssService.GetList(_cookieService.GetSessionAdmin().LanguageId);

                rptSssList.DataSource = ssss;
                rptSssList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptSssList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var sss = _sssService.GetById(Convert.ToInt32(e.CommandArgument));

                //Yazıyı silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    _sssService.Delete(sss);

                }

                //Yazı durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    sss.IsView = false;
                    _sssService.Update(sss);
                }

                //Yazı durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    sss.IsView = true;
                    _sssService.Update(sss);
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
        protected void rptSssList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptSssList);
        }
    }
}