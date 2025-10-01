using KZ.Business.Abstract;
using KZ.Entity.Models.Data;
using System.Web;
using KZ.DataAccess.Abstract;

namespace KZ.Business.Concrete
{
    public class MailSettingManager : IMailSettingService
    {
        private IMailSettingDal _mailSettingDal;

        public MailSettingManager(IMailSettingDal mailSettingDal)
        {
            _mailSettingDal = mailSettingDal;
        }

        public void Update(MailSetting mailSetting)
        {
            _mailSettingDal.Update(mailSetting);
            HttpContext.Current.Application["mailSettingData"] = mailSetting;
        }

        public MailSetting GetAll()
        {
            if (HttpContext.Current.Application["mailSettingData"] == null)
                HttpContext.Current.Application["mailSettingData"] = GetAll_Panel();

            return (MailSetting)HttpContext.Current.Application["mailSettingData"];
        }

        public MailSetting GetAll_Panel()
        {
            return _mailSettingDal.Get(x => x.Id == 1);
        }
    }
}
