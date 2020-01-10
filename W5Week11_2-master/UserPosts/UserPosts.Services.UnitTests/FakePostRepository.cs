using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Domain;

namespace UserPosts.Services.UnitTests
{
    class FakePostRepository : IPostRepository
    {
        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetPostsByUserId(int id)
        {
            return new List<Post>()
            {
                new Post()
                {
                    UserId = 1,
                    Body = "asdsa"
                },
                new Post()
                {
                    UserId = 1,
                    Body = "body 2"
                },
                new Post()
                {
                    UserId = 1,
                    Body = "body 2"
                }
            };
        }
    }
}
