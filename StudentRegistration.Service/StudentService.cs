using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistration.Model;
using StudentRegistration.Repository;
using StudentRegistration.ViewModel;

namespace StudentRegistration.Service
{
    public class StudentService:BaseService
    {
        private StudentRepository repository;
        public StudentService(BusinessDbContext db) : base(db)
        {
             repository = new StudentRepository(DbContext);
        }

        public List<StudentViewModel> GetAll()
        {
            IQueryable<Student> queryable = repository.GetAll();
            List<StudentViewModel> list = queryable.Select(x => new StudentViewModel(x)).ToList();
            return list;
        }

        public string Add(Student student)
        {
            return repository.Add(student);
        }
    }
}
