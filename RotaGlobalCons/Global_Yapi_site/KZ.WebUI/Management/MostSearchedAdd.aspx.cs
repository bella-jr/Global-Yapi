using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using System;

namespace KZ.WebUI.Management
{
    public partial class MostSearchedAdd : System.Web.UI.Page
    {
        private IMostSearchedService _mostSearchedService;
        private IExpressToolService _expressToolService;

        public MostSearchedAdd()
        {
            _mostSearchedService = InstanceFactory.GetInstance<IMostSearchedService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var mostSearched = new MostSearched();

                mostSearched.Title = txtTitle.Text;
                mostSearched.Link = "#"; //txtLink.Text;
                mostSearched.IsView = cbIsView.Checked;
                mostSearched.CreationDate = DateTime.Now;

                _mostSearchedService.Add(mostSearched);

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