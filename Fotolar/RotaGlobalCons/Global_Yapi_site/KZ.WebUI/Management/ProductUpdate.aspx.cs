using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool;
using KZ.WebUI.Tool.Abstract;
using KZ.Entity.Enums;
using System.Linq;

namespace KZ.WebUI.Management
{
    public partial class ProductUpdate : Page
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

        public ProductUpdate()
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
                int productId = Convert.ToInt32(RouteData.Values["id"]);
                var sessionUser = _cookieService.GetSessionAdmin();
                var tabFilters = _tabFilterService.GetAll(sessionUser.LanguageId);
                var propertyGroups = _propertyGroupService.GetAll_UIControl(sessionUser.LanguageId);
                var menus = _menuService.GetAllType((byte)MenuType.Kategori, sessionUser.LanguageId);
                var product = _productService.GetById(productId);

                hfProductId.Value = productId.ToString();

                //var references = _referenceService.GetAll(sessionUser.LanguageId, true);
                //_formControlService.GenerateDropdownList(references, ddlReferenceList, text: "Title");
                _formControlService.GenerateDropdownList(propertyGroups, ddlPropertyGroup);
                //_formControlService.GenerateListbox(tabFilters, lstTabFilter);

                lstCategories.Items.Add(new ListItem() { Text = "-Seçim Yapınız-", Value = "0" });

                _formControlService.CategoriesListBoxLoad(menus, 0, 0, lstCategories);

                //Ürün bilgilerini listeleme işlemini gerçekleştirmektedir.
                //txtCode.Text = product.Code;
                txtTopTitle.Text = product.TopTitle;
                txtTitle.Text = product.Title;

                ckeDescription1.Text = product.Description1;
                ckeDescription2.Text = product.Description2;
                //ddlMoneyType.SelectedValue = product.MoneyTypeId.ToString();
                //txtPrice.Text = product.Price.ToString("N");
                //txtOldPrice.Text = product.Old_Price.ToString("N");
                //txtHavalePrice.Text = product.Havale_Price.ToString("N");

                //txtDiscount.Text = product.Discount;
                //txtStartQuantity.Text = product.StartQuantity.ToString();
                cbStatus.Checked = product.IsStatus;
                cbIsHome.Checked = product.IsHome;
                //cbIsPopular.Checked = product.IsPopular;
                //cbIsNew.Checked = product.IsNew;
                //cbIsStock.Checked = product.IsStock;
                //cbIsMadeInTurkey.Checked = product.IsMadeInTurkey;
                //cbIsSoon.Checked = product.IsSoon;
                //cbIsDiscount.Checked = product.IsDiscount;
                //ddlReferenceList.SelectedValue = product.ReferenceId.ToString();
                txtSeoTitle.Text = product.SeoTitle;
                txtSeoDescription.Text = product.SeoDescription;
                txtSeoKeyword.Text = product.SeoKeywords;

                //Ürün kategorilerini seçili getirme işlemini gerçekleştirmektedir.
                var selectedProductMenu = _productMenuService.GetAll_ProductId(productId);
                foreach (var productMenu in selectedProductMenu)
                    lstCategories.Items.FindByValue(productMenu.MenuId.ToString()).Selected = true;

                //Tab filtrelerini seçili getirme işlemini gerçekleştirmektedir.
                //var tabFilterProduct = _tabFilterProductService.GetAll_ProductId(productId);
                //if (tabFilterProduct.Count > 0)
                //{
                //    foreach (var item in tabFilterProduct)
                //    {
                //        var filter = _tabFilterService.GetById(item.TabFilterId);
                //        ListItem listitem = new ListItem()
                //        {
                //            Text = filter.Name,
                //            Value = filter.Id.ToString()
                //        };

                //        lstTabFilter.Items.Remove(listitem);
                //        lstSelectedTabFilter.Items.Add(listitem);
                //    }
                //}

                int groupId = 0;
                var productProperty = _productPropertyService.GetByProductId(productId);
                if (productProperty.Count > 0)
                    groupId = productProperty.FirstOrDefault().GrupId;

                ddlPropertyGroup.SelectedValue = "1";

                var properties = _propertyService.GetAll_GroupId(groupId);

                rptPropertyList.DataSource = properties;
                rptPropertyList.DataBind();

