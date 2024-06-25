using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.API.ViewModels;
using StudentAdmin.Application.Contracts.Students;

namespace StudentAdmin.API.Controllers.Students
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyMembersController : ControllerBase
    {
        private readonly IFamilyMemberAppService _service;
        private readonly IMapper _mapper;

        public FamilyMembersController(IFamilyMemberAppService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFamilyMember(int id, FamilyMemberViewModel familyMemberViewModel)
        {
            var response = await _service.UpdateAsync(id, familyMemberViewModel.FirstName, familyMemberViewModel.LastName, familyMemberViewModel.DateOfBirth, familyMemberViewModel.RelationshipId);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFamilyMember(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}/Nationality/{nationalityId}")]
        public async Task<IActionResult> GetNationality(int id, int nationalityId)
        {
            var response = await _service.GetAsync(id, nationalityId);
            return Ok(response);
        }

        [HttpPut("{id}/Nationality/{nationalityId}")]
        public async Task<IActionResult> UpdateNationality(int id, int nationalityId)
        {
            var response = await _service.UpdateNationality(id, nationalityId);
            return Ok(response);
        }
    }
}
