using System.Collections.Generic;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IProductMenuService
    {
        void Add(ProductMenu productMenu);
        void Update(ProductMenu productMenu);
        void Delete(ProductMenu productMenu);

        List<ProductMenu> GetAll();

        List<ProductMenu> GetAll_ProductId(int productId);

        List<ProductMenuJoin> GetAll_MenuId(int menuId);

        List<ProductMenuJoin> GetAll_MenuId_Home(int menuId);

        List<ProductMenu> GetById(int id);

        ProductMenu GetByIdOne(int id);
    }
}
