using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Logic.ILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeLogic _logic;
        private readonly IConfiguration _config;
        //private readonly IMapper _mapper;

        public EmployeeController(IEmployeeLogic logic, IConfiguration config)
        {
            _logic = logic;
            _config = config;
            //_mapper = mapper;
        }

        // GET: api/Employee/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var employeeDb = await _logic.Login(username.ToLower(), password.ToLower());
            if (employeeDb == null)
                return Unauthorized();

            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, employeeDb.EmployeeID.ToString()),
               new Claim(ClaimTypes.Name, employeeDb.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_config.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                employee = employeeDb
            });
        }
    }
}
