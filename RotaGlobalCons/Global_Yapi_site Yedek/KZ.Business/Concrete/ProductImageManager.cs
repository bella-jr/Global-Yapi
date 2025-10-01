using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }

        public void Add(ProductImage productImage)
        {
            _productImageDal.Add(productImage);
        }

        public void Update(ProductImage productImage)
        {
            _productImageDal.Update(productImage);
        }

        public void Delete(ProductImage productImage)
        {
            _productImageDal.Delete(productImage);
        }

        public List<ProductImageJoin> GetAll_Join(int productId)
        {
            return _productImageDal.GetAllJoin(productId);
        }

        public List<ProductImage> GetAll(int productId)
        {
            return _productImageDal.GetList(x => x.ProductId == productId).OrderBy(x=> x.SequenceNumber).ToList();
        }

        public ProductImage GetById(int imageId)
        {
            return _productImageDal.Get(x => x.Id == imageId);
        }
    }
}
