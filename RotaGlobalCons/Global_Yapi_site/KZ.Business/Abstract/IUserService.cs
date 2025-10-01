using KZ.Entity.Models.Data;
using System.Collections.Generic;
using KZ.Entity.Models.Custom;

namespace KZ.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);

        List<UserJoin> GetAll(byte typeId);
        User GetById(int userId);

        //Yönetilerin panele girmesini sağlar.
        User GetLoginPanel(string mail, string password);

        //Şifre sıfırlama işlemi yapma işlemini sağlar.
        User GetForgetPassword(string mail, byte typeId);

        //Mail adresi kontrol işlemi sağlar.
        bool MailControl(string mail);

        int GetCount(byte typeId);

    }
}
