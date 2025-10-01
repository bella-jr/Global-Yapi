using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ProductList : Page
    {
        private IProductService _productService;
        private IProductImageService _productImageService;
        private IExpressToolService _expressToolService;
        private ICookieService _cookieService;

        public ProductList()
        {
            _productService = InstanceFactory.GetInstance<IProductService>();
            _productImageService = InstanceFactory.GetInstance<IProductImageService>();
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
                var sessionAdmin = _cookieService.GetSessionAdmin();
                var products = _productService.GetAll(sessionAdmin.LanguageId);

                rptProductList.DataSource = products;
                rptProductList.DataBind();
            }
            catch
            {
                return;
            }
        }

        protected void rptProductList_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                var product = _productService.GetById(Convert.ToInt32(e.CommandArgument));

                if (e.CommandName == "Delete")
                {
                    var productImages = _productImageService.GetAll(product.Id);

                    foreach (var item in productImages)
                    {
                        //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Thumb_"), item.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Small_"), item.Image);
                        //_expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Medium_"), item.Image);
                        _expressToolService.FileDelete(Server.MapPath("UploadFiles/Product_Images/Big_"), item.Image);
                        
                        _productImageService.Delete(item);
                    }

                    _productService.Delete(product);
                }

                else if (e.CommandName == "Active")
                {
                    product.IsStatus = false;
                    _productService.Update(product);
                }

                else if (e.CommandName == "Pasive")
                {
                    product.IsStatus = true;
                    _productService.Update(product);
                }

                LoadData();
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        //Aktif-Pasif butonlarını ilgili durumlara göre listeleme işlemeini gerçekeştirmektedir.
        protected void rptProductList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            _expressToolService.Status("hfStatus", "btnActive", "btnPasive", e, rptProductList);
        }
    }
}