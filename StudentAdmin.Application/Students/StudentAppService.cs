using AutoMapper;
using StudentAdmin.Application.Contracts.Students;
using StudentAdmin.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Students
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentAppService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> CreateAsync(string firstName, string lastName, DateTime dateOfBirth)
        {
            var student = Student.Create(firstName, lastName, dateOfBirth);
            await _studentRepository.CreateAsync(student);
            await _studentRepository.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> UpdateAsync(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            student.Update(student.ID, firstName, lastName, dateOfBirth);
            await _studentRepository.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> UpdateNationalityAsync(int id, int nationlaityId)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            student.UpdateNationality(id, nationlaityId);
            await _studentRepository.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }

        //public async Task<StudentNationalityDto> UpdateAsync(StudentNationalityDto studentDto)
        //{
        //    var student = await _studentRepository.GetByIdAsync(studentDto.Id);
        //    student.Update(student.ID, studentDto.FirstName, studentDto.LastName, studentDto.DateOfBirth, studentDto.NationalityId);
        //    await _studentRepository.SaveChangesAsync();
        //    return _mapper.Map<StudentNationalityDto>(student);
        //}

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var list = await _studentRepository.GetAllAsync();
            return _mapper.Map<List<StudentDto>>(list);
        }

        public async Task<StudentDto> GetAsync(int id)
        {
            var student= await _studentRepository.GetByIdAsync(id);
            return _mapper.Map<StudentDto>(student);
        }

        
    }
}
