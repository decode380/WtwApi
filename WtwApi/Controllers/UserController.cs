using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WtwApi.Application.Commands.CreateUserCommand;
using WtwApi.Application.Queries.AuthenticateUserQuery;
using WtwApi.Application.Queries.UserExistQuery;

namespace WtwApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/new-user")]
        [HttpPost()]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Route("/authenticate-user")]
        [HttpGet()]
        public async Task<IActionResult> AuthenticateUser([FromQuery(Name="username")] string username, [FromQuery(Name = "password")] string password)
        {
            var result = await _mediator.Send(new AuthenticateUserQuery(username,password));
            return Ok(result);
        }

        [Route("/exist-user")]
        [HttpGet()]
        public async Task<IActionResult> GetUser([FromQuery(Name="username")] string username)
        {
            var result = await _mediator.Send(new UserExistQuery(username));
            return Ok(result);
        }
    }
}
