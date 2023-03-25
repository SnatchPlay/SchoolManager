﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ClassDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}