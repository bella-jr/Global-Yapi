using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class HomePageContentUpdate : Page
    {
        private IHomePageContentService _homePageContentService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;
        private ICkEditorService _ckEditorService;

        public HomePageContentUpdate()
        {
            _homePageContentService = InstanceFactory.GetInstance<IHomePageContentService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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
                var data = _homePageContentService.Get(language.LanguageId);

                ckeDescription1.Text = data.Content1;
                ckeDescription2.Text = data.Content2;
                ckeDescription3.Text = data.Content3;
                //ckeDescription4.Text = data.Content4;
                //ckeDescription5.Text = data.Content5;

                _ckEditorService.StandartAyarlar(ckeDescription1, "/Management/UploadFiles/Editor_Files/");
                _ckEditorService.StandartAyarlar(ckeDescription2, "/Management/UploadFiles/Editor_Files/");
                _ckEditorService.StandartAyarlar(ckeDescription3, "/Management/UploadFiles/Editor_Files/");
                //_ckEditorService.StandartAyarlar(ckeDescription4, "/Management/UploadFiles/Editor_Files/");
                //_ckEditorService.StandartAyarlar(ckeDescription5, "/Management/UploadFiles/Editor_Files/");

            }
            catch
            {
                return;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                var language = _cookieService.GetSessionAdmin();

                _homePageContentService.Update(new HomePageContent()
                {
                    Id = language.LanguageId,
                    Content1 = ckeDescription1.Text.Trim(),
                    Content2 = ckeDescription2.Text.Trim(),
                    Content3 = ckeDescription3.Text.Trim(),
                    Content4 = "-", //ckeDescription4.Text.Trim(),
                    Content5 = "-", //ckeDescription5.Text.Trim(),
                    LanguageId = language.LanguageId
                });

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}