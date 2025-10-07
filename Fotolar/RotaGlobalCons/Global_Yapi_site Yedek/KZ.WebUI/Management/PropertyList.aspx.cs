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
    public partial class PropertyList : Page
    {
        private IPropertyGroupService _propertyGroupService;
        private IPropertyService _propertyService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICookieService _cookieService;

        public PropertyList()
        {
            _propertyGroupService = InstanceFactory.GetInstance<IPropertyGroupService>();
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
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
                var language = _cookieService.GetSessionAdmin();
                var groups = _propertyGroupService.GetAll_UIControl(language.LanguageId);
                var properties = _propertyService.GetAll();

                rptPropertyList.DataSource = properties;
                rptPropertyList.DataBind();

                _formControlService.GenerateDropdownList(groups, ddlAdd_PropertyGroup);
                _formControlService.GenerateDropdownList(groups, ddlUpdate_ProperyGroup);
            }
            catch
            {
                return;
            }
        }

        protected void btnAddSave_OnClick(object sender, EventArgs e)
        {
            try
            {

                //string image = "Default.jpg";

                //if (flpAddImage.HasFile)
                //{
                //    int fileSize = Convert.ToInt32(flpUpdateImage.PostedFile.ContentLength);
                //    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = "";
                //        uploadFolder = Server.MapPath("UploadFiles/Property_Icons/");
                //        flpAddImage.SaveAs(uploadFolder + flpAddImage.FileName);
                //        image = _expressToolService.ImageUpload(uploadFolder, flpAddImage, StaticDataTool.getPropertyIconWidth(), StaticDataTool.getPropertyIconHeight(), "");
                //    }
                //    else
                //    {
                //        lblAddImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                //        lblAddImageError.Visible = true;
                //        return;
                //    }
                //}

                _propertyService.Add(new Property()
                {
                    Name = txtAddName.Text,
                    Icon = "-", //txtAddIcon.Text,
                    PropertyGroupId = Convert.ToInt32(ddlAdd_PropertyGroup.SelectedValue),
                    SequenceNumber = 0
                });


                txtAddName.Text = "";
                //txtAddIcon.Text = "";
                ddlAdd_PropertyGroup.SelectedIndex = 0;

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
        protected void btnUpdateSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(hfId.Value);
                var property = _propertyService.GetById(id);

                //string image = "Default.jpg";

                //if (flpUpdateImage.HasFile)
                //{
                //    int fileSize = Convert.ToInt32(flpUpdateImage.PostedFile.ContentLength);
                //    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                //    {
                //        string uploadFolder = "";
                //        uploadFolder = Server.MapPath("UploadFiles/Property_Icons/");

                //        flpUpdateImage.SaveAs(uploadFolder + flpUpdateImage.FileName);

                //        _expressToolService.FileDelete(uploadFolder, property.Name);

                //        image = _expressToolService.ImageUpload(uploadFolder, flpUpdateImage, StaticDataTool.getPropertyIconWidth(), StaticDataTool.getPropertyIconHeight(), "");
                //    }
                //    else
                //    {
                //        lblUpdateImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                //        lblUpdateImageError.Visible = true;
                //        return;
                //    }
                //}


                property.Name = txtUpdateName.Text;
                //property.Icon = txtUpdateIcon.Text;
                property.PropertyGroupId = Convert.ToInt32(ddlUpdate_ProperyGroup.SelectedValue);

                _propertyService.Update(property);

                txtUpdateName.Text = "";
                txtUpdateName.Text = "";
                ddlUpdate_ProperyGroup.SelectedIndex = 0;

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }


        protected void rptPropertyList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Delete")
                {
                    var property = _propertyService.GetById(Convert.ToInt32(e.CommandArgument));

                    //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Property_Icons/"), property.Name);

                    _propertyService.Delete(property);
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
        public static Property GetProperty(int propertyId)
        {
            IPropertyService _propertyService;
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();
            var data = _propertyService.GetById(propertyId);
            return data;
        }
    }
}