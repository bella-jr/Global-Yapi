using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, DataContext>, IProductDal
    {
        public List<Product> GetListSearch(string query)
        {
            using (var db = new DataContext())
            {
                DbRawSqlQuery<Product> data = db.Database.SqlQuery<Product>("Select * from Product " + query + "");

                return data.ToList();
            }
        }

        public List<PopularProductJoin> GetPopularList(byte languageId)
        {
            using (var db = new DataContext())
            {
                var data = from p in db.Product
                           where p.IsStatus && p.IsPopular && p.LanguageId == languageId
                           orderby p.PopularSequenceNumber
                           select new PopularProductJoin()
                           {
                               Id = p.Id,
                               Code = p.Code,
                               Title = p.Title,
                               Image = p.Image,
                               Price = p.Price,
                               Old_Price = p.Old_Price,
                               IsNew = p.IsNew,
                               IsStock = p.IsStock,
                               IsSoon = p.IsSoon,
                               IsDiscount = p.IsDiscount,
                               Discount = p.Discount,
                               SeoKeywords = p.SeoKeywords
                           };

                return data.ToList();
            }
        }
    }
}
