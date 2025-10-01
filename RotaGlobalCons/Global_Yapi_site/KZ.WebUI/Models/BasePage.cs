using System.Globalization;
using System.Threading;
using System.Web.UI;
using KZ.WebUI.DependencyResolvers.Ninject;
using KZ.WebUI.Tool.Abstract;

namespace KZ.WebUI.Models
{
    public class BasePage : Page
    {
        private ISessionService _sessionService;

        public BasePage()
        {
            _sessionService = WebUIInstanceFactory.GetInstance<ISessionService>();
        }

        protected override void InitializeCulture()
        {
            var language = _sessionService.GetSessionLanguage();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language.Culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language.Culture);
        }
    }
}