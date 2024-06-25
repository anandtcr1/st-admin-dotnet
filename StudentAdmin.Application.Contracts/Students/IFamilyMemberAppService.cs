using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Contracts.Students
{
    public interface IFamilyMemberAppService
    {
        Task<FamilyMemberDto> CreateAsync(int studentId, string firstName, string lastName, DateTime dateOfBirth, int relationshipId, int nationalityId);
        //Task<FamilyMemberDto> UpdateAsync(int id, int studentId, string firstName, string lastName, DateTime dateOfBirth);
        Task<FamilyMemberDto> UpdateAsync(int id, string firstName, string lastName, DateTime dateOfBirth, int nationalityId);
        Task<FamilyMemberNationalityDto> UpdateNationality(int id, int nationalityId);
        Task<FamilyMemberNationalityDto> GetAsync(int id);
        Task<FamilyMemberNationalityDto> GetAsync(int id, int nationalityId);
        Task<List<FamilyMemberDto>> GetByStudentIdAsync(int studentId);
        Task DeleteAsync(int id);

    }
}
