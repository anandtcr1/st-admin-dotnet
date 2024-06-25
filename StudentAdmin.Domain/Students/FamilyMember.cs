using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Domain.Students
{
    public class FamilyMember
    {
        private FamilyMember(int studentId, string firstName, string lastName, DateTime dateOfBirth, int relationshipId, int nationalityId)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            RelationshipId = relationshipId;
            NationalityId = nationalityId;
        }

        [Key]
        public int ID { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
        [ForeignKey("Nationality")]
        public int NationalityId { get; set; }

        public static FamilyMember Create(int studentId, string firstName, string lastName, DateTime dateOfBirth, int relationshipId, int nationalityId)
        {
            return new FamilyMember(studentId, firstName, lastName, dateOfBirth, relationshipId, nationalityId);
        }

        //public void Update(int id, int studentId, string firstName, string lastName, DateTime dateOfBirth)
        //{
        //    ID = id;
        //    StudentId = studentId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    DateOfBirth = dateOfBirth;

        //}
        public void Update(int id, string firstName, string lastName, DateTime dateOfBirth, int relationshipId)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            RelationshipId = relationshipId;
        }

        public void UpdateNationality(int id, int nationalityId)
        {
            ID = id;
            NationalityId = nationalityId;
        }
    }
}
