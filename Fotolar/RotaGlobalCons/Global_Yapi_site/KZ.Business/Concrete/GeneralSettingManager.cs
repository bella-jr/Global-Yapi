using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class GeneralSettingManager : IGeneralSettingService
    {
        private IGeneralSettingDal _generalSettingDal;

        public GeneralSettingManager(IGeneralSettingDal generalSettingDal)
        {
            _generalSettingDal = generalSettingDal;
        }

        public void Update(GeneralSetting generalSetting)
        {
            _generalSettingDal.Update(generalSetting);
        }

        public GeneralSetting GetAll()
        {
            return _generalSettingDal.Get(g => g.Id == 1);
        }
    }
}
