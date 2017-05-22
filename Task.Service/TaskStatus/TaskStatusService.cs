using System.Collections.Generic;
using Task.DAL;

namespace Task.Service
{
    public class TaskStatusService
    {
        private DAL.TaskStatusRepository _repository;

        public TaskStatusService()
        {
            _repository = new TaskStatusRepository();    
        }

        public IEnumerable<Core.TaskStatus> GetAll()
        {
            return _repository.FetchAll(new TaskStatusCriteria());
        }

    }
}
