using StudentAdmin.Domain.Nationalities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Domain
{
    public class Student
    {
        private Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("Nationality")]
        public int NationalityId { get; set; }

        public static Student Create(string firstName, string lastName, DateTime dateOfBirth)
        {
            return new Student(firstName, lastName, dateOfBirth);
        }

        public void Update(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public void UpdateNationality(int id, int nationalityId)
        {
            ID = id;
            NationalityId = nationalityId;
        }

        public virtual Nationality? Nationality { get; private set; }
    }
}
