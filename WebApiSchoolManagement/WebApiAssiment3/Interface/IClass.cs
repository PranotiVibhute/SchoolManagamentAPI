using WebApiAssiment3.Entities;

namespace WebApiAssiment3.Interface
{
    public interface IClass
    {
        Task<List<Class>> GetAllClasses();
        Task<Class?>GetClassById(int id);
        Task<Class?> AddClass(Class @class);
        Task<bool>DeleteByid(int id);
    }
}
