using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IGeneralSettingService
    {
        void Update(GeneralSetting generalSetting);

        GeneralSetting GetAll();
    }
}
