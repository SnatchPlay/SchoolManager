using BLL.DTO;
using ClassLibrary.Models;

namespace BLL.Interfaces
{
    internal interface IClassService
    {
        public void AddNewClass(string name);
        public void RemoveClassById(int id);
        public void RenameClassById(int id);
        public List<Class> GetClasses();
        public Class GetClassById(int id);
        public Class GetClassByName(string name);
    }
}
