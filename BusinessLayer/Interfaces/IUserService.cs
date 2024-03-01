using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZV.Pro.Core.Entities;

namespace ZV.Pro.Business.Interfaces
{
    public interface IUserService
    {
        void Create(User Entity);
        void Update(User Entity);
        void Delete(int id);
        User GetUsersByUserName(string userName);

        User GetById(int id);

        List<User> GetAll();
        Task SaveChangesAsync();
    }
}
