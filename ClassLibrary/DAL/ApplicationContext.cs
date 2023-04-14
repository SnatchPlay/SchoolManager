using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Journal> Journal { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Shedule> Shedule { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TaskClass> Tasks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<ParentStudent> ParentStudents { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public ApplicationContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OV9BI3K;Initial Catalog=SchoolManagement;Integrated Security=True;Encrypt=False");
        }
    }
}
