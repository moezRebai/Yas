using EnsureThat;

namespace Yas.UserService.Domain
{
    public class User
    {
        public User(string name, int age, string address, DateTime creationDate)
        {
            Ensure.That(name).IsNotNullOrWhiteSpace();
            Ensure.That(address).IsNotNullOrWhiteSpace();
            Ensure.That(age).IsInRange(2, 100);
            Ensure.That(creationDate).IsNotDefault();

            Name = name;
            Age = age;
            Address = address;
            CreationDate = creationDate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public DateTime CreationDate { get; set; }
    }
}