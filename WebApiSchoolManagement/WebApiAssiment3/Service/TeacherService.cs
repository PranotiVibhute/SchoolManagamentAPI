using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Service
{
    public class TeacherService : ITeacher
    {
        private readonly SchoolManagementDbContext _dbContext;
        public TeacherService(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _dbContext.Teachers.ToListAsync();
        }
        public async Task<Teacher?> GetTeacherById(int id)
        {
            return await _dbContext.Teachers.FirstOrDefaultAsync(obj => obj.TeacherId == id);

        }
        public async Task<Teacher?> addTeacher(Teacher teacher)
        {
            var obj = new Teacher()
            {
                
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                SubjectId = teacher.SubjectId,
            };
            _dbContext.Teachers.Add(obj);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<Teacher?> UpdateTeacher(int id, Teacher teacher)
        {
            var obj = await _dbContext.Teachers.FirstOrDefaultAsync(index => index.TeacherId == id);
            if (obj != null)
            {
                obj.FirstName = teacher.FirstName;
                obj.LastName = teacher.LastName;
                obj.SubjectId = teacher.SubjectId;

                var result = await _dbContext.SaveChangesAsync();
                return result >= 0 ? obj : null;
            }
            return null;
        }
        public async Task<bool> removeTeacher(int id)
        {
            var obj = await _dbContext.Teachers.FirstOrDefaultAsync(obj => obj.TeacherId == id);
            if (obj == null)
            {
                return false;
            }
            _dbContext.Teachers.Remove(obj);
            var Teach = await _dbContext.SaveChangesAsync();
            return Teach >= 0;
        }
    }
}
