
namespace Task.Core
{
    public class User : BusinessBase
    {
        public int ID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
