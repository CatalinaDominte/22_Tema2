namespace UserPosts.Services.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using NSubstitute;
    using UserPosts.Domain;

    [TestFixture]
    public class UserServiceTests
    {
        private IUserRepository fakeUserRepository;
        private User fakeUser;
        private List<Post> dummyPosts;

        [SetUp]
        public void Setup()
        {
            fakeUserRepository = Substitute.For<IUserRepository>();

            fakeUser = new User()
            {
                Email = "fake@fake.com",
                Id = 1,
                Name = "name",
                Username = "username"
            };

            dummyPosts = new List<Post>();

            for (int i = 0; i < 20; i++)
            {
                dummyPosts.Add(new Post()
                {
                    UserId = 1,
                    Body = "asdsa"
                });
            }
        }

        [Test]
        public void Should_Have_Inactive_Status_When_Less_Than_Five_Posts()
        {
            //Arrange

            FakeUserRepository fakeUserRepository = new FakeUserRepository();
            FakePostRepository fakePostRepository = new FakePostRepository();
            UserService sut = new UserService(fakeUserRepository, fakePostRepository);
            //Act

            var response = sut.GetUserActiveRespose(1);

            //Assert
            Assert.AreEqual(UserPostsStatus.Inactive, response.Status);
        }

        [Test]
        public void Should_Have_Inactive_Status_When_Less_Than_Five_Posts2()
        {
            //Arrange

            fakeUserRepository.GetById(1).Returns(fakeUser);

            var fakePostRepository = Substitute.For<IPostRepository>();

            var fakePosts = dummyPosts.Take(4).ToList();

            fakePostRepository.GetPostsByUserId(1).Returns(fakePosts);

            UserService sut = new UserService(fakeUserRepository, fakePostRepository);
            //Act

            var response = sut.GetUserActiveRespose(1);

            //Assert
            Assert.AreEqual(UserPostsStatus.Inactive, response.Status);
        }

        [Test]
        public void Should_Have_Inactive_Status_When_Less_Than_Five_Posts3()
        {
            //Arrange
            fakeUserRepository.GetById(1).Returns(fakeUser);

            var fakePostRepository = Substitute.For<IPostRepository>();

            var fakePosts = dummyPosts.Take(7).ToList();

            fakePostRepository.GetPostsByUserId(1).Returns(fakePosts);

            UserService sut = new UserService(fakeUserRepository, fakePostRepository);
            //Act

            var response = sut.GetUserActiveRespose(1);

            //Assert
            Assert.AreEqual(UserPostsStatus.Active, response.Status);
        }
    }
}
