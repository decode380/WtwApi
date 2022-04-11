using System.Collections.Generic;
using MediatR;
using WtwApi;
using WtwApi.Wrappers;


namespace WtwApi.Application.Commands.AllUsersQuery
{
    public class AllUsersQuery: IRequest<Response<List<PersonModel>>>{
    }
}