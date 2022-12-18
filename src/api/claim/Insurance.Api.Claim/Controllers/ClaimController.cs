using Insurance.Service.Dto;
using Insurance.Service.Interface;
using Insurance.Service.Model;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace Insurance.Api.Claim.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimService _service;

        public ClaimController(IClaimService service)
        {
            _service = service;
        }

        [HttpGet("~/api/company/{companyId:int}/claims")]
        [ResponseType(typeof(IEnumerable<ClaimDto>))]
        public async Task<IActionResult> GetClaims(int companyId)
        {
            var claims = await _service.GetClaimsAsync(companyId);

            if (claims == null || !claims.Any())
            {
                return NotFound();
            }

            return Ok(claims);
        }


        [HttpGet("{id}")]
        [ResponseType(typeof(ClaimDto))]
        public async Task<IActionResult> GetClaim(int id)
        {
            var claim = await _service.GetAsync(id);

            if (claim == null)
            {
                return NotFound();
            }

            return Ok(claim);
        }

        [HttpPut("{id}")]
        [ResponseType(typeof(ClaimDto))]
        public async Task<IActionResult> put(int id, ClaimModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                var claim = await _service.GetAsync(id);

                if (claim == null)
                {
                    return NotFound();
                }

                await _service.UpdateAsync(model);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok();

        }
    }
}
