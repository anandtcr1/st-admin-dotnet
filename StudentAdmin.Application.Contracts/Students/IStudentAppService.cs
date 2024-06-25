using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Contracts.Students
{
    public interface IStudentAppService
    {
        Task<StudentDto> CreateAsync(string firstName, string lastName, DateTime dateOfBirth);
        Task<StudentDto> UpdateAsync(int id, string firstName, string lastName, DateTime dateOfBirth);
        Task<StudentDto> UpdateNationalityAsync(int id, int nationlaityId);
        Task<StudentDto> GetAsync(int id);
        Task<List<StudentDto>> GetAllAsync();
    }
}
