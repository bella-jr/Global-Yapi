using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IGalleryImageService
    {
        void Add(GalleryImage galleryImage);
        void Update(GalleryImage galleryImage);
        void Delete(GalleryImage galleryImage);
        List<GalleryImage> GetAll(int galleryId);
        List<GalleryImage> GetAllHome_UI();
        List<GalleryImage> GetAll_UI(int galleryId);

        GalleryImage GetById(int id);
    }
}
