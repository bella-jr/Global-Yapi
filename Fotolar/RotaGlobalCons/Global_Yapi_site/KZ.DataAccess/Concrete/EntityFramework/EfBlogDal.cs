using System.Collections.Generic;
using System.Linq;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Context;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, DataContext>, IBlogDal
    {
        public List<BlogJoin> GetAllJoin(byte languageId)
        {
            using (var db = new DataContext())
            {
                var data = from b in db.Blog
                    join t in db.BlogType on b.BlogTypeId equals t.Id
                    where b.LanguageId == languageId
                    select new BlogJoin()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Image = b.Image,
                        IsStatus = b.IsStatus,
                        IsDetail = b.IsDetail,
                        Link = b.Link,
                        CreationDate = b.CreationDate,
                        TypeName = t.Name
                    };

                return data.ToList();
            }
        }
    }
}
