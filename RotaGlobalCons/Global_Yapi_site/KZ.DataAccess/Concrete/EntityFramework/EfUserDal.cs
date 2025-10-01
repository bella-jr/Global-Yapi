using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DataContext>, IUserDal
    {
        public List<UserJoin> GetListJoin(int typeId)
        {
            using (var db = new DataContext())
            {
                var data = from u in db.User
                           join ut in db.UserType on u.TypeId equals ut.Id
                           where u.TypeId == typeId && u.IsDeleted == false
                           select new UserJoin()
                           {
                               Id = u.Id,
                               Name = u.Name,
                               Surname = u.Surname,
                               Mail = u.Mail,
                               IsStatus = u.IsStatus,
                               TypeId = u.TypeId,
                               TypeName = ut.Name,
                               CreationDate = u.CreationDate
                           };

                return data.ToList();
            }
        }
    }
}
