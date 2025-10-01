using System.Collections.Generic;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IProductService
    {
        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);

        List<Product> GetAll(byte languageId);

        List<Product> GetAll_UI(byte languageId);

        Product GetById(int id);

        List<PopularProductJoin> GetPopularProductList(byte languageId);

        int GetCount(byte languageId);

        List<Product> GetAll_Take(byte languageId, int count);

        List<Product> GetListSearch(string query);

        List<Product> GetAll_Home(byte languageId);

        List<Product> GetAll_Reference(byte languageId, int referenceId);
    }
}
