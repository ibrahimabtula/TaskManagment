
using Task.DTO;

namespace Task.Core
{
    public class CommentType : BusinessBase
    {

        public int ID { get; private set; }
        public string Name { get; private set; }

        internal static CommentType CopyFromDTO(CommentTypeDTO dto)
        {
            var commentType = new CommentType();

            commentType.ID = dto.ID;
            commentType.Name = dto.Name;

            return commentType;
        }
    }
}
