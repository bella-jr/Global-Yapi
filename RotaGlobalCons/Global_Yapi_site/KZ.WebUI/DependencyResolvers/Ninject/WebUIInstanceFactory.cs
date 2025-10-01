using Ninject;

namespace KZ.WebUI.DependencyResolvers.Ninject
{
    public class WebUIInstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new WebUIModule());
            return kernel.Get<T>();
        }
    }
}