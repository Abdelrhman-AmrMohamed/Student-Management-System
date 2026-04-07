using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Departments
    {
        public Departments()
        {
            Students = new HashSet<Students>();
            DepartmentSubjects = new HashSet<DepartmentsSubjects>();
        }
        [Key]
        public int DID { get; set; }
        [StringLength(500)]
        public string DName { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<DepartmentsSubjects> DepartmentSubjects { get; set; }
    }
}
