using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfArticleDal : EfEntityRepositoryBase<Article,DataContext>, IArticleDal
    {
        public List<ArticleJoin> GetListJoin(byte languageId)
        {
            using (var db = new DataContext())
            {
                var data = from a in db.Article
                    join m in db.Menu on a.MenuId equals m.Id
                    where a.LanguageId == languageId
                    select new ArticleJoin()
                    {
                        Id = a.Id,
                        Title = a.Title,
                        Description = a.Description,
                        IsStatus = a.IsStatus,
                        SeoTitle = a.SeoTitle,
                        SeoDescription = a.SeoDescription,
                        SeoKeywords = a.SeoKeywords,
                        MenuId = a.MenuId,
                        GalleryId = a.GalleryId,
                        LanguageId = a.LanguageId,
                        CreationDate = a.CreationDate,
                        MenuName = m.Name,
                        PageTypeId = a.PageTypeId
                    };

                return data.ToList();
            }
        }
    }
}
