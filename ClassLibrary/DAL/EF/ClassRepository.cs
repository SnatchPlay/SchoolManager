﻿using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Delete(int id)
        { 
            Class cl = _context.Classes.Find(id);
            for (int i = 0; i < ClassList.Count(); i++)
            {
                if (i == id)
                {
                    ClassList.RemoveAt(i);
                }
            }
            _context.Remove(cl);
        } 

        public List<Class> GetAll()
        {
            return ClassList;
        }

        public Class Get(int id)
        {
            return _context.Classes.Find(id);
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
        }
    }
}