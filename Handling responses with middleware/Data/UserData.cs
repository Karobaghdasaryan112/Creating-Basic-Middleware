using ustomLogger.Models;

namespace ustomLogger.Data
{
    public class UserData
    {
        private List<User> Users { get; set; }
        public UserData()
        {
            Users = new List<User>()
            {
                new User { Id = 1, Name = "John Doe", Email = "john@example.com", Password = "password123" },
                new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Password = "password456" },
                new User { Id = 3, Name = "Alice Johnson", Email = "alice@example.com", Password = "password789" },
                new User { Id = 4, Name = "Bob Brown", Email = "bob@example.com", Password = "password001" },
                new User { Id = 5, Name = "Charlie White", Email = "charlie@example.com", Password = "password002" },
                new User { Id = 6, Name = "David Black", Email = "david@example.com", Password = "password003" },
                new User { Id = 7, Name = "Emma Green", Email = "emma@example.com", Password = "password004" },
                new User { Id = 8, Name = "Frank Blue", Email = "frank@example.com", Password = "password005" },
                new User { Id = 9, Name = "Grace Red", Email = "grace@example.com", Password = "password006" },
                new User { Id = 10, Name = "Henry Gold", Email = "henry@example.com", Password = "password007" }
            };
        }
        public List<User> GetUsers()
        {
            return Users;
        }
    }
}
