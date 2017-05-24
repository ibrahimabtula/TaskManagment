using Task.DAL;

namespace Task.Core
{
    public class CommentTypeCollection : BusinessCollectionBase<CommentType>
    {

        public static CommentTypeCollection GetAll()
        {
            var repository = new CommentTypeRepository();
            var collection = new CommentTypeCollection();

            var colletionDTO = repository.FetchAll(new CommentTypeCriteria());

            foreach (DTO.CommentTypeDTO dto in colletionDTO)
            {
                var taskStatus = CommentType.CopyFromDTO(dto);
                taskStatus.MarkOld();
                collection.Add(taskStatus);
            }

            return collection;
        }
    }
}
