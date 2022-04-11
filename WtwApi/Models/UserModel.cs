using WtwApi.Models.Base;

namespace WtwApi.Models
{
    public class UserModel: BaseEntity
    {
        public string Username { get; set; }
        public int PersonId { get; set; }
        public string Password { get; set; }

    }
}
