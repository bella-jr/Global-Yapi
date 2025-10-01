using System.Web;
using KZ.Business.Abstract;
using KZ.Business.DependencyResolvers.Ninject;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class StaticGeneralSettingManager
    {

        public static GeneralSetting GeneralSettingData()
        {
            IGeneralSettingService _generalSettingService;
            _generalSettingService = InstanceFactory.GetInstance<IGeneralSettingService>();

            if (HttpContext.Current.Application["generalSettingData"] == null)
                HttpContext.Current.Application["generalSettingData"] = _generalSettingService.GetAll();

            return (GeneralSetting)HttpContext.Current.Application["generalSettingData"];
        }
        
    }
}
