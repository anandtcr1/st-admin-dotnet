using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Domain
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task<int> SaveChangesAsync();
    }
}
