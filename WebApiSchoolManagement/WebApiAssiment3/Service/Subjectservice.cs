using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Service
{
    public class Subjectservice:ISubject
    {
        private readonly SchoolManagementDbContext _dbContext; 

        public Subjectservice (SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Subject>> GetAllSubjects()
        {
            return await _dbContext.Subjects.ToListAsync();
        }
        public async Task<Subject?> GetSubjectById(int id)
        {
            return await _dbContext.Subjects.FirstOrDefaultAsync(obj => obj.SubjectId == id);

        }
        public async Task<Subject?> AddSubject(Subject subject)
        {
            var sub = new Subject()
            {                
                SubjectName = subject.SubjectName,
            };
            _dbContext.Subjects.Add(sub);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? subject : null;
        }
        public async Task<Subject?> UpdateSubject(int id, Subject subject)
        {
            var sub = await _dbContext.Subjects.FirstOrDefaultAsync(obj => obj.SubjectId == id);
            if (sub != null)
            {
                sub.SubjectId = subject.SubjectId;
                sub.SubjectName = subject.SubjectName;

            }
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? sub:null;
        }
        public async Task<bool> DeleteSubject(int id)
        {
            var sub=await _dbContext.Subjects.FirstOrDefaultAsync(obj=>obj.SubjectId == id);
            if(sub!=null)
            {
                _dbContext.Subjects.Remove(sub);
                var result = await _dbContext.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }

    }
}
