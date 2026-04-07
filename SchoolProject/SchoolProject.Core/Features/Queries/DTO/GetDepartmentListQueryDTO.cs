using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Features.Queries.DTO
{
    public class GetDepartmentListQueryDTO
    {
        public int DID { get; set; }
        public string DName { get; set; }
        public virtual ICollection<Students> Students { get; set; }
    }
}
