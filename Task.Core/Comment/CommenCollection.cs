
using Task.DAL;

namespace Task.Core
{
    public class CommentCollection : BusinessCollectionBase<Comment>
    {

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
