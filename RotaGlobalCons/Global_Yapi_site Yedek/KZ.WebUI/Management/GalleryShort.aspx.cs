using System;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI.Management
{
    public partial class GalleryShort : System.Web.UI.Page
    {
        private IGalleryService _galleryService;

        public GalleryShort()
        {
            _galleryService = InstanceFactory.GetInstance<IGalleryService>();
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
                var gallerys = _galleryService.GetAll();

                rptGalleryList.DataSource = gallerys;
                rptGalleryList.DataBind();
            }
            catch
            {
                return;
            }
        }
    }
}