using FluentValidation;
using MediatR;
using WtwApi.Wrappers;

namespace WtwApi.Application.Commands.CreatePersonCommand
{
    public class CreatePersonCommand: IRequest<Response<int>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string DocumentType { get; set; }

        public CreatePersonCommand(
            string firstName,
            string lastName,
            string documentNumber,
            string email,
            string documentType
        )
        {
            FirstName = firstName;
            LastName = lastName;
            DocumentNumber = documentNumber;
            Email = email;
            DocumentType = documentType;
        }
    }

    public class CreatePersonCommandValidator: AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                                     .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                                     .MaximumLength(100).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                                    .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                                    .MaximumLength(100).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");

            RuleFor(x => x.DocumentNumber).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                                          .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                                          .MaximumLength(50).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");

            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                                 .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                                 .EmailAddress().WithMessage("{PropertyName} no es un email válido")
                                 .MaximumLength(150).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");

            RuleFor(x => x.DocumentType).NotEmpty().WithMessage("{PropertyName} no puede estar vacío")
                                        .NotNull().WithMessage("{PropertyName} no puede ser nulo")
                                        .Matches(@"^cc$|^ce$|^pas$|^ti$/i").WithMessage("{PropertyName} no es válido (cc,ce,pas,ti)")
                                        .MaximumLength(5).WithMessage("{PropertyName} debe contener menos de {MaxLength} caracteres");
        }
    }
}
