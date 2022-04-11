using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WtwApi.Application.Commands.AllUsersQuery;
using WtwApi.Application.Commands.CreatePersonCommand;

namespace WtwApi.Controllers
{
    [ApiController]
    [Route("api/person")]

    public class PersonController : ControllerBase
    {
        private IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/new-person")]
        [HttpPost()]
        public async Task<IActionResult> CreatePerson(CreatePersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("/all-persons")]
        [HttpGet()]
        public async Task<IActionResult> AllPersons()
        {
            var result = await _mediator.Send(new AllUsersQuery());
            return Ok(result);
        }
    }
}
