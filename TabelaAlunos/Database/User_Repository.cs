using System.Collections.Generic;
using System.Linq;
using TabelaAlunos.Model;

namespace TabelaAlunos.Database
{
    public class User_Repository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "diretor" });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "aluno" });
            users.Add(new User { Id = 3, Username = "alfred", Password = "alfred", Role = "professor" });

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
