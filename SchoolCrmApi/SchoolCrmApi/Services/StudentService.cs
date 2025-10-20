using SchoolCrmApi.Data;
using SchoolCrmApi.Models;
using SchoolCrmApi.Services.IServices;

namespace SchoolCrmApi.Services
{
    public class StudentService : CrudService<Student>, IStudentService
    {
        public StudentService(SchoolCrmDbContext context) : base(context)
        {
        }
    }
}
