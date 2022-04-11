using Ardalis.Specification;
using WtwApi.Models;

namespace WtwApi.Application.Specifications
{
    public class UserByUsernameSpec : Specification<UserModel>, ISingleResultSpecification
    {
        public UserByUsernameSpec(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                Query.Where(h => h.Username == username);
            }
        }
    }

    public class UserByPasswordSpec : Specification<UserModel>, ISingleResultSpecification
    {
        public UserByPasswordSpec(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                Query.Where(h => h.Username == username);
            }
        }
    }
}
