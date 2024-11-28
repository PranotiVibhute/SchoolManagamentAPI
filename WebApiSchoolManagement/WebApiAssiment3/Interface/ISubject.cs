using WebApiAssiment3.Entities;

namespace WebApiAssiment3.Interface
{
    public interface ISubject
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject?> GetSubjectById(int id);
        Task<Subject?> AddSubject(Subject subject);
        Task<Subject?> UpdateSubject(int id,Subject subject);
        Task<bool> DeleteSubject(int id);

    }
}
