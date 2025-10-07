using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.Tool;

namespace KZ.WebUI.Management
{
    public partial class MenuAdd : System.Web.UI.Page
    {
        private IMenuService _menuService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICookieService _cookieService;

        public MenuAdd()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
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
                var sessionAdmin = _cookieService.GetSessionAdmin();
                var menus = _menuService.GetAll(sessionAdmin.LanguageId);

                ddlMenuList.Items.Add(new ListItem() { Text = "Üst Menü Yok", Value = "0" });
                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList);
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
                var cookieAdmin = _cookieService.GetSessionAdmin();

                if (cbExternalLink.Checked && String.IsNullOrEmpty(txtLink.Text.Trim()))
                {
                    lblLinkMessage.Text = "Lütfen gerekli alanı doldurunuz.";
                    return;
                }

                lblLinkMessage.Text = "";

                string image = "Default.jpg";

                if (flpImage.HasFile)
                {
                    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                    {
                        string uploadFolder = "";
                        uploadFolder = Server.MapPath("UploadFiles/Menu_Images/");
                        flpImage.SaveAs(uploadFolder + flpImage.FileName);
                        image = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getCategoryImageWidth(), StaticDataTool.getCategoryImageHeight(), "");
                    }
                    else
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }
                }

                _menuService.Add(new Entity.Models.Data.Menu()
                {
                    Name = txtName.Text.Trim(),
                    Image = image,
                    MainMenuId = Convert.ToInt32(ddlMenuList.SelectedValue),
                    IsExternal = cbExternalLink.Checked,
                    IsFooter = cbIsFooter.Checked,
                    IsFooter2 = cbIsFooter2.Checked,
                    Link = cbExternalLink.Checked ? txtLink.Text.Trim() : "#",
                    IsTarget = cbIsTarget.Checked,
                    IsProduct = false,/* cbIsProduct.Checked,*/
                    IsHome = false, //cbIsHome.Checked,
                    IsHome2 = false, //cbIsHome2.Checked,
                    IsForm = false /*cbIsForm.Checked*/,
                    IsGrades = false /*cbIsGrades.Checked*/,
                    IsDetailPage = /*cbIsDetailPage.Checked,*/ false,
                    IsOtherService = false, /*cbIsOtherService.Checked,*/
                    IsHomeDefaultSelected = false, //cbIsHomeDefaultSelected.Checked,
                    IsMega = false,
                    MegaItemCount = 4,//cbIsMega.Checked && ddlMenuList.SelectedIndex == 0 ? 9 : 0,
                    IsHeaderAccordion = false, //cbIsHeaderAccordion.Checked,
                    IsHeaderMainAccordion = false,//cbIsMainHeaderAccordion.Checked,
                    IsSidebar = false, //cbIsSidebar.Checked,
                    IsHeader = cbIsHeaderTop.Checked,
                    IsLeftView = false, //cbIsHeaderLeft.Checked,
                    IsRightView = false, //cbIsHeaderRight.Checked,
                    IsMegaSubView = false,
                    IsHeaderTop = false,
                    IsSubMenuListView = cbIsSubMenuListView.Checked,
                    TypeId = Convert.ToByte(ddlMenuType.SelectedValue),
                    LanguageId = cookieAdmin.LanguageId,
                    SequenceNumber = 0,
                    SeoDescription = "-", //txtSeoDescription.Text,
                    Description = "-", //txtDescription.Text
                });

                _expressToolService.ClearTextboxDropdown(pnlContent);

                ddlMenuList.Items.Clear();

                //Application.Remove("sahinKirtasiye_HeaderMenu");
                //Application.Remove("sahinKirtasiye_MobileMenu");
                //Application.Remove("sahinKirtasiye_FooterMenu");

                LoadData();

                cbExternalLink.Checked = false;
                txtLink.Enabled = false;

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void cbExternalLink_OnCheckedChanged(object sender, EventArgs e)
        {
            txtLink.Text = "";
            txtLink.Enabled = cbExternalLink.Checked;
        }

    }
}