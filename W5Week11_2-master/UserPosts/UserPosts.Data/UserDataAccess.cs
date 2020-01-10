using UserPosts.Domain;
using UserPosts.Services;

namespace UserPosts.Data
{
    public class UserDataAccess : BaseDataAccess<User>, IUserRepository
    {
        protected override string GetFile()
        {
            return @"..\..\..\UserPosts.Data\Files\users.json";
        }
    }
}
