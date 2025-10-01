using KZ.Business.Abstract;
using KZ.Entity.Models.Data;
using System.Collections.Generic;
using System.Linq;
using KZ.DataAccess.Abstract;
using KZ.Entity.Models.Custom;

namespace KZ.Business.Concrete
{
    public class LoginLogManager : ILoginLogService
    {
        private ILoginLogDal _loginLogDal;

        public LoginLogManager(ILoginLogDal loginLogDal)
        {
            _loginLogDal = loginLogDal;
        }

        public void Add(LoginLog loginLog)
        {
            _loginLogDal.Add(loginLog);
        }

        public List<LoginLogJoin> GetAll()
        {
            return _loginLogDal.GetAllJoin();
        }

        public int GetAll_Take(int count)
        {
            return _loginLogDal.GetList().Take(count).Count();
        }
    }
}
