using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WtwApi.Application.Specifications;
using WtwApi.Exceptions;
using WtwApi.Interfaces;
using WtwApi.Models;
using WtwApi.Wrappers;

namespace WtwApi.Application.Queries.AuthenticateUserQuery
{
    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, Response<bool>>
    {
        private readonly IRepositoryAsync<UserModel> _repositoryAsync;
        private readonly IMapper _mapper;
        public AuthenticateUserQueryHandler(IRepositoryAsync<UserModel> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var spec = new UserByUsernameSpec(request.Username);
            var responseUser = await _repositoryAsync.GetBySpecAsync(spec);
            if (responseUser != null)
            {
                if (responseUser.Password == request.Password)
                {
                    return new Response<bool>(true);
                }
            }
            return new Response<bool>(false);
        }
    }
}
