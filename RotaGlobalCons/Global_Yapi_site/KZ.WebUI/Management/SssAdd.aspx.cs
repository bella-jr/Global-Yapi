using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class SssAdd : System.Web.UI.Page
    {
        private ISssService _sssService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;
        private ICookieService _cookieService;


        public SssAdd()
        {
            _sssService = InstanceFactory.GetInstance<ISssService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
            _cookieService = WebUIInstanceFactory.GetInstance<ICookieService>();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var sss = new SSS();

                sss.LanguageId = _cookieService.GetSessionAdmin().LanguageId;
                sss.Question = txtQuestion.Text;
                sss.Answer = txtAnswer.Text;
                sss.IsView = cbIsView.Checked;
                sss.IsHome = cbIsHome.Checked;
                sss.CreationDate = DateTime.Now;

                _sssService.Add(sss);

                _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}