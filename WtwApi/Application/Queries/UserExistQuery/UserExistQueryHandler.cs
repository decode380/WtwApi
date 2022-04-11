using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using WtwApi.Application.Specifications;
using WtwApi.Interfaces;
using WtwApi.Models;
using WtwApi.Wrappers;

namespace WtwApi.Application.Queries.UserExistQuery
{
    public class UserExistQueryHandler : IRequestHandler<UserExistQuery, Response<bool>>
    {
        private readonly IRepositoryAsync<UserModel> _repositoryAsync;
        private readonly IMapper _mapper;
        public UserExistQueryHandler(IRepositoryAsync<UserModel> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UserExistQuery request, CancellationToken cancellationToken)
        {
            var spec = new UserByUsernameSpec(request.Username);
            var user = await _repositoryAsync.GetBySpecAsync(spec);
            if(user != null){
                return new Response<bool>(true);
            } else {
                return new Response<bool>(false);
            }
        }
    }
}