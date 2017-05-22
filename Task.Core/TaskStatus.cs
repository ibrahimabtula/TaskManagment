
namespace Task.Core
{
    public class TaskStatus
    {

        public int ID { get; private set; }
        public string Name { get; private set; }

        public TaskStatus(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
