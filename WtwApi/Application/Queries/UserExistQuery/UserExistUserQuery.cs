using FluentValidation;
using MediatR;
using WtwApi.Models;
using WtwApi.Wrappers;

namespace WtwApi.Application.Queries.UserExistQuery
{
    public class UserExistQuery: IRequest<Response<bool>>{
        public string Username { get; set; }

        public UserExistQuery(string username)
        {
            Username = username;
        }
    }

    public class SpecificUserQueryValidator: AbstractValidator<UserExistQuery>
    {
        public SpecificUserQueryValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo");
        }
    }
}