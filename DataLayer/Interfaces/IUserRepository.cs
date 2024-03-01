using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZV.Pro.Core.Entities;

namespace ZV.Pro.Data.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        User GetByUsername(string userName);
    }
}
