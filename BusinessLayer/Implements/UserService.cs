using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZV.Pro.Business.Interfaces;
using ZV.Pro.Core.Entities;
using ZV.Pro.Data.Interfaces;

namespace ZV.Pro.Business.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Create(User Entity)
        {
            userRepository.Create(Entity);
        }
      

        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }


        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }


        public User GetUsersByUserName(string userName)
        {
            return userRepository.GetByUsername(userName);
        }

        public void Update(User Entity)
        {
            userRepository.Update(Entity);
        }

        public void Delete(int id)
        {
            User user=userRepository.GetById(id);

            userRepository.Delete(user);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}