using System;
using System.IO;
using System.Web;
using System.Web.UI;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;
using System.Web.UI.WebControls;
using System.Linq;
using KZ.Entity.Enums;

namespace KZ.WebUI.Management
{
    public partial class ProductAdd : Page
    {
        private IProductService _productService;
        private IProductImageService _productImageService;
        //private IReferenceService _referenceService;
        private IProductMenuService _productMenuService;
        private IProductPropertyService _productPropertyService;
        private IMenuService _menuService;
        private IPropertyGroupService _propertyGroupService;
        private ITabFilterService _tabFilterService;
        private ITabFilterProductService _tabFilterProductService;
        private IPropertyService _propertyService;
        private IFormControlService _formControlService;
        private IExpressToolService _expressToolService;
        //private ICkEditorService _ckEditorService;
        private ICookieService _cookieService;


        public ProductAdd()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _productImageService = InstanceFactory.GetInstance<IProductImageService>();
            //_referenceService = InstanceFactory.GetInstance<IReferenceService>();
            _productMenuService = InstanceFactory.GetInstance<IProductMenuService>();
            _productPropertyService = InstanceFactory.GetInstance<IProductPropertyService>();
            _menuService = InstanceFactory.GetInstance<IMenuService>();
            _propertyGroupService = InstanceFactory.GetInstance<IPropertyGroupService>();
            _tabFilterService = InstanceFactory.GetInstance<ITabFilterService>();
            _tabFilterProductService = InstanceFactory.GetInstance<ITabFilterProductService>();
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            //_ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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
                //var references = _referenceService.GetAll(language.LanguageId, true);
                var tabFilters = _tabFilterService.GetAll(language.LanguageId);
                var propertyGroups = _propertyGroupService.GetAll_UIControl(language.LanguageId);

                //_formControlService.GenerateDropdownList(references, ddlReferenceList, text: "Title");
                _formControlService.GenerateDropdownList(propertyGroups, ddlPropertyGroup);
                //_formControlService.GenerateListbox(tabFilters, lstTabFilter);

                lstCategories.Items.Add(new ListItem() { Text = "-Seçim Yapınız-", Value = "0" });
                _formControlService.CategoriesListBoxLoad(_menuService.GetAllType((byte)MenuType.Kategori, language.LanguageId), 0, 0, lstCategories);

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
                //Ürün genel bilgilerini ekleme işlemini gerçekleştirmektedir.

                var cookieAdmin = _cookieService.GetSessionAdmin();
                var product = new Product();

                product.Code = "0";//String.IsNullOrEmpty(txtCode.Text) ? "0" : txtCode.Text.Trim();
                product.Title = txtTitle.Text.Trim();
                product.TopTitle = txtTopTitle.Text.Trim();
                product.Price = 0; //String.IsNullOrEmpty(txtPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtPrice.Text.Trim());
                product.Havale_Price = 0; //String.IsNullOrEmpty(txtHavalePrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtHavalePrice.Text.Trim());
                product.Old_Price = 0; //String.IsNullOrEmpty(txtOldPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtOldPrice.Text.Trim());
                product.Discount = "0"; //String.IsNullOrEmpty(txtDiscount.Text.Trim()) ? "0" : txtDiscount.Text.Trim();
                product.StartQuantity = 1; //Convert.ToInt32(txtStartQuantity.Text.Trim());
                product.Image = "Default.jpg";
                product.Image2 = "Default.jpg";
                product.Description1 = ckeDescription1.Text;
                product.Description2 = ckeDescription2.Text;
                product.IsStatus = cbStatus.Checked;
                product.IsPopular = false; //cbIsPopular.Checked;
                product.IsNew = false;
                product.IsDiscount = false;
                product.IsHome = cbIsHome.Checked;
                product.IsStock = false;
                product.IsMadeInTurkey = false;
                product.IsSoon = false;
                product.LanguageId = cookieAdmin.LanguageId;
                product.ReferenceId = 0; //Convert.ToInt32(ddlReferenceList.SelectedValue);
                product.SeoTitle = txtSeoTitle.Text.Trim();
                product.SeoDescription = String.IsNullOrEmpty(txtSeoDescription.Text) ? txtSeoTitle.Text : txtSeoDescription.Text;
                product.SeoKeywords = txtSeoKeyword.Text.Trim();
                product.CreationDate = DateTime.Now;
                _productService.Add(product);

                //Ürün kategorilerini ekleme işlemini gerçekleştirmektedir.

                var selectedCategory = lstCategories.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
                foreach (var category in selectedCategory)
                {
                    if (category != "0")
                        _productMenuService.Add(new ProductMenu() { MenuId = Convert.ToInt32(category), ProductId = product.Id });
                }


