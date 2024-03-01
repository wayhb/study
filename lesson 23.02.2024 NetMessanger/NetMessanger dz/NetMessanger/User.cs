using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetMessanger
{
    internal class User
    {
        string name;
        public string Name 
        { 
            get 
            {
                return name;
            } 
            set 
            {
                if(FindUser(value) != null)
                {
                    throw new Exception("Такой пользователь уже есть!");
                }
                name = value;
            } 
        }
        public string Password { get; set; }
        static List<User> Users { get; }
        public static User? FindUser(string name)
        {
            return Users.SingleOrDefault(u => u.Name.Equals(name));
        }
        public User(string name)
        {
            Name = name;
            Users.Add(this);
        }
        public static void Save()
        {
            Directory.CreateDirectory("data");
            using (var file = File.Create("data\\users.json"))
            {
                // utf8 при сериализации!!
                JsonSerializer.Serialize<List<User>>(file, Users);
            }
        }
        static User()
        {
            try
            {
                using (var file = File.OpenRead("data\\users.json"))
                {
                    Users = JsonSerializer.Deserialize<List<User>>(file);
                }
            }
            catch (FileNotFoundException)
            { 
                Users=new List<User>();
            }
            catch(DirectoryNotFoundException)
            {
                Users = new List<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Необработанная ошибка");
                throw ex;
            }
        }
        [JsonConstructor]
        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
