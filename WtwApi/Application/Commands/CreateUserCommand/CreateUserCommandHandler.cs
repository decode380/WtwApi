using Ardalis.Specification;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WtwApi.Application.Specifications;
using WtwApi.Exceptions;
using WtwApi.Interfaces;
using WtwApi.Models;
using WtwApi.Wrappers;

namespace WtwApi.Application.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IRepositoryAsync<UserModel> _repositoryUser;
        private readonly IRepositoryAsync<PersonModel> _repositoryPerson;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IRepositoryAsync<UserModel> repositoryUser, IRepositoryAsync<PersonModel> repositoryPerson, IMapper mapper)
        {
            _repositoryUser = repositoryUser;
            _repositoryPerson = repositoryPerson;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            UserModel newUser;
            var personExist = await _repositoryPerson.GetByIdAsync(request.PersonId);
            if (personExist == null)
            {
                throw new KeyNotFoundException($"No se encuentra el id {request.PersonId} en la tabla personas");
            } else
            {
                newUser = _mapper.Map<UserModel>(request);
                var userSpec = new UserByUsernameSpec(request.Username);
                var usernameExist = await _repositoryUser.GetBySpecAsync(userSpec);

                if (usernameExist != null)
                {
                    throw new ApiException($"El usuario {request.Username} ya se encuentra registrado");
                }
                await _repositoryUser.AddAsync(newUser);
            }
            return new Response<int>(newUser.Id);
        }
    }
}
