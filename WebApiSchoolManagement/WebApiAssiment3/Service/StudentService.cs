using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Service
{
    public class StudentService: IStudent
    {
        private readonly SchoolManagementDbContext _dbContext;
        public StudentService(SchoolManagementDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<List<Student>>GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }
        public async Task<Student?> GetStudentById(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(obj => obj.StudentId == id);
        }
        public async Task<Student?> AddStudent(Student student)
        {
            var obj = new Student()
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                DateOfBirth = student.DateOfBirth,
                ClassId = student.ClassId,
            };
            _dbContext.Students.Add(obj);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<Student?> UpdateStudent(int id ,Student updateStudent)
        {
            var result=await _dbContext.Students.FirstOrDefaultAsync(obj=>obj.StudentId == id);
            if(result !=null)
            {
                result.StudentId = updateStudent.StudentId;
                result.Firstname = updateStudent.Firstname;
                result.Lastname = updateStudent.Lastname;
                result.DateOfBirth = updateStudent.DateOfBirth;
                result.ClassId = updateStudent.ClassId; 
            }
            var obj = await _dbContext.SaveChangesAsync();
            return obj >= 0 ? result : null;
        }
        public async Task<bool> DeleteStudentById(int id)
        {
            var obj = await _dbContext.Students.FirstOrDefaultAsync(obj => obj.StudentId == id);
            if (obj != null)
            { 
                _dbContext.Students.Remove(obj);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }
       
            
    }
}
