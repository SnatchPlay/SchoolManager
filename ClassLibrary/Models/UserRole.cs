using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        [Column ("role_name")]
        public string RoleName { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }
        public UserRole(int id, string title, DateTime rowInsertTime, DateTime rowUpdateTime)
        {
            this.Id = id;
            this.RoleName = title;
            this.RowInsertTime = rowInsertTime;
            this.RowUpdateTime = rowUpdateTime;
        }
        public UserRole() { }
    }
}
