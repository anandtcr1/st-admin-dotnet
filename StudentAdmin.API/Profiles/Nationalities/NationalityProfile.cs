using AutoMapper;
using StudentAdmin.Application.Contracts.Nationalities;
using StudentAdmin.Domain.Nationalities;

namespace StudentAdmin.API.Profiles.Nationalities
{
    public class NationalityProfile : Profile
    {
        public NationalityProfile()
        {
            CreateMap<Nationality, NationalitiyDto>();
        }
    }
}
