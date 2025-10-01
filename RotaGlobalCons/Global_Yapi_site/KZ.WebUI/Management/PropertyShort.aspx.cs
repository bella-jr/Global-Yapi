using System;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class PropertyShort : Page
    {
        private IPropertyService _propertyService;
        private IPropertyGroupService _propertyGroupService;
        private IFormControlService _formControlService;
        private ICookieService _cookieService;

        public PropertyShort()
        {
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();
            _propertyGroupService = InstanceFactory.GetInstance<IPropertyGroupService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
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
                _formControlService.GenerateDropdownList(_propertyGroupService.GetAll_UIControl(_cookieService.GetSessionAdmin().LanguageId), ddlPropertyGroup);
            }
            catch
            {
                return;
            }
        }

        protected void ddlPropertyGroup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ltlProperty.Text = "";

                int groupId = Convert.ToInt32(ddlPropertyGroup.SelectedValue);

                var property = _propertyService.GetAll_GroupId(groupId);
                if (property != null)
                {
                    foreach (var item in property)
                        ltlProperty.Text += "<li id=\"order_" + item.Id + "\"><i class=\"fa fa-angle-right\"></i>&nbsp;" + item.Name + "</li>";
                }
            }
            catch
            {
                return;
            }
        }
    }
}