using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.API.ViewModels;
using StudentAdmin.Application.Contracts.Students;

namespace StudentAdmin.API.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentAppService _studentService;
        private readonly IFamilyMemberAppService _familyMemberService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentAppService service, IFamilyMemberAppService familyMemberService, IMapper mapper)
        {
            _studentService = service;
            _familyMemberService = familyMemberService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentViewModel viewModel)
        {
            var response = await _studentService.CreateAsync(viewModel.FirstName, viewModel.LastName, viewModel.DateOfBirth);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateStudentViewModel viewModel)
        {
            var response = await _studentService.UpdateAsync(id, viewModel.FirstName, viewModel.LastName, viewModel.DateOfBirth);
            return Ok(response);
        }

        [HttpGet("{id}/Nationality")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _studentService.GetAsync(id);
            return Ok(response);
        }

        [HttpPut("{id}/Nationality/{nationalityId}")]
        public async Task<IActionResult> UpdateNationalityAsync(int id, int nationalityId)
        {
            var response = await _studentService.UpdateNationalityAsync(id, nationalityId);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Students()
        {
            var response = await _studentService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}/FamilyMembers")]
        public async Task<IActionResult> GetFamilyMembersAsync(int id)
        {
            var response = await _familyMemberService.GetByStudentIdAsync(id);
            return Ok(response);
        }

        [HttpPost("{id}/FamilyMembers")]
        public async Task<IActionResult> CreateFamilyMemberAsync(int id, FamilyMemberViewModel familyMemberViewModel)
        {
            var response = await _familyMemberService.CreateAsync(id, familyMemberViewModel.FirstName, familyMemberViewModel.LastName, familyMemberViewModel.DateOfBirth, familyMemberViewModel.RelationshipId, familyMemberViewModel.NationalityId);
            return Ok(response);
        }

        
    }
}
