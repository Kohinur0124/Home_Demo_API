using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ViewModel;

namespace Home_Demo_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly IStaffRepository staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateStaffViewModel createStaff)
        {
            await staffRepository.Create(createStaff);

            return Ok("Created");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await staffRepository.Get();
            return Ok(companies);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] CreateStaffViewModel newStaff)
        {
            await staffRepository.Update(id, newStaff);
            return Ok("Updated");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await staffRepository.Delete(id);
            return Ok("Deleted");

        }
    }
}
