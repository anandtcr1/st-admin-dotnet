using AutoMapper;
using StudentAdmin.API.ViewModels;
using StudentAdmin.Application.Contracts.Students;
using StudentAdmin.Domain.Students;

namespace StudentAdmin.API.Profiles.Students
{
    public class FamilyMemberProfile: Profile
    {
        public FamilyMemberProfile()
        {
            CreateMap<FamilyMemberViewModel, FamilyMemberDto>();
            CreateMap<FamilyMemberViewModel, FamilyMemberNationalityDto>();
            CreateMap<FamilyMember, FamilyMemberDto>();
            CreateMap<FamilyMember, FamilyMemberNationalityDto>();

        }
    }
}
