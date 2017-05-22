namespace Task.Core
{
    public class TaskType
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public TaskType(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }        
    }
}
