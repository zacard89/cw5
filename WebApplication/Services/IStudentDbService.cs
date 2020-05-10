using WebApplication.DTOs.Requests;

namespace WebApplication.Services
{
    public interface IStudentDbService
    {
        void EnrollStudent(EnrollStudentRequest request);
        void PromoteStudents(int semester, string studies);

    }
}