using FluentValidation;
using MediatR;
using WtwApi.Wrappers;

namespace WtwApi.Application.Queries.AuthenticateUserQuery
{
    public class AuthenticateUserQuery: IRequest<Response<bool>>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticateUserQuery(
            string username,
            string password
        )
        {
            Username = username;
            Password = password;
        }
    }

    public class AuthenticateUserQueryValidator: AbstractValidator<AuthenticateUserQuery>
    {
        public AuthenticateUserQueryValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                             .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                             .MaximumLength(50).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                             .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                             .MaximumLength(50).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");
        }
    }
}
