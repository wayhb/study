using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Server
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
        static List<User> Users { get; } = new();
        public static User? FindUser(string name)
        {
            return Users.SingleOrDefault(u => u.Name.Equals(name));
        }
        public void Delete()
        {
            Users.Remove(this);
            File.Delete($"data\\users\\{Name}.json");
        }
        public void Save()
        {
            Directory.CreateDirectory("data\\users");

            using (var file = File.Create($"data\\users\\{Name}.json"))
            {
                JsonSerializer.Serialize(file, this);
            }
        }
        static User()
        {

            try
            {
                foreach (var filePath in Directory.EnumerateFiles("data\\users"))
                {
                    using (var file = File.OpenRead(filePath))
                    {
                        JsonSerializer.Deserialize<User>(file);
                    }
                }
                
            }
            catch (FileNotFoundException)
            { 

            }
            catch(DirectoryNotFoundException)
            {

            }
            catch
            {
                Console.WriteLine("Необработанная ошибка");
                throw;
            }
        }
        [JsonConstructor]
        public User(string name, string password)
        {
            Name = name;
            Password = password;
            Users.Add(this);
        }
    }
}
