using System;
using UserPosts.Data;
using UserPosts.Domain;
using UserPosts.Services;

namespace UserPosts.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPostRepository postRepository = new PostDataAccess();
            IUserRepository userRepository = new UserDataAccess();
            ICommentRepository commentRepository = new CommentDataAccess();

            var service = new UserService(userRepository, postRepository, commentRepository);

            var response = service.GetUserActiveRespose(1);

                foreach (var item in response)
                {
                    Console.Write(item);
                }
            var service1 = new UserService(userRepository, postRepository, commentRepository);

            var comments = service1.GetUserComents(2);
            foreach (var item in comments)
            {
                Console.Write(item.Comment);
            }
           
            
            
            Console.ReadLine();
        }
    }
}