using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Core;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Management
{
    public partial class ExternalArticleUpdate : System.Web.UI.Page
    {
        private IExtarnelArticleService _extarnelArticleService;
        private IGalleryService _galleryService;
        private IExpressToolService _expressToolService;
        private IFormControlService _formControlService;
        private ICkEditorService _ckEditorService;

        public ExternalArticleUpdate()
        {
            _extarnelArticleService = InstanceFactory.GetInstance<IExtarnelArticleService>();
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
            _expressToolService = WebUIInstanceFactory.GetInstance<IExpressToolService>();
            _formControlService = WebUIInstanceFactory.GetInstance<IFormControlService>();
            _ckEditorService = WebUIInstanceFactory.GetInstance<ICkEditorService>();

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
                int id = Convert.ToInt32(RouteData.Values["articleId"]);
                var article = _extarnelArticleService.GetById(id);
                var galleries = _galleryService.GetAll_UIControl();

                _ckEditorService.StandartAyarlar(ckeDescription, "/Management/UploadFiles/Editor_Files/");
                _formControlService.GenerateDropdownList(galleries, ddlGallery);

                txtTitle.Text = article.Title;
                ckeDescription.Text = article.Description;
                cbStatus.Checked = article.IsStatus;
                cbGoogleIndex.Checked = article.IsGoogleIndex;
                txtLink.Text = article.Link;
                ddlGallery.SelectedValue = article.GalleryId.ToString();
                txtSeoTitle.Text = article.SeoTitle;
                txtSeoDescription.Text = article.SeoDescription;
                txtSeoKeyword.Text = article.SeoKeywords;
            }
            catch
            {
                return;
            }
        }

        protected void txtLink_OnTextChanged(object sender, EventArgs e)
        {
            txtLink.Text = Tools.UrlSeo(txtLink.Text.Trim());
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(RouteData.Values["articleId"]);
                var article = _extarnelArticleService.GetById(id);
                var articleControl = _extarnelArticleService.GetArticleControl(txtLink.Text);

                if (articleControl || article.Link == txtLink.Text.Trim())
                {

                    article.Title = txtTitle.Text.Trim();
                    article.Description = ckeDescription.Text.Trim();
                    article.IsStatus = cbStatus.Checked;
                    article.IsGoogleIndex = cbGoogleIndex.Checked;
                    article.Link = txtLink.Text;
                    article.GalleryId = Convert.ToInt32(ddlGallery.SelectedValue);
                    article.SeoTitle = txtSeoTitle.Text.Trim();
                    article.SeoDescription = txtSeoDescription.Text.Trim();
                    article.SeoKeywords = txtSeoKeyword.Text.Trim();

                    _extarnelArticleService.Update(article);

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
    }
}