using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Domain.Students
{
    public interface IFamilyMemberRepository
    {
        Task<FamilyMember> CreateAsync(FamilyMember familyMember);
        Task<List<FamilyMember>> GetByStudentIdAsync(int studentId);
        Task<FamilyMember> GetAsync(int id);
        Task<FamilyMember> GetAsync(int id, int nationalityId);
        Task DeleteAsync(FamilyMember familyMember);
        Task<int> SaveChangesAsync();

    }
}
