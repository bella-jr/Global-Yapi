using System.Collections.Generic;
using KZ.Core;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetListSearch(string query);

        List<PopularProductJoin> GetPopularList(byte languageId);
    }
}
