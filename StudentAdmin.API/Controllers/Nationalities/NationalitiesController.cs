using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.Application.Contracts.Nationalities;

namespace StudentAdmin.API.Controllers.Nationalities
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalitiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly INationalityAppService _appService;

        public NationalitiesController(IMapper mapper, INationalityAppService appService)
        {
            _mapper = mapper;
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var response = await _appService.GetListAsync();
            return Ok(response);
        }
    }
}
