using System;
using System.Web.Routing;
using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;

namespace KZ.WebUI
{
    public class Global : System.Web.HttpApplication
    {
        private ISeoUrlRedirectService _seoUrlRedirectService;

        public Global()
        {
            _seoUrlRedirectService = InstanceFactory.GetInstance<ISeoUrlRedirectService>();
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.RawUrl;

            //if (Request.AppRelativeCurrentExecutionFilePath == "~/" || url == "/" || url == "/Default.aspx" || url == "/default.aspx")
            //    Response.Redirect("/tr");
            //else
            //{
            var seoUrl = _seoUrlRedirectService.Get(url);
            if (seoUrl != null)
            {
                Response.RedirectPermanent(seoUrl.NewUrl);
            }
            //}
        }

        public void RegisterRoutes(RouteCollection routes)
        {

            routes.MapPageRoute("ForgetPassword", "Management/ForgetPassword", "~/Management/ForgetPassword.aspx");
            routes.MapPageRoute("Dashboard", "Management/Dashboard", "~/Management/Dashboard.aspx");
            routes.MapPageRoute("Profile", "Management/Profile", "~/Management/Profile.aspx");

            //Yönetim Paneli
            routes.MapPageRoute("AdminEkle", "Management/AdminAdd", "~/Management/AdminAdd.aspx");
            routes.MapPageRoute("AdminListele", "Management/AdminList", "~/Management/AdminList.aspx");
            routes.MapPageRoute("AdminUpdate", "Management/AdminUpdate-{userId}", "~/Management/AdminUpdate.aspx");

            routes.MapPageRoute("Menu Ekle", "Management/MenuAdd", "~/Management/MenuAdd.aspx");
            routes.MapPageRoute("Menu Listele", "Management/MenuList", "~/Management/MenuList.aspx");
            routes.MapPageRoute("Menu Sıralam", "Management/MenuShort", "~/Management/MenuShort.aspx");

            routes.MapPageRoute("Yazı Ekle", "Management/ArticleAdd", "~/Management/ArticleAdd.aspx");
            routes.MapPageRoute("Yazı Listele", "Management/ArticleList", "~/Management/ArticleList.aspx");
            routes.MapPageRoute("Yazı Güncelle", "Management/ArticleUpdate-{menuId}", "~/Management/ArticleUpdate.aspx");

            routes.MapPageRoute("Galeri Ekle", "Management/GalleryAdd", "~/Management/GalleryAdd.aspx");
            routes.MapPageRoute("Galeri Listele", "Management/GalleryList", "~/Management/GalleryList.aspx");
            routes.MapPageRoute("Galeri Güncelle", "Management/GalleryUpdate-{galleryId}", "~/Management/GalleryUpdate.aspx");
            routes.MapPageRoute("Galeri Sıralama", "Management/GalleryShort", "~/Management/GalleryShort.aspx");

            routes.MapPageRoute("Yorum Ekle", "Management/CommentAdd", "~/Management/CommentAdd.aspx");
            routes.MapPageRoute("Yorum Listele", "Management/CommentList", "~/Management/CommentList.aspx");
            routes.MapPageRoute("Yorum Güncelle", "Management/CommentUpdate-{id}", "~/Management/CommentUpdate.aspx");

            routes.MapPageRoute("Bağımsız Yazı Ekle", "Management/ExternalArticleAdd", "~/Management/ExternalArticleAdd.aspx");
            routes.MapPageRoute("Bağımsız Yazı Listele", "Management/ExternalArticleList", "~/Management/ExternalArticleList.aspx");
            routes.MapPageRoute("Bağımsız Yazı Güncelle", "Management/ExternalArticleUpdate-{articleId}", "~/Management/ExternalArticleUpdate.aspx");

            routes.MapPageRoute("Blog Ekle", "Management/BlogAdd", "~/Management/BlogAdd.aspx");
            routes.MapPageRoute("Blog Listele", "Management/BlogList", "~/Management/BlogList.aspx");
            routes.MapPageRoute("Blog Güncelle", "Management/BlogUpdate-{blogId}", "~/Management/BlogUpdate.aspx");
            routes.MapPageRoute("Blog Sıralama", "Management/BlogShort", "~/Management/BlogShort.aspx");

            routes.MapPageRoute("Slider Ekle", "Management/SliderAdd", "~/Management/SliderAdd.aspx");
            routes.MapPageRoute("Slider Listele", "Management/SliderList", "~/Management/SliderList.aspx");
            routes.MapPageRoute("Slider Güncelle", "Management/SliderUpdate-{sliderId}", "~/Management/SliderUpdate.aspx");
            routes.MapPageRoute("Slider Sıralama", "Management/SliderShort", "~/Management/SliderShort.aspx");

            routes.MapPageRoute("Referans Ekle", "Management/ReferenceAdd", "~/Management/ReferenceAdd.aspx");
            routes.MapPageRoute("Referans Listele", "Management/ReferenceList", "~/Management/ReferenceList.aspx");
            routes.MapPageRoute("Referans Güncelle", "Management/ReferenceUpdate-{id}", "~/Management/ReferenceUpdate.aspx");
            routes.MapPageRoute("Referans Sıralama", "Management/ReferenceShort", "~/Management/ReferenceShort.aspx");

            routes.MapPageRoute("Referans Kategori Ekle", "Management/ReferenceCategoryAdd", "~/Management/ReferenceCategoryAdd.aspx");
            routes.MapPageRoute("Referans Kategori Listele", "Management/ReferenceCategoryList", "~/Management/ReferenceCategoryList.aspx");
            routes.MapPageRoute("Referans Kategori Güncelle", "Management/ReferenceCategoryUpdate-{id}", "~/Management/ReferenceCategoryUpdate.aspx");
            routes.MapPageRoute("Referans Kategori Sıralama", "Management/ReferenceCategoryShort", "~/Management/ReferenceCategoryShort.aspx");

            routes.MapPageRoute("SSS Ekle", "Management/SssAdd", "~/Management/SssAdd.aspx");
            routes.MapPageRoute("SSS Listele", "Management/SssList", "~/Management/SssList.aspx");
            routes.MapPageRoute("SSS Güncelle", "Management/SssUpdate-{id}", "~/Management/SssUpdate.aspx");

            routes.MapPageRoute("Çok Aranan Ekle", "Management/MostSearchedAdd", "~/Management/MostSearchedAdd.aspx");
            routes.MapPageRoute("Çok Aranan Listele", "Management/MostSearchedList", "~/Management/MostSearchedList.aspx");
            routes.MapPageRoute("Çok Aranan Güncelle", "Management/MostSearchedUpdate-{id}", "~/Management/MostSearchedUpdate.aspx");

            routes.MapPageRoute("Ekip Ekle", "Management/TeamAdd", "~/Management/TeamAdd.aspx");
            routes.MapPageRoute("Ekip Listele", "Management/TeamList", "~/Management/TeamList.aspx");
            routes.MapPageRoute("Ekip Güncelle", "Management/TeamUpdate-{id}", "~/Management/TeamUpdate.aspx");
            routes.MapPageRoute("Ekip Sıralama", "Management/TeamShort", "~/Management/TeamShort.aspx");

            routes.MapPageRoute("Özellik Grup Listele", "Management/PropertyGroupList", "~/Management/PropertyGroupList.aspx");
            routes.MapPageRoute("Özellik Listele", "Management/PropertyList", "~/Management/PropertyList.aspx");
            routes.MapPageRoute("Özellik Sıralama", "Management/PropertyShort", "~/Management/PropertyShort.aspx");

            routes.MapPageRoute("Ürün Ekle", "Management/ProductAdd", "~/Management/ProductAdd.aspx");
            routes.MapPageRoute("Ürün Listele", "Management/ProductList", "~/Management/ProductList.aspx");
            routes.MapPageRoute("Ürün Güncelle", "Management/ProductUpdate-{id}", "~/Management/ProductUpdate.aspx");
            routes.MapPageRoute("Popüler Ürün Sıralama", "Management/PopularProductShort", "~/Management/PopularProductShort.aspx");
            routes.MapPageRoute("Ürün Sıralama", "Management/ProductShort", "~/Management/ProductShort.aspx");

            routes.MapPageRoute("Tab Filtre Ekle", "Management/TabFilterAdd", "~/Management/TabFilterAdd.aspx");
            routes.MapPageRoute("Tab Filtre Listele", "Management/TabFilterList", "~/Management/TabFilterList.aspx");
            routes.MapPageRoute("Tab Filtre Güncelle", "Management/TabFilterUpdate-{filterId}", "~/Management/TabFilterUpdate.aspx");
            routes.MapPageRoute("Tab Filtre Sıralama", "Management/TabFilterShort", "~/Management/TabFilterShort.aspx");

            routes.MapPageRoute("Bağış Kayıtları Listele", "Management/DonateRecordList", "~/Management/DonateRecordList.aspx");
            routes.MapPageRoute("Bağış Kayıtları Güncelle", "Management/DonateRecordUpdate-{id}", "~/Management/DonateRecordUpdate.aspx");

            routes.MapPageRoute("Mail Sunucu Ayarları", "Management/MailSettingUpdate", "~/Management/MailSettingUpdate.aspx");
            routes.MapPageRoute("Sayfa Genel Ayarları", "Management/GeneralSettingUpdate", "~/Management/GeneralSettingUpdate.aspx");
            routes.MapPageRoute("Sipariş Genel Ayarları", "Management/OrderSettingUpdate", "~/Management/OrderSettingUpdate.aspx");
            routes.MapPageRoute("Sayfa Seo Listele", "Management/SeoPageList", "~/Management/SeoPageList.aspx");
            routes.MapPageRoute("Sayfa Seo Güncelle", "Management/SeoPageUpdate-{id}", "~/Management/SeoPageUpdate.aspx");
            routes.MapPageRoute("Anasayfa İçerik Ayarları", "Management/HomePageContentUpdate", "~/Management/HomePageContentUpdate.aspx");
            routes.MapPageRoute("İşlem Kayıtları", "Management/OperationLogs", "~/Management/OperationLogs.aspx");
            routes.MapPageRoute("Giriş Kayıtları", "Management/LoginLogs", "~/Management/LoginLogs.aspx");
            routes.MapPageRoute("Raporlama", "Management/Reports", "~/Management/Reports.aspx");
            routes.MapPageRoute("Popup Yönetim", "Management/PopupManagement", "~/Management/PopupManagement.aspx");

            ////Site genel sayfalar.
            routes.MapPageRoute("Anasayfa", "tr", "~/Default.aspx");
            routes.MapPageRoute("İletişim", "tr/iletisim", "~/General_Pages/Contact.aspx");
            routes.MapPageRoute("Menu Detay", "tr/menu/{name}/{id}", "~/General_Pages/MenuList.aspx");
            routes.MapPageRoute("Kategori Listeleme", "tr/kategori/{name}/{id}", "~/General_Pages/CategoryList.aspx");
            routes.MapPageRoute("Alt Kategori Listeleme", "tr/kategoriler/{name}/{id}", "~/General_Pages/CategorySubList.aspx");
            routes.MapPageRoute("Blog", "tr/blog", "~/General_Pages/BlogList.aspx");
            routes.MapPageRoute("Blog Detay", "tr/blog/{tityle}-{id}", "~/General_Pages/BlogDetail.aspx");
            routes.MapPageRoute("Bağımsız Sayfa", "tr/sayfa/{link}", "~/General_Pages/ExternalArticleList.aspx");
            routes.MapPageRoute("Referanslar", "tr/referanslar", "~/General_Pages/ReferenceList.aspx");
            routes.MapPageRoute("Ürün Detay", "tr/proje/{title}-{id}", "~/General_Pages/ProductDetail.aspx");
            routes.MapPageRoute("Form Başarılı", "tr/form-basarili", "~/General_Pages/FormSuccess.aspx");

            routes.MapPageRoute("EN Anasayfa", "en", "~/Default.aspx");
            routes.MapPageRoute("EN İletişim", "en/contact", "~/General_Pages/Contact.aspx");
            routes.MapPageRoute("EN Menu Detay", "en/menu/{name}/{id}", "~/General_Pages/MenuList.aspx");
            routes.MapPageRoute("EN Kategori Listeleme", "en/category/{name}/{id}", "~/General_Pages/CategoryList.aspx");
            routes.MapPageRoute("EN Alt Kategori Listeleme", "en/categories/{name}/{id}", "~/General_Pages/CategorySubList.aspx");
            routes.MapPageRoute("EN Blog", "en/blog", "~/General_Pages/BlogList.aspx");
            routes.MapPageRoute("EN Blog Detay", "en/blog/{tityle}-{id}", "~/General_Pages/BlogDetail.aspx");
            routes.MapPageRoute("EN Bağımsız Sayfa", "en/page/{link}", "~/General_Pages/ExternalArticleList.aspx");
            routes.MapPageRoute("EN Referanslar", "en/references", "~/General_Pages/ReferenceList.aspx");
            routes.MapPageRoute("EN Ürün Detay", "en/project/{title}-{id}", "~/General_Pages/ProductDetail.aspx");
            routes.MapPageRoute("EN Form Başarılı", "en/form-success", "~/General_Pages/FormSuccess.aspx");

            routes.MapPageRoute("HU Anasayfa", "hu", "~/Default.aspx");
            routes.MapPageRoute("HU İletişim", "hu/contact", "~/General_Pages/Contact.aspx");
            routes.MapPageRoute("HU Menu Detay", "hu/menu/{name}/{id}", "~/General_Pages/MenuList.aspx");
            routes.MapPageRoute("HU Kategori Listeleme", "hu/category/{name}/{id}", "~/General_Pages/CategoryList.aspx");
            routes.MapPageRoute("HU Alt Kategori Listeleme", "hu/categories/{name}/{id}", "~/General_Pages/CategorySubList.aspx");
            routes.MapPageRoute("HU Blog", "hu/blog", "~/General_Pages/BlogList.aspx");
            routes.MapPageRoute("HU Blog Detay", "hu/blog/{tityle}-{id}", "~/General_Pages/BlogDetail.aspx");
            routes.MapPageRoute("HU Bağımsız Sayfa", "hu/page/{link}", "~/General_Pages/ExternalArticleList.aspx");
            routes.MapPageRoute("HU Referanslar", "hu/references", "~/General_Pages/ReferenceList.aspx");
            routes.MapPageRoute("HU Ürün Detay", "hu/project/{title}-{id}", "~/General_Pages/ProductDetail.aspx");
            routes.MapPageRoute("HU Form Başarılı", "hu/form-success", "~/General_Pages/FormSuccess.aspx");

            routes.MapPageRoute("Hata", "error", "~/Error.aspx");

        }
    }
}