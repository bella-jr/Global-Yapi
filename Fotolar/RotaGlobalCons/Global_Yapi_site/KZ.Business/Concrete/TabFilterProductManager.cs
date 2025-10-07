using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class TabFilterProductManager : ITabFilterProductService
    {
        private ITabFilterProductDal _tabFilterProductDal;

        public TabFilterProductManager(ITabFilterProductDal tabFilterProductDal)
        {
            _tabFilterProductDal = tabFilterProductDal;
        }

        public void Add(TabFilterProduct tabFilterProduct)
        {
            _tabFilterProductDal.Add(tabFilterProduct);
        }

        public void Update(TabFilterProduct tabFilterProduct)
        {
            _tabFilterProductDal.Update(tabFilterProduct);
        }

        public void Delete(TabFilterProduct tabFilterProduct)
        {
            _tabFilterProductDal.Delete(tabFilterProduct);
        }

        public List<TabFilterProduct> GetAll_ProductId(int productId)
        {
            return _tabFilterProductDal.GetList(x => x.ProductId == productId);
        }

        public List<TabFilterProductJoin> GetAll_TabFilterId(int tabFilterId)
        {
            return _tabFilterProductDal.GetAllJoin(tabFilterId);
        }

        public List<TabFilterProductJoin> GetAll()
        {
            return _tabFilterProductDal.GetAllJoin();
        }

        public TabFilterProduct GetById(int id)
        {
            return _tabFilterProductDal.Get(x => x.Id == id);
        }

        public TabFilterProduct GetById(int id, int productId)
        {
            return _tabFilterProductDal.Get(x => x.TabFilterId == id && x.ProductId == productId);

        }
    }
}
