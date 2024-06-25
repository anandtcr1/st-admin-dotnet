using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Contracts.Students
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityId { get; set; }
    }

    //public class StudentNationalityDto : StudentDto
    //{
    //    public int NationalityId { get; set; }
    //}
}
