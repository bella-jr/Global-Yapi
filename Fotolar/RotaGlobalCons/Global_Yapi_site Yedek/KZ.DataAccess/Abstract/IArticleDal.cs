using System.Collections.Generic;
using KZ.Core;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.DataAccess.Abstract
{
    public interface IArticleDal : IEntityRepository<Article>
    {
        List<ArticleJoin> GetListJoin(byte languageId);
    }
}
