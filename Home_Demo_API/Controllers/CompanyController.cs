using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ViewModel;

namespace Home_Demo_API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCompanyViewModel createCompany)
        {
            await companyRepository.Create(createCompany);

            return Ok("Created");
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var companies = await companyRepository.Get();
            return Ok(companies);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromForm] CreateCompanyViewModel newCompany)
        {
            await companyRepository.Update(id, newCompany);
            return Ok("Updated");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await companyRepository.Delete(id);
            return Ok("Deleted");

        }
    }
}
