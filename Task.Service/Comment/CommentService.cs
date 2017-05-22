using System.Collections.Generic;
using Task.DAL;

namespace Task.Service
{
    public class CommentService
    {
        private DAL.CommentRepository _repository;

        public CommentService()
        {
            _repository = new CommentRepository();
        }

        public IEnumerable<Core.Comment> GetAll()
        {
            return _repository.FetchAll(new CommentCriteria());
        }

        public IEnumerable<Core.Comment> GetAllByTaskID(int TaskID)
        {
            return _repository.FetchAll(new CommentCriteria()
            {
                TaskID = TaskID
            });
        }

        public void Update(Core.Comment Comment)
        {
            _repository.Update(Comment);
        }
    }
}
