using WebApiAssiment3.Entities;

namespace WebApiAssiment3.Interface
{
    public interface IStudent
    {
        Task<List<Student>>GetAllStudents();
        Task<Student?> GetStudentById(int id);

        Task<Student?> AddStudent(Student student);
        Task<Student?> UpdateStudent(int id,Student student);
        Task<bool> DeleteStudentById(int id);
                        

    }
}
