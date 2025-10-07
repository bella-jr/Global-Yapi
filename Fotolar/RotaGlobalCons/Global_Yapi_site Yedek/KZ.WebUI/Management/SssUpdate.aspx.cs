using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class SssUpdate : System.Web.UI.Page
    {
        private ISssService _sssService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;

        public SssUpdate()
        {
            _sssService = InstanceFactory.GetInstance<ISssService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
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
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var sss = _sssService.GetById(id);

                txtQuestion.Text = sss.Question;
                txtAnswer.Text = sss.Answer;
                cbIsHome.Checked = sss.IsHome;
                cbIsView.Checked = sss.IsView;

            }
            catch
            {
                return;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var sss = _sssService.GetById(id);

                sss.Question = txtQuestion.Text;
                sss.Answer = txtAnswer.Text;
                sss.IsView = cbIsView.Checked;
                sss.IsHome = cbIsHome.Checked;

                _sssService.Update(sss);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

    }
}