using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class ProductMenuManager : IProductMenuService
    {
        private IProductMenuDal _productMenuDal;

        public ProductMenuManager(IProductMenuDal productMenuDal)
        {
            _productMenuDal = productMenuDal;
        }

        public void Add(ProductMenu productMenu)
        {
            _productMenuDal.Add(productMenu);
        }

        public void Update(ProductMenu productMenu)
        {
            _productMenuDal.Update(productMenu);
        }

        public void Delete(ProductMenu productMenu)
        {
            _productMenuDal.Delete(productMenu);
        }

        public List<ProductMenu> GetAll()
        {
            return _productMenuDal.GetList();
        }

        public List<ProductMenu> GetAll_ProductId(int productId)
        {
            return _productMenuDal.GetList(x => x.ProductId == productId);
        }

        public List<ProductMenuJoin> GetAll_MenuId(int menuId)
        {
            return _productMenuDal.GetAllMenuId(menuId);
        }

        public List<ProductMenuJoin> GetAll_MenuId_Home(int menuId)
        {
            return _productMenuDal.GetAllMenuId_IsHome(menuId);
        }

        public List<ProductMenu> GetById(int id)
        {
            return _productMenuDal.GetList(x => x.MenuId == id);
        }

        public ProductMenu GetByIdOne(int id)
        {
            return _productMenuDal.Get(x => x.Id == id);
        }
    }
}
