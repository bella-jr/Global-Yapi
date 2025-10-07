using KZ.Entity.Models.Data;
using System.Collections.Generic;
using KZ.Entity.Models.Custom;

namespace KZ.Business.Abstract
{
    public interface IArticleService
    {
        void Add(Article article);
        void Update(Article article);
        void Delete(Article article);

        List<ArticleJoin> GetAll(byte languageId);

        Article Get_MenuList(int menuId);

        List<Article> GetAll_GalleryId(int galleryId);

        List<Article> GetAll_Detail(int menuId);
    }
}
