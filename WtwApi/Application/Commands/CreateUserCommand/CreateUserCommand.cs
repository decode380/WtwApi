using FluentValidation;
using MediatR;
using WtwApi.Wrappers;

namespace WtwApi.Application.Commands.CreateUserCommand
{
    public class CreateUserCommand: IRequest<Response<int>>
    {
        public string Username { get; set; }
        public int PersonId { get; set; }
        public string Password { get; set; }

        public CreateUserCommand(
            string username,
            int personId,
            string password
        )
        {
            Username = username;
            PersonId = personId;
            Password = password;
        }
    }

    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                                         .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                                         .MaximumLength(50).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");
            RuleFor(x => x.PersonId).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                             .NotNull().WithMessage("{PropertyName} no puede ser nulo");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                             .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                             .MaximumLength(50).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");
        }
    }
}
