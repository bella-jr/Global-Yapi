using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfTabFilterProductDal : EfEntityRepositoryBase<TabFilterProduct, DataContext>, ITabFilterProductDal
    {
        public List<TabFilterProductJoin> GetAllJoin(int filterId)
        {
            using (var db = new DataContext())
            {
                var data = from tb in db.TabFilterProduct
                           join p in db.Product on tb.ProductId equals p.Id
                           where tb.TabFilterId == filterId && p.IsStatus
                           select new TabFilterProductJoin()
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Code = p.Code,
                               Image = p.Image,
                               Price = p.Price,
                               Old_Price = p.Old_Price,
                               SeoKeywords = p.SeoKeywords,
                               IsNew = p.IsNew,
                               IsDiscount = p.IsDiscount,
                               IsStock = p.IsStock,
                               IsSoon = p.IsSoon,
                               Discount = p.Discount,
                               TabFilterId = tb.TabFilterId,
                           };

                return data.ToList();
            }
        }

        public List<TabFilterProductJoin> GetAllJoin()
        {
            using (var db = new DataContext())
            {
                var data = from tb in db.TabFilterProduct
                           join p in db.Product on tb.ProductId equals p.Id
                           where p.IsStatus
                           select new TabFilterProductJoin()
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Code = p.Code,
                               Image = p.Image,
                               Price = p.Price,
                               Old_Price = p.Old_Price,
                               SeoKeywords = p.SeoKeywords,
                               IsNew = p.IsNew,
                               IsDiscount = p.IsDiscount,
                               IsStock = p.IsStock,
                               IsSoon = p.IsSoon,
                               Discount = p.Discount,
                               TabFilterId = tb.TabFilterId,
                           };

                return data.ToList();
            }
        }
    }
}
