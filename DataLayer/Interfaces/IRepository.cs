using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZV.Pro.Core.Entities;

namespace ZV.Pro.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        T GetById(int id);

        List<T> GetAll();
    }
}
