using System;
using KZ.Entity.Models.Data;

namespace KZ.Business.Abstract
{
    public interface IPopupService
    {
        void Update(Popup popup);

        Popup GetById(int id);

        Popup GetByUI(int id);

        Popup GetByDate(int id, DateTime date);
    }
}
