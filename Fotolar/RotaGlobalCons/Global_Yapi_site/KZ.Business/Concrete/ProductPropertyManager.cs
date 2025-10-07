using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class ProductPropertyManager : IProductPropertyService
    {
        private IProductPropertyDal _productPropertyDal;

        public ProductPropertyManager(IProductPropertyDal productPropertyDal)
        {
            _productPropertyDal = productPropertyDal;
        }

        public void Add(ProductProperty productProperty)
        {
            _productPropertyDal.Add(productProperty);
        }

        public void Update(ProductProperty productProperty)
        {
            _productPropertyDal.Update(productProperty);
        }

        public void Delete(ProductProperty productProperty)
        {
            _productPropertyDal.Delete(productProperty);
        }

        public List<ProductProperty> GetAll()
        {
            return _productPropertyDal.GetList();
        }

        public List<ProductPropertyJoin> GetAll_Join(int productId)
        {
            return _productPropertyDal.GetAllJoin(productId);
        }

        public List<ProductProperty> GetAll(int productId)
        {
            return _productPropertyDal.GetList(x => x.ProductId == productId);
        }

        public ProductProperty GetById(int id)
        {
            return _productPropertyDal.Get(x => x.Id == id);
        }

        public List<ProductProperty> GetByProductId(int productId)
        {
            return _productPropertyDal.GetList(x => x.ProductId == productId);
        }

        public ProductProperty GetByProductId(int propertyId, int productId)
        {
            return _productPropertyDal.Get(x => x.PropertyId == propertyId && x.ProductId == productId);
        }
    }
}
