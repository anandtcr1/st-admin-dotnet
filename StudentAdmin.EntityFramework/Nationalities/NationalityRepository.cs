using Microsoft.EntityFrameworkCore;
using StudentAdmin.Application.Contracts.Nationalities;
using StudentAdmin.Domain.Nationalities;
using StudentAdmin.EntityFramework.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.EntityFramework.Nationalities
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly DatabaseContext _databaseContext;
        public NationalityRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Nationality>> GetListAsync()
        {
            return await _databaseContext.Nationalities.ToListAsync();
        }
    }
}