                for (int i = 0; i < rptPropertyList.Items.Count; i++)
                {
                    HiddenField hfPropertyId = (HiddenField)rptPropertyList.Items[i].FindControl("hfPropertyId");
                    TextBox txtPropertyValue = (TextBox)rptPropertyList.Items[i].FindControl("txtPropertyValue");

                    var control = _productPropertyService.GetByProductId(Convert.ToInt32(hfPropertyId.Value), productId);

                    if (control != null)
                        txtPropertyValue.Text = control.Value;
                }

                ProductImageLoad(productId, _productImageService);


            }
            catch
            {
                return;
            }
        }

        //Ürün resimlerinin listelenme işlemini gerçekleştirmektedir.
        private void ProductImageLoad(int productId, IProductImageService productImageService)
        {
            rptProductImageList.DataSource = productImageService.GetAll_Join(productId);
            rptProductImageList.DataBind();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                var product = _productService.GetById(id);

                string filterParameter = "0";
                //Ürün tab filtrelerini ekleme işlemini gerçekleştirmektedir.
                //if (lstSelectedTabFilter.Items.Count > 0)
                //{
                //    filterParameter = "";
                //    foreach (ListItem item in lstSelectedTabFilter.Items)
                //        filterParameter += item.Value + " ";
                //}

                //Ürün genel bilgilerini güncelleme işlemini gerçekleştirmektedir.
                //product.Code = String.IsNullOrEmpty(txtCode.Text) ? "0" : txtCode.Text.Trim();
                product.Title = txtTitle.Text.Trim();
                product.TopTitle = txtTopTitle.Text.Trim();
                //product.Price = String.IsNullOrEmpty(txtPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtPrice.Text.Trim());
                //product.Havale_Price = String.IsNullOrEmpty(txtHavalePrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtHavalePrice.Text.Trim());
                //product.Old_Price = String.IsNullOrEmpty(txtOldPrice.Text.Trim()) ? 0 : Convert.ToDecimal(txtOldPrice.Text.Trim());

                //product.Discount = String.IsNullOrEmpty(txtDiscount.Text.Trim()) ? "0" : txtDiscount.Text.Trim();
                //product.StartQuantity = Convert.ToInt32(txtStartQuantity.Text.Trim());
                product.Description1 = ckeDescription1.Text;
                product.Description2 = ckeDescription2.Text;
                product.IsStatus = cbStatus.Checked;
                //product.IsPopular = cbIsPopular.Checked;
                //product.IsNew = cbIsNew.Checked;
                product.IsDiscount = false;
                product.IsHome = cbIsHome.Checked;
                //product.IsStock = cbIsStock.Checked;
                //product.IsMadeInTurkey = cbIsMadeInTurkey.Checked;
                //product.IsSoon = cbIsSoon.Checked;
                //product.ReferenceId = Convert.ToInt32(ddlReferenceList.SelectedValue);
                product.SeoTitle = txtSeoTitle.Text.Trim();
                product.SeoDescription = String.IsNullOrEmpty(txtSeoDescription.Text) ? txtSeoTitle.Text : txtSeoDescription.Text;
                product.SeoKeywords = txtSeoKeyword.Text.Trim();

                _productService.Update(product);


                //Ürün kategorilerini silme işlemini gerçekleştirmektedir.
                var productCategory = _productMenuService.GetAll_ProductId(id);
                if (productCategory.Count > 0)
                {
                    foreach (var item in productCategory)
                        _productMenuService.Delete(item);
                }


                //Ürün kategorilerini ekleme işlemini gerçekleştirmektedir.
                var selectedCategory = lstCategories.Items.Cast<ListItem>().Where(li => li.Selected).Select(li => li.Value).ToList();
                if (selectedCategory.Count > 0)
                {
                    foreach (var category in selectedCategory)
                    {
                        if (category != "0")
                            _productMenuService.Add(new ProductMenu() { MenuId = Convert.ToInt32(category), ProductId = product.Id });
                    }
                }


                //Ürün özelliklerini silme işlemini gerçekleştirmektedir.
                var productProperty = _productPropertyService.GetAll(id);
                if (productProperty.Count > 0)
                {
                    foreach (var item in productProperty)
                        _productPropertyService.Delete(item);
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

                //Ürün filterlerini silme işlemini gerçekleştirmektedir.
                //var tabFilterProduct = _tabFilterProductService.GetAll_ProductId(id);
                //if (tabFilterProduct.Count > 0)
                //{
                //    foreach (var item in tabFilterProduct)
                //        _tabFilterProductService.Delete(item);
                //}

                //Ürün tab filtrelerini ekleme işlemini gerçekleştirmektedir.
                //if (lstSelectedTabFilter.Items.Count > 0)
                //{
                //    foreach (ListItem item in lstSelectedTabFilter.Items)
                //    {
                //        int tabFilterId = Convert.ToInt32(item.Value);
                //        var tabFilterControl = _tabFilterProductService.GetById(tabFilterId, id);

                //        if (tabFilterControl == null)
                //        {
                //            _tabFilterProductService.Add(new TabFilterProduct()
                //            {
                //                ProductId = product.Id,
                //                TabFilterId = tabFilterId
                //            });
                //        }
                //    }
                //}


                lstCategories.Items.Clear();
                ddlPropertyGroup.Items.Clear();
                //lstSelectedTabFilter.Items.Clear();
                //lstTabFilter.Items.Clear();

                LoadData();

                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void rptProductImageList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var productImage = _productImageService.GetById(Convert.ToInt32(e.CommandArgument));

                //Ürün resmini silme işlemini gerçekleştirmektedir.
                if (e.CommandName == "Delete")
                {
                    //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Thumb_"), productImage.Image);
                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Small_"), productImage.Image);
                    //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Medium_"), productImage.Image);
                    _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Big_"), productImage.Image);
                    _productImageService.Delete(productImage);
                }

                //Seçilen resmi kapak resmi yapma işlemini gerçekleştirmektedir.
                else if (e.CommandName == "CoverImage")
                {
                    var productUpdate = _productService.GetById(productImage.ProductId);
                    productUpdate.Image = productImage.Image;
                    _productService.Update(productUpdate);
                }

                //Seçilen resmi 2. kapak resmi yapma işlemini gerçekleştirmektedir.
                else if (e.CommandName == "CoverImage2")
                {
                    var productUpdate = _productService.GetById(productImage.ProductId);
                    productUpdate.Image2 = productImage.Image;
                    _productService.Update(productUpdate);
                }

                ProductImageLoad(productImage.ProductId, _productImageService);
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Ürün resimleri yükleme işlemini gerçekleştirmektedir.
        protected void btnProductPhotoUpload_OnClick(object sender, EventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(RouteData.Values["id"]);

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
                        ProductId = productId,
                        SequenceNumber = 0
                    });

                    //Ürüne varsayılan resmi kapak resmi yapma işlemini gerçekleştirmektedir.
                    if (isDefaultImage == false)
                    {
                        var productUpdate = _productService.GetById(productId);
                        productUpdate.Image = guid + ".jpg";
                        _productService.Update(productUpdate);
                        isDefaultImage = true;
                    }
                }

                ProductImageLoad(productId, _productImageService);
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Tüm ürün resimlerini silme işlemini gerçekleştirmektedir.
        protected void btnAllDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(RouteData.Values["id"]);
                var productImages = _productImageService.GetAll(id);
                if (productImages.Count > 0)
                {
                    foreach (var item in productImages)
                    {
                        //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Thumb_"), item.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Small_"), item.Image);
                        //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Medium_"), item.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Big_"), item.Image);
                        _productImageService.Delete(item);
                    }

                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Yalnızca seçilen ürün resimlerini silme işlemini gerçekleştirmektedir.
        protected void btnSelectedAllDelete_OnClick(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem item in rptProductImageList.Items)
                {
                    HtmlInputCheckBox chkDisplayTitle = (HtmlInputCheckBox)item.FindControl("chkDisplayTitle");
                    if (chkDisplayTitle.Checked)
                    {
                        var productImage = _productImageService.GetById(Convert.ToInt32(chkDisplayTitle.Value));

                        //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Thumb_"), productImage.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Small_"), productImage.Image);
                        //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Medium_"), productImage.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Big_"), productImage.Image);

                        _productImageService.Delete(productImage);
                    }
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
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