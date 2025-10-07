using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, DataContext>, IProductImageDal
    {
        public List<ProductImageJoin> GetAllJoin(int productId)
        {
            using (var db = new DataContext())
            {
                var data = from pi in db.ProductImage
                    join p in db.Product on pi.ProductId equals p.Id
                    where pi.ProductId == productId
                    select new ProductImageJoin()
                    {
                        Id = pi.Id,
                        Image = pi.Image,
                        ProductId = pi.ProductId,
                        SequenceNumber = pi.SequenceNumber,
                        ProductImage = p.Image,
                        ProductImage2 = p.Image2
                    };

                return data.OrderBy(x => x.SequenceNumber).ToList();
            }
        }
    }
}
