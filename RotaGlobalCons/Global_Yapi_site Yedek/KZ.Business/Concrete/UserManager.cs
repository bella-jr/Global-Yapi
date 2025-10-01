using System.Collections.Generic;
using KZ.Business.Abstract;
using KZ.Core;
using KZ.DataAccess.Abstract;
using KZ.Entity.Enums;
using KZ.Entity.Models.Custom;
using KZ.Entity.Models.Data;

namespace KZ.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        Tools tool = new Tools();

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            user.Password = tool.Encrypt(user.Password);
            _userDal.Add(user);
        }

        public void Update(User user)
        {
            if (user.Password.Length < 50)
                user.Password = tool.Encrypt(user.Password);

            _userDal.Update(user);
        }

        public void Delete(User user)
        {
            _userDal.Update(user);
        }

        public List<UserJoin> GetAll(byte typeId)
        {
            return _userDal.GetListJoin(typeId);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(x => x.Id == userId);
        }

        public User GetLoginPanel(string mail, string password)
        {
            string pass = tool.Encrypt(password);
            return _userDal.Get(x => x.Mail == mail && x.Password == pass && x.TypeId == (byte)TypeUser.Admin && x.IsStatus && x.IsMailVerify && x.IsDeleted == false);
        }

        public User GetForgetPassword(string mail, byte typeId)
        {
            return _userDal.Get(x => x.Mail == mail && x.IsMailVerify && x.TypeId == typeId && x.IsDeleted == false && x.IsStatus);
        }

        public bool MailControl(string mail)
        {
            if (_userDal.Get(x => x.Mail == mail) == null)
                return true;

            return false;
        }

        public int GetCount(byte typeId)
        {
            return _userDal.GetList(x => x.TypeId == typeId).Count;
        }
    }
}
