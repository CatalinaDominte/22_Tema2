using System;
using System.Collections;
using System.Collections.Generic;
using UserPosts.Domain;

namespace UserPosts.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;

        public UserService(IUserRepository userRepository, IPostRepository postRepository, ICommentRepository commentRepository)
        {
            this.userRepository = userRepository;
            this.postRepository = postRepository;
            this.commentRepository = commentRepository;
        }

       public List<UserComments> GetUserComents(int id)
        {
            var comments = new List<UserComments>();
            var comment = new UserComments();


            var userComment = this.commentRepository.GetCommentByUserId(id);
           
            foreach (var item in userComment)
            {
                comment.Comment = item.Text;
                comments.Add(comment);
                
            }
            

            return comments;
        }

        public UserActiveRespose GetUserActiveRespose(int id)
        {
            var response = new UserActiveRespose();

            var user = this.userRepository.GetById(id);

            response.Email = user.Email;

            var posts = this.postRepository.GetPostsByUserId(id);

            var numberOfPosts = posts.Count;

            if(numberOfPosts < 5)
            {
                response.Status = UserPostsStatus.Inactive;
            }
            else
            {
                if (numberOfPosts > 5 && numberOfPosts < 10)
                {
                    response.Status = UserPostsStatus.Active;
                }
                else
                {
                    if (numberOfPosts >= 10)
                    {
                        response.Status = UserPostsStatus.Superactive;
                    }
                }
            }
           
            return response;
        }
    }

    public class UserActiveRespose:IEnumerable
    {
       public string Email { get; set; }

        public UserPostsStatus Status { get; set; }

        private IEnumerable Ev()
        {
            yield return Status;

        }
        public IEnumerator GetEnumerator()
        {
            return Ev().GetEnumerator();
        }
    }
    public class UserComments:IEnumerable
    {
       
        public string Comment { get; set; }
        private IEnumerable Ev()
        {
            yield return Comment;
            
        }
        public IEnumerator GetEnumerator()
        {
            return Ev().GetEnumerator();
        }
    }

    public enum UserPostsStatus
    {
        Inactive,
        Active, 
        Superactive
    }
}
