using System.Collections.Generic;
using System.Linq;
using KZ.Business.Abstract;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Add(Slider slider)
        {
            _sliderDal.Add(slider);
        }

        public void Update(Slider slider)
        {
            _sliderDal.Update(slider);
        }

        public void Delete(Slider slider)
        {
            _sliderDal.Delete(slider);
        }

        public Slider GetById(int id)
        {
            return _sliderDal.Get(x => x.Id == id);
        }

        public List<Slider> GetAll(byte languageId)
        {
            return _sliderDal.GetList(x => x.LanguageId == languageId).OrderBy(x => x.SequenceNumber)
                .ToList();
        }

        public List<Slider> GetAll_UI(byte languageId)
        {
            return _sliderDal.GetList(x => x.IsStatus && x.LanguageId == languageId).OrderBy(x => x.SequenceNumber)
                .ToList();
        }
    }
}
