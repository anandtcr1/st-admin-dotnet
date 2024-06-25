﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdmin.Application.Contracts.Students
{
    public class FamilyMemberDto
    {
        public int Id { get; set; }
        //public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RelationshipId { get; set; }
    }

    public class FamilyMemberNationalityDto : FamilyMemberDto
    {
        public int NationalityId { get; set; }
    }
}