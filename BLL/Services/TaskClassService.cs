using BLL.Interfaces;
using ClassLibrary.DAL;
using ClassLibrary.Factory;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class TaskClassService : ITaskService
    {
        IRepository<TaskClass> taskClassRep;
        public TaskClassService() 
        {
            taskClassRep=FactoryProvider.GetFactory().GetTaskClassRepository();
        }
        public List<TaskClass> GetAllTaskClasses()
        {
            return taskClassRep.GetAll();
        }

        public TaskClass GetTaskClassById(int id)
        {
            return taskClassRep.Get(x=>x.Id == id);
        }

        public List<TaskClass> GetTaskClassesByClosedTime(DateTime closedTime)
        {
            return taskClassRep.GetAll().FindAll(x=>x.ClosedTime == closedTime);
        }

        public List<TaskClass> GetTaskClassesByDeadLine(DateTime deadline)
        {
            return taskClassRep.GetAll().FindAll(x => x.DeadLine == deadline);
        }

        public List<TaskClass> GetTaskClassesByLessonId(int lessonId)
        {
            return taskClassRep.GetAll().FindAll(x => x.LessonId == lessonId);
        }

        public List<TaskClass> GetTaskClassesByStatus(bool status)
        {
            return taskClassRep.GetAll().FindAll(x => x.Status == status);
        }

        public List<TaskClass> GetTaskClassesByStudentId(int studentId)
        {
            return taskClassRep.GetAll().FindAll(x => x.StudentId == studentId);
        }
    }
}
