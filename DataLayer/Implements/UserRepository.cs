using System;
using System.Text;
using ZV.Pro.Core.Entities;
using ZV.Pro.Data.Context;
using ZV.Pro.Data.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ZV.Pro.Data.Implements
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

       

        public User GetByUsername(string userName)
        {
            return _dbContext.Set<User>().Where(x => x.UserName == userName).FirstOrDefault();
        }


    }
}

