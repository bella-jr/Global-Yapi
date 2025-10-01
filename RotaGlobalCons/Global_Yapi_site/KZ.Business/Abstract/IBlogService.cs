using KZ.Entity.Models.Data;
using System.Collections.Generic;
using KZ.Entity.Models.Custom;

namespace KZ.Business.Abstract
{
    public interface IBlogService
    {
        void Add(Blog news);
        void Update(Blog news);
        void Delete(Blog news);
        List<BlogJoin> GetAll(byte languageId);
        List<Blog> GetAll_Active(byte typeId, byte languageId);
        List<Blog> GetAll_Detail(string link);
        bool BlogControl(string link);

        Blog GetById(int newsId);

        Blog GetByLink(string link);

        List<Blog> GetAll_HomeLastTopList(byte count, byte languageId);

        List<Blog> GetAll_GalleryIdList(int galleryId, byte languageId);

    }
}
