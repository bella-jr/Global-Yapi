using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IMailSettingService
    {
        void Update(MailSetting mailSetting);
        MailSetting GetAll();
        MailSetting GetAll_Panel();
    }
}
