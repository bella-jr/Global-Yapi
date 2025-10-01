using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Models;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.General_Pages
{
    public partial class ReferenceList : BasePage
    {
        private IReferenceService _referenceService;
        private ISessionService _sessionService;

        public ReferenceList()
        {
            _referenceService = InstanceFactory.GetInstance<IReferenceService>();
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
                var references = _referenceService.GetAll_UI(language.LanguageId, (byte)TypeReference.Referans);

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