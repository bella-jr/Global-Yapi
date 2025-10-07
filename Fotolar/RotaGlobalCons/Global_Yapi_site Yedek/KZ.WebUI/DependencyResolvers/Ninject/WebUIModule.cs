using KZ.WebUI.Tool.Abstract;
using KZ.WebUI.Tool.Concrete;
using Ninject.Modules;

namespace KZ.WebUI.DependencyResolvers.Ninject
{
    public class WebUIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICkEditorService>().To<CkEditorManager>();
            Bind<ISessionService>().To<SessionManager>();
            Bind<IFormControlService>().To<FormControlManager>();
            Bind<IExpressToolService>().To<ExpressToolManager>();
            Bind<IMailService>().To<MailServiceManager>();
            Bind<IMenuToolService>().To<MenuToolManager>();
            Bind<ICookieService>().To<CookieManager>();

        }
    }
}