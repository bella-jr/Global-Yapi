using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfMailSettingDal : EfEntityRepositoryBase<MailSetting, DataContext>, IMailSettingDal
    {
    }
}
