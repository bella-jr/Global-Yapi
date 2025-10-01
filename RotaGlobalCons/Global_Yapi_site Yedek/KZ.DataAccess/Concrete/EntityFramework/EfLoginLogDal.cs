using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfLoginLogDal : EfEntityRepositoryBase<LoginLog, DataContext>, ILoginLogDal
    {
        public List<LoginLogJoin> GetAllJoin()
        {
            using (var db = new DataContext())
            {
                var data = from l in db.LoginLog
                           join u in db.User on l.UserId equals u.Id
                           select new LoginLogJoin()
                           {
                               Ip = l.Ip,
                               NameSurname = u.Name + " " + u.Surname,
                               CreationDate = l.CreationDate
                           };

                return data.ToList();
            }
        }
    }
}
