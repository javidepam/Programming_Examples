using HealthcareInsurance.Application.Commands;
using HealthcareInsurance.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareInsurance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController(IMediator mediator) : Controller
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetPatientByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
