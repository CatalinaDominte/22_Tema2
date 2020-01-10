using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Domain;

namespace UserPosts.Services.UnitTests
{
    public class FakeUserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            return new User()
            {
                Email = "fake@fake.com",
                Id = 1,
                Name = "name",
                Username = "username"
            };
        }

        IList<User> IBaseRepository<User>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
