using AutoMapper;
using WtwApi.Application.Commands.CreatePersonCommand;
using WtwApi.Application.Commands.CreateUserCommand;
using WtwApi.Models;

namespace WtwApi.Mappings
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile()
        {
            #region Commands
            CreateMap<CreatePersonCommand, PersonModel>();
            CreateMap<CreateUserCommand, UserModel>();
            #endregion
        }
    }
}
