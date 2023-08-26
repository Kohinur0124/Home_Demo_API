using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ViewModel;

namespace Home_Demo_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateEmoloyeeViewModel createEmployee)
        {
            await employeeRepository.Create(createEmployee);

            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await employeeRepository.Get();
            return Ok(companies);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] CreateEmoloyeeViewModel newEmployee)
        {
            await employeeRepository.Update (id, newEmployee);
            return Ok("Updated");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await employeeRepository.Delete(id);
            return Ok("Deleted");

        }

    }
}
