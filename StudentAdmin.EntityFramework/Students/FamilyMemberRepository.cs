using Microsoft.EntityFrameworkCore;
using StudentAdmin.Domain.Students;
using StudentAdmin.EntityFramework.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.EntityFramework.Students
{
    public class FamilyMemberRepository : IFamilyMemberRepository
    {
        private readonly DatabaseContext _databaseContext;
        public FamilyMemberRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<FamilyMember> CreateAsync(FamilyMember familyMember)
        {
            await _databaseContext.FamilyMembers.AddAsync(familyMember);
            _databaseContext.SaveChanges();
            return familyMember;
        }



        public async Task DeleteAsync(FamilyMember familyMember)
        {
            _databaseContext.FamilyMembers.Remove(familyMember);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<FamilyMember> GetAsync(int id)
        {
            return await _databaseContext.FamilyMembers
                .Where(x => x.ID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<FamilyMember> GetAsync(int id, int nationalityId)
        {
            return await _databaseContext.FamilyMembers
                .Where(x => x.ID == id && x.NationalityId == nationalityId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<FamilyMember>> GetByStudentIdAsync(int studentId)
        {
            return await _databaseContext.FamilyMembers
                .Where(x => x.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }

    }
}
