using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Interface
{
    public interface IStudentService
    {
        public Task<List<Students>> GetListStudentAsync();
        public Task<Students> GetStudentByIDAsync(int id);
        public Task<string> AddStudentAsync(Students student);
        public Task<string> EditStudentAsync(Students student);
        public Task<string> DeleteStudentAsync(Students student);
        public Task<bool> IsNameExistAsync(string name);
        public Task<bool> IsNameExistAndNotSameIdAsync(string name, int id);
    }
}
