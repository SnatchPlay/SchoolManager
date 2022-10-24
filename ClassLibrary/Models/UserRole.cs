using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string Title { get; set; }
        public UserRole(int id, string title)
        {
            this.UserRoleId = id;
            this.Title = title;
        }
        public UserRole() { }
    }
}