                //Ürün özelliklerini ekleme işlemini gerçekleştirmektedir.
                if (ddlPropertyGroup.SelectedIndex != 0)
                {
                    for (int i = 0; i < rptPropertyList.Items.Count; i++)
                    {
                        TextBox txtPropertyValue = (TextBox)rptPropertyList.Items[i].FindControl("txtPropertyValue");
                        HiddenField hfPropertyId = (HiddenField)rptPropertyList.Items[i].FindControl("hfPropertyId");
                        if (!String.IsNullOrEmpty(txtPropertyValue.Text))
                        {
                            _productPropertyService.Add(new ProductProperty()
                            {
                                ProductId = product.Id,
                                PropertyId = Convert.ToInt32(hfPropertyId.Value),
                                Value = txtPropertyValue.Text,
                                GrupId = Convert.ToInt32(ddlPropertyGroup.SelectedValue)
                            });
                        }
                    }
                }

                ////Ürün tab filtrelerini ekleme işlemini gerçekleştirmektedir.
                //if (lstSelectedTabFilter.Items.Count > 0)
                //{
                //    foreach (ListItem item in lstSelectedTabFilter.Items)
                //        _tabFilterProductService.Add(new TabFilterProduct()
                //        {
                //            ProductId = product.Id,
                //            TabFilterId = Convert.ToInt32(item.Value)
                //        });
                //}

                //Ürün resimlerini ekleme işlemini gerçekleştirmektedir.
                string folder = "", guid = "";
                bool isDefaultImage = false;
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];

                    if (userPostedFile.ContentLength == 0)
                        break;

                    if (userPostedFile.ContentLength > StaticDataTool.getPhotoUploadLimit()) //Max 5mb dosya yukleme sınırı koydum)
                    {
                        lblImageError.Text = "Maksimum " + StaticDataTool.getPhotoUploadSizeName() + " büyüklüğünde dosya yükleyebilirsiniz.";
                        lblImageError.Visible = true;
                        return;
                    }

                    folder = Server.MapPath("UploadFiles/Product_Images/");
                    userPostedFile.SaveAs(folder + Path.GetFileName(userPostedFile.FileName));

                    guid = Guid.NewGuid().ToString();

                    //_expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getProductThumbImageWidth(), StaticDataTool.getProductThumbImageHeight(), guid, "Thumb_");

                    _expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getProductSmallImageWidth(), StaticDataTool.getProductSmallImageHeight(), guid, "Small_");

                    //_expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getProductMediumImageWidth(), StaticDataTool.getProductMediumImageHeight(), guid, "Medium_");

                    _expressToolService.MultiImageUpload(folder, userPostedFile, StaticDataTool.getProductBigImageWidth(), StaticDataTool.getProductBigImageHeight(), guid, "Big_");

                    _expressToolService.FileDelete(folder, userPostedFile.FileName);

                    _productImageService.Add(new ProductImage()
                    {
                        Image = guid + ".jpg",
                        ProductId = product.Id,
                        SequenceNumber = 0
                    });

                    //Ürüne varsayılan resmi kapak resmi yapma işlemini gerçekleştirmektedir.
                    if (isDefaultImage == false)
                    {
                        var productUpdate = _productService.GetById(product.Id);
                        productUpdate.Image = guid + ".jpg";
                        _productService.Update(productUpdate);
                        isDefaultImage = true;
                    }
                }

                _expressToolService.SuccessAlertMessage(Page, "ProductAdd");
            }
            catch
            {
                _expressToolService.ErrorAlertMessage(Page, "#");
            }
        }

        protected void btnCompleted_OnClick(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("groupId");
            _expressToolService.SuccessAlertMessage(Page, "ProductAdd");
        }

        //protected void MoveRight(object sender, EventArgs e)
        //{
        //    while (lstTabFilter.Items.Count > 0 && lstTabFilter.SelectedItem != null)
        //    {
        //        ListItem selectedItem = lstTabFilter.SelectedItem;
        //        selectedItem.Selected = false;
        //        lstSelectedTabFilter.Items.Add(selectedItem);
        //        lstTabFilter.Items.Remove(selectedItem);
        //    }
        //}
        //protected void MoveLeft(object sender, EventArgs e)
        //{
        //    while (lstSelectedTabFilter.Items.Count > 0 && lstSelectedTabFilter.SelectedItem != null)
        //    {
        //        ListItem selectedItem = lstSelectedTabFilter.SelectedItem;
        //        selectedItem.Selected = false;
        //        lstTabFilter.Items.Add(selectedItem);
        //        lstSelectedTabFilter.Items.Remove(selectedItem);
        //    }
        //}

        protected void ddlPropertyGroup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int groupId = Convert.ToInt32(ddlPropertyGroup.SelectedValue);
            var properties = _propertyService.GetAll_GroupId(groupId);

            rptPropertyList.DataSource = properties;
            rptPropertyList.DataBind();
        }
    }
}