using System.Collections.Generic;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IProductPropertyService
    {
        void Add(ProductProperty productProperty);
        void Update(ProductProperty productProperty);
        void Delete(ProductProperty productProperty);

        List<ProductProperty> GetAll(int productId);

        List<ProductPropertyJoin> GetAll_Join(int productId);

        ProductProperty GetById(int id);

        List<ProductProperty> GetByProductId(int productId);

        ProductProperty GetByProductId(int propertyId, int productId);
    }
}
