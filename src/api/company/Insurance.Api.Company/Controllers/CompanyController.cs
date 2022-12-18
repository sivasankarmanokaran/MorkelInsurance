using Insurance.Service.Dto;
using Insurance.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace Insurance.Api.Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;

        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [ResponseType(typeof(CompanyDto))]
        public async Task<IActionResult> Get(int id)
        {

            var company = await _service.GetByIdAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}
