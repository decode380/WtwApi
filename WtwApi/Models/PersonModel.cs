using System;
using WtwApi.Application.Commands.CreatePersonCommand;
using WtwApi.Interfaces;
using WtwApi.Models.Base;

namespace WtwApi
{
    public class PersonModel: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string DocumentType { get; set; }
    }
}
