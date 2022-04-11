using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WtwApi.Interfaces;
using WtwApi.Wrappers;

namespace WtwApi.Application.Commands.CreatePersonCommand
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PersonModel> _repository;
        private readonly IMapper _mapper;
        public CreatePersonCommandHandler(IRepositoryAsync<PersonModel> repositoryAsync, IMapper mapper)
        {
            _repository = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            PersonModel newPerson = _mapper.Map<PersonModel>(request);
            var data = await _repository.AddAsync(newPerson);

            return new Response<int>(data.Id);
        }
    }
}
