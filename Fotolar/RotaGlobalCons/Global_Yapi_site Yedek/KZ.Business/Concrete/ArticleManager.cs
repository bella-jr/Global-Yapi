using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        private IArticleDal _iArticleDal;

        public ArticleManager(IArticleDal iArticleDal)
        {
            _iArticleDal = iArticleDal;
        }


        public void Add(Article article)
        {
            _iArticleDal.Add(article);
        }

        public void Update(Article article)
        {
            _iArticleDal.Update(article);
        }

        public void Delete(Article article)
        {
            _iArticleDal.Delete(article);
        }

        public List<ArticleJoin> GetAll(byte languageId)
        {
            return _iArticleDal.GetListJoin(languageId).ToList();
        }

        public Article Get_MenuList(int menuId)
        {
            return _iArticleDal.Get(x => x.MenuId == menuId);
        }

        public List<Article> GetAll_GalleryId(int galleryId)
        {
            return _iArticleDal.GetList(x => x.GalleryId == galleryId);
        }

        public List<Article> GetAll_Detail(int menuId)
        {
            return _iArticleDal.GetList(x => x.IsStatus && x.MenuId == menuId);
        }
    }
}
