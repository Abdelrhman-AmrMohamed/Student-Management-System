using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities
{
    public class Subjects
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentsSubjects>();
            DepartmetsSubjects = new HashSet<DepartmentsSubjects>();
        }
        [Key]
        public int SubID { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
        public virtual ICollection<StudentsSubjects> StudentsSubjects { get; set; }
        public virtual ICollection<DepartmentsSubjects> DepartmetsSubjects { get; set; }
    }
}
