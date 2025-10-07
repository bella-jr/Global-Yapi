using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfProductPropertyDal : EfEntityRepositoryBase<ProductProperty, DataContext>, IProductPropertyDal
    {
        public List<ProductPropertyJoin> GetAllJoin(int productId)
        {
            using (var db = new DataContext())
            {
                var data = from pp in db.ProductProperty
                           join p in db.Property on pp.PropertyId equals p.Id
                           where pp.ProductId == productId
                           select new ProductPropertyJoin()
                           {
                               Id = pp.Id,
                               Icon = p.Icon,
                               Value = pp.Value,
                               PropertyId = pp.PropertyId,
                               ProductId = pp.ProductId,
                               PropertyName = p.Name,
                               SequenceNumber = p.SequenceNumber,
                               GroupId = p.PropertyGroupId
                           };

                return data.OrderBy(x => x.SequenceNumber).ToList();
            }
        }
    }
}
