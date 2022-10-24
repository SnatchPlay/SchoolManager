using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public interface IRepository<T>
    {
        List<T> GetEnteties();
        void AddObj(T tempObj);
        void DeleteObject(int id);
        void ReadFromDB();
        T GetObj(int id);
        void UpdateField(string Table, string Field, string NewValue, int id);
        void RefreshList();
    }
}
