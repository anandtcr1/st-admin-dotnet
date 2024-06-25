using AutoMapper;
using StudentAdmin.Application.Contracts.Nationalities;
using StudentAdmin.Domain.Nationalities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Nationalities
{
    public class NationalityAppService : INationalityAppService
    {
        private readonly IMapper _mapper;
        private readonly INationalityRepository _repository;

        public NationalityAppService(IMapper mapper, INationalityRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<NationalitiyDto>> GetListAsync()
        {
            var list = await _repository.GetListAsync();
            return _mapper.Map<List<NationalitiyDto>>(list);
        }
    }
}
