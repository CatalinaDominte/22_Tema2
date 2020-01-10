using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPosts.Domain;
using UserPosts.Services;

namespace UserPosts.Data
{
    public class CommentDataAccess: BaseDataAccess<Comment>, ICommentRepository
    {
        protected override string GetFile()
        {
            return @"..\..\..\UserPosts.Data\Files\comments.json";
        }

        public IList<Comment> GetCommentByUserId(int id)
        {
            var list = this.GetAll();
            return list.Where(x => x.UserId==id).ToList();
        }
    }
}
