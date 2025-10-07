using KZ.Entity.Models.Data;
using System.Collections.Generic;
using KZ.Entity.Models.Custom;

namespace KZ.Business.Abstract
{
    public interface ILoginLogService
    {
        void Add(LoginLog loginLog);
        List<LoginLogJoin> GetAll();

        int GetAll_Take(int count);

    }
}
