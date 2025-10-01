using System.Collections.Generic;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IGalleryService
    {
        void Add(Gallery gallery);
        void Update(Gallery gallery);
        void Delete(Gallery gallery);


        List<Gallery> GetAll();

        List<Gallery> GetAll_UIControl(string text = "- Seçim Yapınız -", bool isDefaultValue = true);

        Gallery GetById(int galleryId);
    }
}
