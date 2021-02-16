using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Logic.ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/projectplan")]
    [ApiController]
    public class ProjectPlanController : ControllerBase
    {
        private readonly IProjectPlanLogic _logic;
        //private readonly IMapper _mapper;
        public ProjectPlanController(IProjectPlanLogic logic)
        {
            _logic = logic;
            //_mapper = mapper;
        }
        // GET: api/ProjectPlan/project/1
        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetForProject(long id)
        {
            var plans = await _logic.GetByProject(id);
            if (plans == null)
                return NotFound("Nisu pronadjeni planovi projekta koji ste odabrali.");
            return Ok(plans);
        }

        // GET: api/ProjectPlan/criteria/plan
        [HttpGet("criteria/{criteria}")]
        public async Task<IActionResult> GetByCriteria(string criteria)
        {
            var plans = await _logic.GetByCriteria(criteria);
            if (plans == null)
                return NotFound("Nisu pronadjeni planovi projekta prema definisanom kriterijumu.");
            return Ok(plans);
        }

        // GET: api/ProjectPlan/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPlanId(int id)
        {
            var plans = await _logic.GetById(id);
            if (plans == null)
                return NotFound("Ne postoji plan projekta sa ovim id-jem.");
            return Ok(plans);
        }

        // POST: api/ProjectPlan/2
        [HttpPost("{employeeId}")]
        public async Task<IActionResult> Post([FromBody] ProjectPlan projectPlanForInsert, int employeeId)
        {
            //var projectPlan = _mapper.Map<ProjectPlan>(projectPlanForInsert);
            if (!await _logic.Insert(projectPlanForInsert))
                return BadRequest("Neuspešno sačuvan plan projekta");
            return Ok();
        }

        // PUT: api/ProjectPlan/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProjectPlan projectPlan)
        {
            //var projectPlan = _mapper.Map<ProjectPlan>(projectPlanForUpdate);
            if (!await _logic.Update(projectPlan))
                return BadRequest("Neuspešno izmenjen plan projekta");
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var plan = await _logic.GetById(id);
            if (plan == null)
                return NotFound("Ne postoji plan projekta sa ovim id-jem.");
            if(!await _logic.Delete(plan))
                return BadRequest("Nije uspelo brisanje plana projekta.");
            return Ok();
        }





        
            //if (employeeId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            //    return Unauthorized("Niste prijavljeni");
    }
}
