using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class GalleryManager : IGalleryService
    {
        private IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }


        public void Add(Gallery gallery)
        {
            _galleryDal.Add(gallery);
        }

        public void Update(Gallery gallery)
        {
            _galleryDal.Update(gallery);
        }

        public void Delete(Gallery gallery)
        {
            _galleryDal.Delete(gallery);
        }

        public List<Gallery> GetAll()
        {
            return _galleryDal.GetList().OrderBy(x => x.SequenceNumber).ToList();
        }

        public List<Gallery> GetAll_UIControl(string text, bool isDefaultValue = true)
        {
            var gallery = _galleryDal.GetList(x => x.IsStatus).OrderBy(x => x.SequenceNumber).ToList();

            if (isDefaultValue)
            {
                gallery.Insert(0, new Gallery { Id = 0, Name = text });
            }

            return gallery;
        }

        public Gallery GetById(int galleryId)
        {
            return _galleryDal.Get(x => x.Id == galleryId);
        }
    }
}
