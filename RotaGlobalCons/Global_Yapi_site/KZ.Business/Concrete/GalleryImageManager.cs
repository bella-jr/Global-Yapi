using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class GalleryImageManager : IGalleryImageService
    {
        private IGalleryImageDal _galleryImageDal;

        public GalleryImageManager(IGalleryImageDal galleryImageDal)
        {
            _galleryImageDal = galleryImageDal;
        }


        public void Add(GalleryImage galleryImage)
        {
            _galleryImageDal.Add(galleryImage);
        }

        public void Update(GalleryImage galleryImage)
        {
            _galleryImageDal.Update(galleryImage);
        }

        public void Delete(GalleryImage galleryImage)
        {
            _galleryImageDal.Delete(galleryImage);
        }

        public List<GalleryImage> GetAll(int galleryId)
        {
            return _galleryImageDal.GetList(x => x.GalleryId == galleryId).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<GalleryImage> GetAll_UI(int galleryId)
        {
            return _galleryImageDal.GetList(x => x.GalleryId == galleryId && x.Gallery.IsStatus).OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<GalleryImage> GetAllHome_UI()
        {
            return _galleryImageDal.GetList(x => x.Gallery.IsStatus && x.Gallery.IsHome).OrderBy(x => x.SequenceNumber).ToList();
        }

        public GalleryImage GetById(int id)
        {
            return _galleryImageDal.Get(x => x.Id == id);
        }
    }
}
