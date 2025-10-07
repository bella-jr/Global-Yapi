using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;
using System;
using System.Web.UI.WebControls;

namespace KZ.WebUI.Management
{
    public partial class ReferenceList : BasePage
    {
        private IReferenceService _referenceService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public ReferenceList()
        {
            _referenceService = InstanceFactory.GetInstance<IReferenceService>();
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
                var language = _cookieService.GetSessionAdmin();
                var references = _referenceService.GetAll(language.LanguageId);

                rptReferenceList.DataSource = references;
                rptReferenceList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptReferenceList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var reference = _referenceService.GetById(Convert.ToInt32(e.CommandArgument));

                //Reference silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {

                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Reference_Images/"), reference.Image);
                    _referenceService.Delete(reference);
                }

                //Reference durumunu "pasif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Active")
                {
                    reference.IsStatus = false;
                    _referenceService.Update(reference);
                }

                //Reference durumunu "aktif" yapma işlemini gerçekletirmektedir.
                else if (e.CommandName == "Pasive")
                {
                    reference.IsStatus = true;
                    _referenceService.Update(reference);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void rptReferenceList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptReferenceList);
        }
    }
}