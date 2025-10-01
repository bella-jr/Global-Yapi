using System.Collections.Generic;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IProductImageService
    {
        void Add(ProductImage productImage);

        void Update(ProductImage productImage);

        void Delete(ProductImage productImage);

        List<ProductImageJoin> GetAll_Join(int productId);

        List<ProductImage> GetAll(int productId);

        ProductImage GetById(int imageId);
    }
}
