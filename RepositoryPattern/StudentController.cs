using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class StudentController
    {
        private IStudentRepository studentRepository;

        public StudentController()
        {
            this.studentRepository = new StudentRepository(new SchoolContext());
        }

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public Student GetStudent(int id)
        {
            var tempStu = studentRepository.GetStudentByID(id);
            return tempStu;
        }
    }
}
