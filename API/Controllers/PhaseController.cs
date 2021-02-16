using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/phase")]
    [ApiController]
    public class PhaseController : ControllerBase
    {
        private readonly IPhaseLogic _logic;
        public PhaseController(IPhaseLogic logic)
        {
            _logic = logic;
        }

        // GET: api/Phase/5
        [HttpGet("{id}", Name = "GetPhase")]
        public async Task<IActionResult> Get(int id)
        {
            var phase = await _logic.GetById(id);
            if (phase == null)
                return NotFound();
            return Ok(phase);
        }
    }
}
