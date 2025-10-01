using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class MostSearchedUpdate : System.Web.UI.Page
    {
        private IMostSearchedService _mostSearchedService;
        private IExpressToolService _expressToolService;
        private ICkEditorService _ckEditorService;

        public MostSearchedUpdate()
        {
            _mostSearchedService = InstanceFactory.GetInstance<IMostSearchedService>();
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
                var mostSearched = _mostSearchedService.GetById(id);

                txtTitle.Text = mostSearched.Title;
                //txtLink.Text = mostSearched.Link;
                cbIsView.Checked = mostSearched.IsView;

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
                var mostSearched = _mostSearchedService.GetById(id);

                mostSearched.Title = txtTitle.Text;
                //mostSearched.Link = txtLink.Text;
                mostSearched.IsView = cbIsView.Checked;

                _mostSearchedService.Update(mostSearched);

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

    }
}