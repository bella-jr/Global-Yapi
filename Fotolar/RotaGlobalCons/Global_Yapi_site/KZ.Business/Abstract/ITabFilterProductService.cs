using System.Collections.Generic;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface ITabFilterProductService
    {
        void Add(TabFilterProduct tabFilterProduct);
        void Update(TabFilterProduct tabFilterProduct);
        void Delete(TabFilterProduct tabFilterProduct);

        List<TabFilterProduct> GetAll_ProductId(int productId);

        List<TabFilterProductJoin> GetAll_TabFilterId(int tabFilterId);

        List<TabFilterProductJoin> GetAll();

        TabFilterProduct GetById(int id);

        TabFilterProduct GetById(int id, int productId);
    }
}