using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.DataAccess;
using WebApplication1.DataAccess.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;


        public EmployeeController(IUnitOfWork unitOfWork, ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
           
            _dbContext = dbContext;
            _configuration = configuration;
          
        }

        [Authorize]
        [HttpGet("GetRecord")]
        public IActionResult GetRecord()
        {
            try
            {
                var empList = _unitOfWork.EmployeeService.GetEmpList().ToList();

                return Ok(new { data = empList });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize]
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var emp = _unitOfWork.EmployeeService.GetEmpById(id);

                return Ok(new { status = 200, data = emp });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize]
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employees emp)
        {
            try
            {
                var addEmp = _unitOfWork.EmployeeService.addEmp(emp);

                return Ok(new { status = 200, data = addEmp });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize]
        [HttpPost("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employees emp)
        {
            try
            {
                var updateEmp = _unitOfWork.EmployeeService.updateEmp(emp);

                return Ok(new { status = 200, data = updateEmp });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [Authorize]
        [HttpPost("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var deleteEmp = _unitOfWork.EmployeeService.deleteEmp(id);

                return Ok(new { status = 200, data = deleteEmp });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("LoginEmployee/{name}/{age}")]
        public IActionResult LoginEmployee(string name, int age)
        {
            try
            {
                var getEmp = _unitOfWork.EmployeeService.loginEmp(name, age);

                if(getEmp == null)
                {
                    return Unauthorized();
                }
                else
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Expires = DateTime.UtcNow.AddMinutes(
                            Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])
                        ),
                        Issuer = _configuration["Jwt:Issuer"],
                        Audience = _configuration["Jwt:Audience"],
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature
                        )
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(new { status = 200, token = jwtToken });
                }           
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }


    }
}
