using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfPropertyDal : EfEntityRepositoryBase<Property, DataContext>, IPropertyDal
    {
        public List<PropertyJoin> GetAllJoin()
        {
            using (var db = new DataContext())
            {
                var data = from p in db.Property
                           join pg in db.PropertyGroup on p.PropertyGroupId equals pg.Id
                           select new PropertyJoin()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               Icon = p.Icon,
                               PropertyGroupName = pg.Name
                           };

                return data.ToList();
            }
        }
    }
}
