using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface ITaskService
    {
        public TaskClass GetTaskClassById(int id);
        public List<TaskClass> GetTaskClassesByStudentId(int studentId);
        public List<TaskClass> GetTaskClassesByLessonId(int lessonId);
        public List<TaskClass> GetTaskClassesByStatus(bool status);
        public List<TaskClass> GetAllTaskClasses();
        public List<TaskClass> GetTaskClassesByDeadLine(DateTime deadline);
        public List<TaskClass> GetTaskClassesByClosedTime(DateTime closedTime);
       // public List<TaskClass> GetTaskkClassesByMultipleParams();
       //Логіка фільтрування за динамічними параметрами
    }
}
