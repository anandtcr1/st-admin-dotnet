using AutoMapper;
using StudentAdmin.API.ViewModels;
using StudentAdmin.Application.Contracts.Students;
using StudentAdmin.Domain;

namespace StudentAdmin.API.Profiles.Students
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentViewModel, StudentDto>();
            //CreateMap<StudentViewModel, StudentNationalityDto>();
            CreateMap<Student, StudentDto>();
            //CreateMap<Student, StudentNationalityDto>();
        }
    }
}
