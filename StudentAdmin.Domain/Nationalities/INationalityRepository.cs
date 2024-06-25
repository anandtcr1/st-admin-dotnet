using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Domain.Nationalities
{
    public interface INationalityRepository
    {
        Task<List<Nationality>> GetListAsync();
    }
}
