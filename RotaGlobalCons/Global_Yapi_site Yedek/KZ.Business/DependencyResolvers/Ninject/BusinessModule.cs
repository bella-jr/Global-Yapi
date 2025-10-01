using KZ.Business.Abstract;
using KZ.Business.Concrete;
using KZ.DataAccess.Abstract;
using KZ.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace KZ.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IArticleService>().To<ArticleManager>();
            Bind<IArticleDal>().To<EfArticleDal>();

            Bind<IBlogService>().To<BlogManager>();
            Bind<IBlogDal>().To<EfBlogDal>();

            Bind<IExtarnelArticleService>().To<ExtarnelArticleManager>();
            Bind<IExternalArticleDal>().To<EfExternalArticleDal>();

            Bind<IGalleryService>().To<GalleryManager>();
            Bind<IGalleryDal>().To<EfGalleryDal>();

            Bind<IGalleryImageService>().To<GalleryImageManager>();
            Bind<IGalleryImageDal>().To<EfGalleryImageDal>();

            Bind<IGeneralSettingService>().To<GeneralSettingManager>();
            Bind<IGeneralSettingDal>().To<EfGeneralSettingDal>();

            Bind<IHomePageContentService>().To<HomePageContentManager>();
            Bind<IHomePageContentDal>().To<EfHomePageContentDal>();

            Bind<ILanguageService>().To<LanguageManager>();
            Bind<ILanguageDal>().To<EfLanguageDal>();

            Bind<ILoginLogService>().To<LoginLogManager>();
            Bind<ILoginLogDal>().To<EfLoginLogDal>();

            Bind<IMailSettingService>().To<MailSettingManager>();
            Bind<IMailSettingDal>().To<EfMailSettingDal>();

            Bind<IMenuService>().To<MenuManager>();
            Bind<IMenuDal>().To<EfMenuDal>();

            Bind<IProductService>().To<ProductManager>();
            Bind<IProductDal>().To<EfProductDal>();

            Bind<IProductImageService>().To<ProductImageManager>();
            Bind<IProductImageDal>().To<EfProductImageDal>();

            Bind<IProductMenuService>().To<ProductMenuManager>();
            Bind<IProductMenuDal>().To<EfProductMenuDal>();

            Bind<IProductPropertyService>().To<ProductPropertyManager>();
            Bind<IProductPropertyDal>().To<EfProductPropertyDal>();

            Bind<IPropertyService>().To<PropertyManager>();
            Bind<IPropertyDal>().To<EfPropertyDal>();

            Bind<IPropertyGroupService>().To<PropertyGroupManager>();
            Bind<IPropertyGroupDal>().To<EfPropertyGroupDal>();

            Bind<ISeoPageService>().To<SeoPageManager>();
            Bind<ISeoPageDal>().To<EfSeoPageDal>();

            Bind<ISliderService>().To<SliderManager>();
            Bind<ISliderDal>().To<EfSliderDal>();

            Bind<ITabFilterService>().To<TabFilterManager>();
            Bind<ITabFilterDal>().To<EfTabFilterDal>();

            Bind<ITabFilterProductService>().To<TabFilterProductManager>();
            Bind<ITabFilterProductDal>().To<EfTabFilterProductDal>();

            Bind<IUserService>().To<UserManager>();
            Bind<IUserDal>().To<EfUserDal>();

            Bind<ISeoUrlRedirectService>().To<SeoUrlRedirectManager>();
            Bind<ISeoUrlRedirectDal>().To<EfSeoUrlRedirectDal>();

            Bind<IReferenceService>().To<ReferenceManager>();
            Bind<IReferenceDal>().To<EfReferenceDal>();

            Bind<ICommentService>().To<CommentManager>();
            Bind<ICommentDal>().To<EfCommentDal>();

            Bind<IPopupService>().To<PopupManager>();
            Bind<IPopupDal>().To<EfPopupDal>();

            Bind<ISssService>().To<SssManager>();
            Bind<ISssDal>().To<EfSssDal>();

            Bind<IMostSearchedService>().To<MostSearchedManager>();
            Bind<IMostSearchedDal>().To<EfMostSearchedDal>();

        }
    }
}
