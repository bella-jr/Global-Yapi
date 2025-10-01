using System.Collections.Generic;
using KZ.Core;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Abstract
{
    public interface IProductImageDal : IEntityRepository<ProductImage>
    {
        List<ProductImageJoin> GetAllJoin(int productId);
    }
}
