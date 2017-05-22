using System.Collections.Generic;
using Task.DAL;

namespace Task.Service
{
    public class TaskTypeService
    {
        private DAL.TaskTypeRepository _repository;

        public TaskTypeService()
        {
            _repository = new TaskTypeRepository();    
        }

        public IEnumerable<Core.TaskType> GetAll()
        {
            return _repository.FetchAll(new TaskTypeCriteria());
        }

    }
}
