using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Service
{
    public class ClassService: IClass
    {
        private readonly SchoolManagementDbContext _dbContext;

        public ClassService (SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Class>> GetAllClasses()
        {
            return await _dbContext.Classes.ToListAsync();
        }
        public async Task<Class?> GetClassById(int id)
        {
            return await _dbContext.Classes.FirstOrDefaultAsync(obj=>obj.ClassId==id);
        }
        public async Task<Class?> AddClass(Class @class)
        {
            var obj = new Class()
            {
                ClassName = @class.ClassName,
                TeacherId = @class.TeacherId,
            };
            _dbContext.Classes.Add(obj);
            var cls = await _dbContext.SaveChangesAsync();
            return cls >= 0 ? obj:null;
        }
        public async Task<Class?> UpdateClass(int id, Class @class)
        {
            var cls = await _dbContext.Classes.FirstOrDefaultAsync(index => index.ClassId == id);
            if (cls != null)
            {
                cls.ClassName = @class.ClassName;
                cls.TeacherId = @class.TeacherId;
            }
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? cls:null;
        }
        public async Task<bool> DeleteByid(int id)
        {
            var obj=await _dbContext.Classes.FirstOrDefaultAsync(obj=>obj.ClassId==id);
            if(obj!=null)
            {
                _dbContext.Classes.Remove(obj);
                var cls=await _dbContext.SaveChangesAsync();
                return (cls>=0);
            }
            return false;
        }
    }
}
