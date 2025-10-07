using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }


        public void Add(Blog news)
        {
            _blogDal.Add(news);
        }

        public void Update(Blog news)
        {
            _blogDal.Update(news);
        }

        public void Delete(Blog news)
        {
            _blogDal.Delete(news);
        }

        public List<BlogJoin> GetAll(byte languageId)
        {
            return _blogDal.GetAllJoin(languageId);
        }

        public List<Blog> GetAll_Active(byte typeId, byte languageId)
        {
            return _blogDal.GetList(x => x.IsStatus && x.BlogTypeId == typeId && x.LanguageId == languageId).OrderByDescending(x => x.Id).ToList();
        }

        public List<Blog> GetAll_Detail(string link)
        {
            return _blogDal.GetList(x => x.IsStatus && x.Link == link);
        }

        public bool BlogControl(string link)
        {
            return _blogDal.Get(x => x.Link == link) == null ? true : false;
        }

        public Blog GetById(int newsId)
        {
            return _blogDal.Get(x => x.Id == newsId);
        }

        public Blog GetByLink(string link)
        {
            return _blogDal.Get(x => x.IsStatus && x.Link == link);
        }

        public List<Blog> GetAll_HomeLastTopList(byte count, byte languageId)
        {
            return _blogDal.GetList(x => x.IsStatus && x.LanguageId == languageId)
                .OrderBy(x => x.SequenceNumber).Take(count).ToList();
        }

        public List<Blog> GetAll_GalleryIdList(int galleryId, byte languageId)
        {
            return _blogDal.GetList(x => x.GalleryId == galleryId && x.LanguageId == languageId);
        }
    }
}
