using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class ReferenceShort : System.Web.UI.Page
    {
        private IReferenceService _referenceService;
        private ICookieService _cookieService;

        public ReferenceShort()
        {
            _referenceService = InstanceFactory.GetInstance<IReferenceService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ddlTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var language = _cookieService.GetSessionAdmin();
                byte typeId = (byte)TypeReference.Referans; //Convert.ToByte(ddlTypeList.SelectedValue);
                var references = _referenceService.GetAll_UI(language.LanguageId, typeId);

                rptReferenceList.DataSource = references;
                rptReferenceList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}