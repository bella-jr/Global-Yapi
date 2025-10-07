using System.Collections.Generic;
using KZ.Core;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Abstract
{
    public interface IProductMenuDal : IEntityRepository<ProductMenu>
    {
        List<ProductMenuJoin> GetAllMenuId(int menuId);

        List<ProductMenuJoin> GetAllMenuId_IsHome(int menuId);
    }
}
