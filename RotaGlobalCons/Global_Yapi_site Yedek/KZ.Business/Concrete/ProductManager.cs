using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> GetAll(byte languageId)
        {
            return _productDal.GetList(x => x.LanguageId == languageId).OrderByDescending(x => x.Id).ToList();
        }

        public List<Product> GetAll_UI(byte languageId)
        {
            return _productDal.GetList(x => x.IsStatus && x.LanguageId == languageId);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(x => x.Id == id);
        }

        public List<PopularProductJoin> GetPopularProductList(byte languageId)
        {
            return _productDal.GetPopularList(languageId);
        }

        public int GetCount(byte languageId)
        {
            return _productDal.GetList(x => x.LanguageId == languageId).Count;
        }

        public List<Product> GetAll_Take(byte languageId, int count)
        {
            return _productDal.GetList(x => x.LanguageId == languageId).Take(count).OrderByDescending(x => x.Id).ToList();
        }

        public List<Product> GetListSearch(string query)
        {
            return _productDal.GetListSearch(query);
        }

        public List<Product> GetAll_Home(byte languageId)
        {
            return _productDal.GetList(x => x.LanguageId == languageId && x.IsStatus && x.IsHome).OrderBy(x => x.HomeSequenceNumber).ToList();
        }

        public List<Product> GetAll_Reference(byte languageId, int referenceId)
        {
            return _productDal.GetList(x => x.LanguageId == languageId && x.IsStatus && x.ReferenceId == referenceId).OrderByDescending(x => x.Id).ToList();
        }
    }
}
