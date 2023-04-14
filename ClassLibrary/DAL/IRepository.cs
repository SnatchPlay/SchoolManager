using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Create(T tempObj);
        void Delete(Func<T, bool> filter);
        void Read();
        T Get(Func<T, bool> filter);
        void Update(T obj);
        void Refresh();
    }
}
