using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
