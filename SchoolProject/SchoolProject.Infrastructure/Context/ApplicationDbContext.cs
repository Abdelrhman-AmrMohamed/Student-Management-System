using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolProject.Data;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<DepartmentsSubjects> DepartmentsSubjects { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentsSubjects> StudentsSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; } 

    }
}
