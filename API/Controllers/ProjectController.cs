using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Logic.ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectLogic _logic;
        //private readonly IMapper _mapper;
        public ProjectController(IProjectLogic logic)
        {
            _logic = logic;
            //_mapper = mapper;
        }
        // GET: api/Project
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _logic.GetAll();
            if (projects == null)
                return NotFound("Ne postoji definisan ni jedan projekat.");
            //var returnProjects = _mapper.Map<List<ProjectForList>>(projects);
            //return Ok(projects);
            return Ok(projects);
        }

        // GET: api/Project/5
        [HttpGet("{id}", Name = "GetP")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _logic.GetById(id);
            if (project == null)
                return NotFound("Ne postoji projekat čiji je id: " + id);
            return Ok(project);
        }

        // GET: api/project/criteria/{value}
        [HttpGet("criteria/{value}")]
        public async Task<IActionResult> Get(string value)
        {
            var projects = await _logic.GetByCriteria(value);
            if (projects == null)
                return NotFound("Ne postoji ni jedan projekat koji se uklapa u ovaj kriterijum.");
            //var returnProjects = _mapper.Map<List<ProjectForList>>(projects);
            //return Ok(returnProjects);
            return Ok(projects);
        }

    }
}
