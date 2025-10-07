using KZ.Entity.Models.Data;
using System.Collections.Generic;

namespace KZ.Business.Abstract
{
    public interface ISliderService
    {
        void Add(Slider slider);
        void Update(Slider slider);
        void Delete(Slider slider);
        Slider GetById(int id);
        List<Slider> GetAll(byte languageId);

        List<Slider> GetAll_UI(byte languageId);
    }
}
