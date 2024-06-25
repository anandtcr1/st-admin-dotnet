using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdmin.Domain;
using StudentAdmin.Domain.Students;
using StudentAdmin.Domain.Nationalities;
namespace StudentAdmin.EntityFramework.EntityFrameworkCore
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
    }
}
