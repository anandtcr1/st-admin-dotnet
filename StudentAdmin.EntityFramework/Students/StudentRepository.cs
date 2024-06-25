using StudentAdmin.Domain;
using StudentAdmin.EntityFramework.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentAdmin.EntityFramework.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _databaseContext;
        public StudentRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<Student> CreateAsync(Student student)
        {
            await _databaseContext.Students.AddAsync(student);
            _databaseContext.SaveChanges();
            return student;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _databaseContext.Students
                .OrderByDescending(x => x.ID).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _databaseContext.Students
                .Where(x => x.ID == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }
    }
}
