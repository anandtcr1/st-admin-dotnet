using AutoMapper;
using StudentAdmin.Application.Contracts.Students;
using StudentAdmin.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Students
{
    public class FamilyMemberAppService: IFamilyMemberAppService
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IMapper _mapper;

        public FamilyMemberAppService(IFamilyMemberRepository familyMemberRepository, IMapper mapper)
        {
            _familyMemberRepository = familyMemberRepository;
            _mapper = mapper;
        }

        public async Task<FamilyMemberDto> CreateAsync(int studentId, string firstName, string lastName, DateTime dateOfBirth, int relationshipId, int nationalityId)
        {
            var familyMember = FamilyMember.Create(studentId, firstName, lastName, dateOfBirth, relationshipId, nationalityId);
            await _familyMemberRepository.CreateAsync(familyMember);
            return _mapper.Map<FamilyMemberDto>(familyMember);
        }



        public async Task DeleteAsync(int id)
        {
            var familyMember = await _familyMemberRepository.GetAsync(id);
            await _familyMemberRepository.DeleteAsync(familyMember);
        }

        public async Task<FamilyMemberNationalityDto> GetAsync(int id)
        {
            var familyMember = await _familyMemberRepository.GetAsync(id);
            return _mapper.Map<FamilyMemberNationalityDto>(familyMember);
        }

        public async Task<FamilyMemberNationalityDto> GetAsync(int id, int nationalityId)
        {
            var familyMember = await _familyMemberRepository.GetAsync(id, nationalityId);
            return _mapper.Map<FamilyMemberNationalityDto>(familyMember);
        }

        public async Task<List<FamilyMemberDto>> GetByStudentIdAsync(int studentId)
        {
            var list = await _familyMemberRepository.GetByStudentIdAsync(studentId);
            return _mapper.Map<List<FamilyMemberDto>>(list);
        }

        //public async Task<FamilyMemberDto> UpdateAsync(int id, int studentId, string firstName, string lastName, DateTime dateOfBirth)
        //{
        //    var familyMember = await _familyMemberRepository.GetAsync(id);
        //    familyMember.Update(id, studentId, firstName, lastName, dateOfBirth);
        //    await _familyMemberRepository.SaveChangesAsync();
        //    return _mapper.Map<FamilyMemberDto>(familyMember);
        //}

        public async Task<FamilyMemberDto> UpdateAsync(int id, string firstName, string lastName, DateTime dateOfBirth, int nationalityId)
        {
            var familyMember = await _familyMemberRepository.GetAsync(id);
            familyMember.Update(id, firstName, lastName, dateOfBirth, nationalityId);
            await _familyMemberRepository.SaveChangesAsync();
            return _mapper.Map<FamilyMemberDto>(familyMember);
        }

        public async Task<FamilyMemberNationalityDto> UpdateNationality(int id, int nationalityId)
        {
            var familyMember = await _familyMemberRepository.GetAsync(id);
            if(familyMember.ID <= 0)
            {
                throw new ArgumentException("Id doesn't exists");
            }
            familyMember.UpdateNationality(id, nationalityId);
            await _familyMemberRepository.SaveChangesAsync();
            return _mapper.Map<FamilyMemberNationalityDto>(familyMember);
        }

    }
}
