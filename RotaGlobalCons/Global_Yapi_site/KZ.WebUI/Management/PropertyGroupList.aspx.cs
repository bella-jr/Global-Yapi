using System;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class PropertyGroupList : Page
    {
        private IPropertyGroupService _propertyGroupService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public PropertyGroupList()
        {
            _propertyGroupService = InstanceFactory.GetInstance<IPropertyGroupService>();
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
                var propertyGroups = _propertyGroupService.GetAll(cookieAdmin.LanguageId);

                rptPropertyGroupList.DataSource = propertyGroups;
                rptPropertyGroupList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptPropertyGroupList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    var group = _propertyGroupService.GetById(Convert.ToInt32(e.CommandArgument));
                    _propertyGroupService.Delete(group);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        [WebMethod]
        public static PropertyGroup GetGroup(int groupId)
        {
            IPropertyGroupService _propertyGroupService;
            _propertyGroupService = InstanceFactory.GetInstance<IPropertyGroupService>();
            var data = _propertyGroupService.GetById(groupId);
            return data;
        }

        protected void btnUpdateSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hfId.Value);
                var group = _propertyGroupService.GetById(id);

                group.Name = txtName.Text.Trim();

                _propertyGroupService.Update(group);

                txtName.Text = "";

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void btnAddSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                _propertyGroupService.Add(new PropertyGroup()
                {
                    Name = txtAddName.Text.Trim(),
                    LanguageId = _cookieService.GetSessionAdmin().LanguageId
                });

                txtAddName.Text = "";

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}