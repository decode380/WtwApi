using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WtwApi;
using WtwApi.Interfaces;
using WtwApi.Wrappers;

namespace WtwApi.Application.Commands.AllUsersQuery
{
    public class AllUsersQueryHandler : IRequestHandler<AllUsersQuery, Response<List<PersonModel>>>{

        private readonly IRepositoryAsync<PersonModel> _repository;
        public AllUsersQueryHandler(IRepositoryAsync<PersonModel> repositoryAsync)
        {
            this._repository = repositoryAsync;
        }
        public async Task<Response<List<PersonModel>>> Handle(AllUsersQuery request, CancellationToken cancellationToken)
        {
            var persons = await _repository.ListAsync();
            return new Response<List<PersonModel>>(persons);
        }
    }
}