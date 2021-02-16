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
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationLogic _logic;
        //private readonly IMapper _mapper;
        public ApplicationController(IApplicationLogic logic)
        {
            _logic = logic;
            //_mapper = mapper;
        }
        // GET: api/Application/1
        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetAllForProject(long id)
        {
            var applications = await _logic.GetAllForProject(id);
            if (applications == null)
                return NotFound("Ni jedan student se nije prijavio za ovaj projekat.");
            //var applicationsReturn = _mapper.Map<List<ApplicationForList>>(applications);
            //return Ok(applicationsReturn);
            return Ok(applications);
        }

        // GET: api/Application/5/10
        [HttpGet("{projectId}/{studentId}", Name = "Get")]
        public async Task<IActionResult> GetById(long projectId, int studentId)
        {
            var application = await _logic.GetById(projectId, studentId);
            if (application == null)
                return NotFound("Ni jedan student se nije prijavio za ovaj projekat.");
            return Ok(application);
        }

        // GET: api/Application/5/10
        [HttpGet("{projectId}/students", Name = "GetAcc")]
        public async Task<IActionResult> GetAccepted(long projectId)
        {
            var application = await _logic.GetAccepted(projectId);
            if (application == null)
                return NotFound("Ni jedan student se nije prijavio za ovaj projekat.");
            return Ok(application);
        }

        // GET: api/Application
        [HttpGet("{projectId}/criteria/{criteria}")]
        public async Task<IActionResult> GetByCriteriaForProject(long projectId, string criteria)
        {
            var applications = await _logic.GetByCriteriaForProject(projectId, criteria);
            if (applications == null)
                return NotFound("Ni jedan student se nije prijavio za ovaj projekat.");
            return Ok(applications);
        }

        // POST: api/application
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Application app)
        {
            if (!await _logic.Insert(app))
                return BadRequest("Neuspesno sacuvana prijava.");
            return Ok();
        }
        // PUT: api/Application/5
        [HttpPut("{projectId}/{studentId}")]
        public async Task<IActionResult> Put(int id, [FromBody] Application application)
        {
            if (!await _logic.Update(application))
                return BadRequest();
            return Ok();
        }

        // DELETE: api/Application/5
        [HttpDelete("{projectId}/{studentId}")]
        public async Task<IActionResult> Delete(long projectId, int studentId)
        {
            var applicationForDelete = await _logic.GetById(projectId, studentId);
            if (applicationForDelete == null)
                return NotFound();
            if (!await _logic.Delete(applicationForDelete))
                return BadRequest();
            return Ok();
        }
    }
}
