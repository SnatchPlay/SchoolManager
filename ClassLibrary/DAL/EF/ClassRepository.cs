using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace ClassLibrary.DAL.EF
{
    public class ClassRepository : IRepository<Class>
    {
        List<Class> ClassList;
        private ApplicationContext _context;
        //protected string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        //protected string connStr = "Data Source=DESKTOP-SO70MLO;Initial Catalog=Trade v.2;Integrated Security=True";

        public ClassRepository(ApplicationContext context)
        {
            ClassList = new List<Class>();
            Read();
            this._context = context;
        }
        public void Create(Class tempObj)
        {
            _context.Add(tempObj);
        }

        public void Delete(Func<Class, bool> filter)
        { 
            Class cl = ClassList.First(filter);
            ClassList.Remove(cl);
            _context.Remove(cl);
        }

        public Class Get(Func<Class, bool> filter)
        {
            return ClassList.First(filter);
        }

        public List<Class> GetAll()
        {
            return ClassList;
        }


        public void Read()
        {
            ClassList= _context.Classes.ToList();
        }

        public void Refresh()
        {
            ClassList.Clear();
            Read();
        }

        public void Update(Class obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
