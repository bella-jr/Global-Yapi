using System;
using KZ.Business.Abstract;
using KZ.Core;
using KZ.Entity.Models.Data;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ExternalArticleAdd : System.Web.UI.Page
    {
        private IExtarnelArticleService _extarnelArticleService;
        private IGalleryService _galleryService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICkEditorService _ckEditorService;
        private ICookieService _cookieService;

        public ExternalArticleAdd()
        {
            _extarnelArticleService = InstanceFactory.GetInstance<IExtarnelArticleService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();
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
                var galleries = _galleryService.GetAll_UIControl();

                _ckEditorService.StandartAyarlar(ckeDescription, "/Management/UploadFiles/Editor_Files/");
                _formControlService.GenerateDropdownList(galleries, ddlGallery);
            }
            catch
            {
                return;
            }
        }

        //Otomatik olarak yazı başlığını replace edip link haline getirmektedir.
        protected void txtTitle_OnTextChanged(object sender, EventArgs e)
        {
            txtLink.Text = Tools.UrlSeo(txtTitle.Text.Trim());
            txtLink.Enabled = true;
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (_extarnelArticleService.GetArticleControl(txtLink.Text))
                {
                    var language = _cookieService.GetSessionAdmin();

                    //Yazı bilgileri ekleme işlemini gerçekleştirmektedir.
                    _extarnelArticleService.Add(new ExternalArticle()
                    {
                        Title = txtTitle.Text.Trim(),
                        Description = ckeDescription.Text.Trim(),
                        IsStatus = cbStatus.Checked,
                        IsGoogleIndex = cbGoogleIndex.Checked,
                        Link = txtLink.Text.Trim(),
                        GalleryId = Convert.ToInt32(ddlGallery.SelectedValue),
                        LanguageId = language.LanguageId,
                        SeoTitle = txtSeoTitle.Text.Trim(),
                        SeoDescription = txtSeoDescription.Text.Trim(),
                        SeoKeywords = txtSeoKeyword.Text.Trim(),
                        CreationDate = DateTime.Now
                    });

                    _expressToolService.ClearTextboxDropdownCheckbox(pnlContent);

                    ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("success");

                }
                else
                {
                    lblMessage.Text = "Uyarı! Bu linke ait bir kayıt bulunmaktadır. Lütfen farklı bir link oluşturunuz.";
                    return;
                }
            }
            catch
            {
                ltlMessage.Text = _expressToolService.AdminLabelAlertMessage("danger");
            }
        }

        protected void txtLink_OnTextChanged(object sender, EventArgs e)
        {
            txtLink.Text = Tools.UrlSeo(txtLink.Text.Trim());
        }
    }
}