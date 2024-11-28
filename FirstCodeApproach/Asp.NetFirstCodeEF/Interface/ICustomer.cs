using Asp.NetFirstCodeEF.Entities;

namespace Asp.NetFirstCodeEF.Interface
{
    public interface ICustomer
    {
         Task<List<Customer>> GetAllCustomer();

    }
}
