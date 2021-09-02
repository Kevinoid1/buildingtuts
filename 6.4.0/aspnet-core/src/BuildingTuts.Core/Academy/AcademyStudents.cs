
using Abp.Domain.Entities;
using System;

namespace BuildingTuts.Academy
{
    //[Table("tbl_students")]
    public class AcademyStudents : Entity, IMustHaveTenant
    {
      
        public int TenantId { get ; set ; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
