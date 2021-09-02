using Abp.Domain.Repositories;
using Abp.UI;
using BuildingTuts.Academy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingTuts.AcademyStudent
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentManager : BuildingTutsAppServiceBase
    {
        private readonly IRepository<AcademyStudents> _repo;
        

        public StudentManager(IRepository<AcademyStudents> repo)
        {
            _repo = repo;
        }

        //create a student entity
        public void StudentCreator(StudentDto input)
        {
            //check what was sent to us by client
            if (input != null)
            {

                //to map from StudentDto to AcademyStudents
                var studentObj = ObjectMapper.Map<AcademyStudents>(input);
                studentObj.TenantId = this.TenantId();
                
                //this adds waht the client has provided to our table in the database.
                //The table is AcademyStudents
                _repo.Insert(studentObj);
            }
            else
            {
                throw new UserFriendlyException("Input is empty");
            }
        }


        //gets all the employees in the database
        public List<StudentDto> GetStudents()
        {
            
            var itemFromRepo = _repo.GetAll().ToList();
            var itemMapped = ObjectMapper.Map<List<StudentDto>>(itemFromRepo);
            return itemMapped;
        }

        //retrieve a single user
        public StudentDto GetStudent(int Id)
        {
            //check the database table to find a match for the Id
            var studentFromRepo = _repo.Get(Id);
            if (studentFromRepo != null)
            {
                var studentMapped = ObjectMapper.Map<StudentDto>(studentFromRepo);
                return studentMapped;
            }
            else
                throw new UserFriendlyException("Student not found");
        }

        //update the student record
        public StudentDto UpdateStudent(StudentDto input)
        {
            //find the student we want to update the record
            //FirstOrDefault LINQ extension method that takes in a delegate which is a predicate
            //a delegate just means a function pointer
            var studentFromRepo = _repo.FirstOrDefault(e => e.Id == input.Id);


            // var employeeMapped = ObjectMapper.Map<EmployeeDto>(employeeFromRepo);
            studentFromRepo.DateOfBirth= input.DateOfBirth;
            studentFromRepo.Department = input.Department;
            studentFromRepo.FirstName = input.FirstName;
            studentFromRepo.LastName = input.LastName;
            studentFromRepo.Gender = input.Gender;
           
            //update the table in the database
            _repo.Update(studentFromRepo);
            return input;
        }
        //delete a student from the database table Students
        //access-moidifier;  return type; name of the method; parameters
        public void DeleteStudent(int Id)
        {
            var studentFromRepo = _repo.FirstOrDefault(e => e.Id == Id);
            //var studentMapped = ObjectMapper.Map<StudentDto>(studentFromRepo);
            _repo.Delete(studentFromRepo);
            CurrentUnitOfWork.SaveChanges();
            //return employeeMapped;
            
        }

        

    }
}
