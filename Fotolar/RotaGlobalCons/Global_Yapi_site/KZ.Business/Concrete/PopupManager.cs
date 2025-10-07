using System;
using KZ.Business.Abstract;
using KZ.Entity.Models.Data;
using KZ.DataAccess.Abstract;

namespace KZ.Business.Concrete
{
    public class PopupManager : IPopupService
    {
        private IPopupDal _popupDal;

        public PopupManager(IPopupDal PopupDal)
        {
            _popupDal = PopupDal;
        }

        public void Update(Popup popup)
        {
            _popupDal.Update(popup);
        }

        public Popup GetById(int id)
        {
            return _popupDal.Get(x => x.LanguageId == id);
        }

        public Popup GetByUI(int id)
        {
            return _popupDal.Get(x => x.LanguageId == id && x.IsStatus && x.IsDateLimited == false);
        }

        public Popup GetByDate(int id, DateTime date)
        {
            return _popupDal.Get(x => x.LanguageId == id && x.StartDate <= date.Date && x.EndDate >= date.Date && x.IsStatus && x.IsDateLimited);
        }
    }
}
