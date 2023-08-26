using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ViewModel;

namespace Home_Demo_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StaffEmployeeController : Controller
    {
        private readonly IStaffEmployeeRepository staffEmployeeRepository;

        public StaffEmployeeController(IStaffEmployeeRepository staffEmployeeRepository)
        {
            this.staffEmployeeRepository = staffEmployeeRepository;    
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateStaffEmployeeViewModel createStaffEmployee)
        {
            await staffEmployeeRepository.Create(createStaffEmployee);

            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await staffEmployeeRepository.Get();
            return Ok(companies);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompanyAsync(Guid id, [FromForm]CreateStaffEmployeeViewModel newStaffEmployee)
        {
            await staffEmployeeRepository.Update(id, newStaffEmployee);
            return Ok("Updated");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await staffEmployeeRepository.Delete(id);
            return Ok("Deleted");

        }

    }
}
