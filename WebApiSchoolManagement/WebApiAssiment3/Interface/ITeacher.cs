using WebApiAssiment3.Entities;

namespace WebApiAssiment3.Interface
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher?> GetTeacherById(int id);
        Task<Teacher?>addTeacher(Teacher teacher);
        Task<Teacher?>UpdateTeacher(int id,Teacher teacher);
        Task<bool>removeTeacher(int id);
    }
}
