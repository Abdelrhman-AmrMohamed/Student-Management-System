using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interface;

namespace SchoolProject.Service.Repository
{
    public class StudentService : IStudentService
    {

        #region Fields
        private readonly IStudentRepositories _studentRepostories;
        #endregion
        #region Constructors
        public StudentService(IStudentRepositories studentRepostories)
        {
            _studentRepostories = studentRepostories;
        }


        #endregion
        #region HandleFunctions
        public async Task<List<Students>> GetListStudentAsync()
        {
            return await _studentRepostories.GetStudentListAsync();
        }

        public async Task<Students> GetStudentByIDAsync(int id)
        {
            var student = await _studentRepostories.GetTableNoTracking().Include(x => x.Department).FirstOrDefaultAsync(s => s.StudID == id);
            return student;
        }
        public async Task<string> AddStudentAsync(Students student)
        {
            //check if the name is exist 
            var StudentResult = _studentRepostories.GetTableNoTracking().FirstOrDefault(s => s.Name == student.Name);
            if (StudentResult != null) return "Exist";
            //Add Student
            await _studentRepostories.AddAsync(student);
            return "Success";
        }

        public Task<bool> IsNameExistAsync(string name)
        {
            var result = _studentRepostories.GetTableNoTracking().AnyAsync(s => s.Name == name);
            return result;
        }

        public Task<bool> IsNameExistAndNotSameIdAsync(string name, int id)
        {
            var result = _studentRepostories.GetTableNoTracking().AnyAsync(s => s.Name == name && s.StudID != id);
            return result;
        }

        public async Task<string> EditStudentAsync(Students student)
        {
            await _studentRepostories.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteStudentAsync(Students student)
        {
            var trans = _studentRepostories.BeginTransaction();
            try
            {
                await _studentRepostories.DeleteAsync(student);
                trans.CommitAsync();
                return "Deleted";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Faild";
            }

        }

        #endregion
    }
}
