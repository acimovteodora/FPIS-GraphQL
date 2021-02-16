using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logic.ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _logic;
        //private readonly IMapper _mapper;
        public StudentController(IStudentLogic logic)
        {
            _logic = logic;
            //_mapper = mapper;
        }
        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _logic.GetAll();
            if (students == null)
                return NotFound($"Studenti nisu uneti u sistem!");
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Student student = await _logic.GetById(id);
            if (student == null)
                return NotFound($"Student čiji je id: {id} ne postoji!");
            return Ok(student);
        }

        // GET: api/Student/igor
        [HttpGet("criteria/{criteria}")]
        public async Task<IActionResult> Get(string criteria)
        {
            var students = await _logic.GetByCriteria(criteria);
            if (students == null)
                return NotFound();
            return Ok(students);
        }

        // GET: api/Student/project/2
        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetByProject(long id)
        {
            List<Student> students = await _logic.GetAcceptedByProject(id);
            if (students == null)
                return NotFound($"Studenti nisu prihvaceni za rad na ovom projektu!");
            return Ok(students);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            if(await _logic.Insert(student))
                return StatusCode(201);
            return BadRequest("Nije uspelo čuvanje studenta: " + student.Name + " " + student.Surname);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            var s = await _logic.GetById(id);
            s.Name = student.Name;
            s.Surname = student.Surname;
            s.YearOfStudy = student.YearOfStudy;
            s.Department = student.Department;
            s.Index = student.Index;
            if (await _logic.Update(s))
                return Ok();
            return BadRequest("Došlo je do greške prilikom izmene podataka o studentu: " + student.Name + " " + student.Surname);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _logic.GetById(id);
            if (student == null)
                return NotFound("Ne postoji student kojeg želite da obrišete.");
            if (await _logic.Delete(student))
                return Ok("Uspešno ste obrisali studenta: " + student.Name + " " + student.Surname);
            return BadRequest("Došlo je do greške prilikom brisanja studenta: " + student.Name + " " + student.Surname);
        }
    }
}
