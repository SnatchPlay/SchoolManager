using BLL.DTO;

namespace BLL.Interfaces
{
    internal interface IClassService
    {
        public void AddNewClass(string name);
        public void RemoveClassById(int id);
        public void RenameClassById(int id);
        public List<ClassDTO> GetClasses();
        public ClassDTO GetClassById(int id);
        public ClassDTO GetClassByName(string name);
    }
}
