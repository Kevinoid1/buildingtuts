using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using BuildingTuts.Academy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingTuts.AcademyStudent
{
    
    [AutoMapFrom(typeof(AcademyStudents))]
    public class StudentDto : EntityDto<int?>
    {
        
       //public int TenantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
