
using System.Collections.Generic;
using Task.DAL;

namespace Task.Core
{
    public class CommentCollection : BusinessCollectionBase<Comment>
    {

        public List<Comment> DeleteComments { get; set; }

        public CommentCollection()
        {
            DeleteComments = new List<Comment>();
        }

        public void Remove(Comment comment)
        {
            DeleteComments.Add(comment);
            base.Remove(comment);
        }


        public static CommentCollection GetByTaskID(int TaskID)
        {
            var commentRepo = new CommentRepository();
            var comments = new CommentCollection();

            var commentsDTO = commentRepo.FetchAll(new CommentCriteria() {TaskID = TaskID});

            foreach (DTO.CommentDTO commentDto in commentsDTO)
            {
                var comment = Comment.CreateCommentFromDTO(commentDto);
                comment.MarkOld();
                comments.Add(comment);
            }

            return comments;
        }
    }
}
