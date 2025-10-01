using System.Collections.Generic;
using KZ.Core;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Abstract
{
    public interface IProductPropertyDal : IEntityRepository<ProductProperty>
    {
        List<ProductPropertyJoin> GetAllJoin(int productId);
    }
}
