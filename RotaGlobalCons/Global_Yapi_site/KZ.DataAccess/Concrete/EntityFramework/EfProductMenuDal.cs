using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfProductMenuDal : EfEntityRepositoryBase<ProductMenu, DataContext>, IProductMenuDal
    {
        public List<ProductMenuJoin> GetAllMenuId(int menuId)
        {
            using (var db = new DataContext())
            {
                var data = from pm in db.ProductMenu
                           join p in db.Product on pm.ProductId equals p.Id
                           where p.IsStatus && pm.MenuId == menuId
                           orderby pm.SequenceNumber
                           select new ProductMenuJoin()
                           {
                               Id = p.Id,
                               TopTitle = p.TopTitle,
                               Title = p.Title,
                               Code = p.Code,
                               Image = p.Image,
                               Price = p.Price,
                               Old_Price = p.Old_Price,
                               IsNew = p.IsNew,
                               IsDiscount = p.IsDiscount,
                               IsStock = p.IsStock,
                               IsSoon = p.IsSoon,
                               Discount = p.Discount,
                               SeoKeywords = p.SeoKeywords,
                               MenuId = pm.Id
                           };

                return data.ToList();
            }
        }

        public List<ProductMenuJoin> GetAllMenuId_IsHome(int menuId)
        {
            using (var db = new DataContext())
            {
                var data = from pm in db.ProductMenu
                           join p in db.Product on pm.ProductId equals p.Id
                           where p.IsStatus && p.IsPopular && pm.MenuId == menuId
                           orderby pm.SequenceNumber
                           select new ProductMenuJoin()
                           {
                               Id = p.Id,
                               TopTitle = p.TopTitle,
                               Title = p.Title,
                               Code = p.Code,
                               Image = p.Image,
                               Price = p.Price,
                               Old_Price = p.Old_Price,
                               IsNew = p.IsNew,
                               IsDiscount = p.IsDiscount,
                               IsStock = p.IsStock,
                               IsSoon = p.IsSoon,
                               Discount = p.Discount,
                               SeoKeywords = p.SeoKeywords,
                               MenuId = pm.Id
                           };

                return data.ToList();
            }
        }
    }
}
