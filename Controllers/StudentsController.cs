using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class StudentsController : ControllerBase
    {
        public static List<Students> GetStudents()
        {
            var students = new List<Students>();

            students.Add(new Students() { Id = 1, First_name = "Lucas", Last_name = "Theze", Age = 21 });
            students.Add(new Students() { Id = 2, First_name = "Aurélien", Last_name = "Izak", Age = 19 });
            students.Add(new Students() { Id = 3, First_name = "Aurélien", Last_name = "Rebourg", Age = 19 });
            students.Add(new Students() { Id = 4, First_name = "Andy", Last_name = "TchingTchong", Age = 20 });

            return students;
        }

        [HttpGet]
        public IEnumerable<Students> GetStudents_List()
        {
            return GetStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<Students> GetStudents_Id(int Id)
        {
            var students = GetStudents().Find(x => x.Id == Id);
            if (students == null)
            {
                return NotFound();
            }
            else
            {
                return students;
            }

        }
    }
}
