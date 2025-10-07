using System;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Enums;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.Tool;

namespace KZ.WebUI.Management
{
    public partial class MenuList : System.Web.UI.Page
    {
        private IMenuService _menuService;
        private IProductMenuService _productMenuService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICookieService _cookieService;

        public MenuList()
        {
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _productMenuService = InstanceFactory.GetInstance<IProductMenuService>();
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
                var sessionUser = _cookieService.GetSessionAdmin();
                var menus = _menuService.GetAll(sessionUser.LanguageId);

                ddlMenuList1.Items.Add(new ListItem() { Text = "Üst Menü Yok", Value = "0" });
                ddlMenuList2.Items.Add(new ListItem() { Text = "Üst Menü Yok", Value = "0" });

                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList1);
                _formControlService.DropDownMenuLoad(menus, 0, 0, ddlMenuList2);
            }
            catch
            {
                return;
            }
        }

        protected void cbExternalLink_OnCheckedChanged(object sender, EventArgs e)
        {
            txtLink.Enabled = cbExternalLink.Checked;
        }

        protected void ddlMenuList1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMenuList1.SelectedIndex == 0)
            {
                pnlUpdateContent.Enabled = false;
                _expressToolService.ClearTextboxDropdownCheckbox(pnlUpdateContent);
                return;
            }

            var data = _menuService.GetById(Convert.ToInt32(ddlMenuList1.SelectedValue));
            if (data != null)
            {
                pnlUpdateContent.Enabled = true;

                ltlImage.Text = "<img src=\"UploadFiles/Menu_Images/" + data.Image + "\" width=\"150\" />";

                txtName.Text = data.Name;
                ddlMenuList2.SelectedValue = data.MainMenuId.ToString();
                cbExternalLink.Checked = data.IsExternal;
                txtLink.Text = data.Link;
                txtLink.Enabled = cbExternalLink.Checked;
                cbIsTarget.Checked = data.IsTarget;
                //cbIsProduct.Checked = data.IsProduct;
                //cbIsHome.Checked = data.IsHome;
                //cbIsHome2.Checked = data.IsHome2;
                //cbIsDetailPage.Checked = data.IsDetailPage;
                //cbIsOtherService.Checked = data.IsOtherService;
                //cbIsForm.Checked = data.IsForm;
                //cbIsGrades.Checked = data.IsGrades;
                //cbIsHomeDefaultSelected.Checked = data.IsHomeDefaultSelected;
                //cbIsMega.Checked = data.IsMega;
                //cbIsHeaderAccordion.Checked = data.IsHeaderAccordion;
                //cbIsMainHeaderAccordion.Checked = data.IsHeaderMainAccordion;
                //cbIsSidebar.Checked = data.IsSidebar;
                //cbIsHeader.Checked = data.IsHeader;
                //cbIsMegaSubView.Checked = data.IsMegaSubView;
                cbIsFooter.Checked = data.IsFooter;
                cbIsFooter2.Checked = data.IsFooter2;
                cbIsSubMenuListView.Checked = data.IsSubMenuListView;
                cbIsHeaderTop.Checked = data.IsHeader;
                ddlMenuType.SelectedValue = data.TypeId.ToString();
                //txtSeoDescription.Text = data.SeoDescription;
                //txtDescription.Text = data.Description;

                //cbIsHeaderLeft.Checked = data.IsLeftView;
                //cbIsHeaderRight.Checked = data.IsRightView;
            }
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                var menu = _menuService.GetById(Convert.ToInt32(ddlMenuList1.SelectedValue));

                //Eğer yüklenecenek bir resim seçilmiş ise haber resmi yükleme işlemini gerçekleştirmektedir.
                if (flpImage.HasFile)
                {
                    int fileSize = Convert.ToInt32(flpImage.PostedFile.ContentLength);
                    if (fileSize <= StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum
                    {
                        string uploadFolder = "";
                        uploadFolder = Server.MapPath("UploadFiles/Menu_Images/");
                        flpImage.SaveAs(uploadFolder + flpImage.FileName);

                        _expressToolService.FileDelete(uploadFolder, menu.Image);

                        menu.Image = _expressToolService.ImageUpload(uploadFolder, flpImage, StaticDataTool.getCategoryImageWidth(), StaticDataTool.getCategoryImageHeight(), "");
                    }
                    else
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yüklebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }
                }

                menu.Name = txtName.Text.Trim();
                menu.MainMenuId = Convert.ToInt32(ddlMenuList2.SelectedValue);
                menu.IsExternal = cbExternalLink.Checked;
                menu.IsFooter = cbIsFooter.Checked;
                menu.IsFooter2 = cbIsFooter2.Checked;
                menu.Link = cbExternalLink.Checked ? txtLink.Text.Trim() : "#";
                menu.IsTarget = cbIsTarget.Checked;
                //menu.IsHome = cbIsHome.Checked;
                //menu.IsHome2 = cbIsHome2.Checked;
                //menu.IsProduct = cbIsProduct.Checked;
                //menu.IsDetailPage = cbIsDetailPage.Checked;
                //menu.IsOtherService = cbIsOtherService.Checked;
                //menu.IsForm = cbIsForm.Checked;
                //menu.IsGrades = cbIsGrades.Checked;
                //menu.IsHomeDefaultSelected = cbIsHomeDefaultSelected.Checked;
                //menu.IsHeaderAccordion = cbIsHeaderAccordion.Checked;
                //menu.IsHeaderMainAccordion = cbIsMainHeaderAccordion.Checked;
                //menu.IsSidebar = cbIsSidebar.Checked;
                //menu.IsHeader = cbIsHeaderTop.Checked;
                menu.IsSubMenuListView = cbIsSubMenuListView.Checked;
                //menu.IsMega = cbIsMega.Checked;
                //menu.IsMegaSubView = cbIsMegaSubView.Checked;
                menu.TypeId = Convert.ToByte(ddlMenuType.SelectedValue);
                //menu.SeoDescription = txtSeoDescription.Text;
                menu.IsHeaderTop = cbIsHeaderTop.Checked;
                //menu.Description = txtDescription.Text.Trim();
                //menu.IsLeftView = cbIsHeaderLeft.Checked;
                //menu.IsRightView = cbIsHeaderRight.Checked;

                _menuService.Update(menu);

                Success();
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        private void Success()
        {
            ddlMenuList1.Items.Clear();
            ddlMenuList2.Items.Clear();

            //Application.Remove("sahinKirtasiye_HeaderMenu");
            //Application.Remove("sahinKirtasiye_MobileMenu");
            //Application.Remove("sahinKirtasiye_FooterMenu");

            LoadData();

            pnlUpdateContent.Enabled = false;

            _expressToolService.ClearTextboxDropdownCheckbox(pnlUpdateContent);

            ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
        }

        //Menü silme işlemini gerçekleştirmektedir.
        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("UploadFiles/Menu_Images/");

                if (ddlMenuList1.SelectedIndex == 0)
                    return;

                //Bir menüyü alt menüleri ile beraber silme işlemini gerçekleştirmektedir.
                int id = Convert.ToInt32(ddlMenuList1.SelectedValue);
                var subMenuList = _menuService.GetAll_SubList(id);
                if (subMenuList.Count != 0)
                    foreach (var item in subMenuList)
                    {
                        _expressToolService.FileDelete(path, item.Image);
                        _menuService.Delete(item);
                    }


                //Tek bir menüyü silme işlemini gerçekleştirmektedir.
                var menu = _menuService.GetById(id);
                _expressToolService.FileDelete(path, menu.Image);
                _menuService.Delete(menu);


                //Ürünlere ait olan kategorileri silme işlemini gerçekleştirmektedir.
                if (menu.TypeId == (byte)MenuType.Kategori)
                {
                    var productMenu = _productMenuService.GetById(menu.Id);
                    foreach (var item in productMenu)
                        _productMenuService.Delete(item);
                }

                Success();
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }
    }
}