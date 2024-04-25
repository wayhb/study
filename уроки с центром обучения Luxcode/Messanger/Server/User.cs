using System.Text.Json;

namespace Server {
  class User {
    string __name;
    public string Name {
      get
        => __name;
      set {
        if(TryFindUser(value) != null)
          throw new Exception("Такой пользователь уже есть!");
        __name = value;
      }
    }
    public string Password { get; set; }

    static List<User> __users = new();
    static IReadOnlyList<User> Users => __users;
    public static User? TryFindUser(string name)
      => __users.SingleOrDefault(u => u.Name.Equals(name));

    public User(string name, string password) {
      Name = name;
      Password = password;
      __users.Add(this);
    }

    static User() {
      try {
        foreach(var file_path in Directory.EnumerateFiles(__DIRECTORY_PATH))
          try {
            using(var file = File.OpenRead(file_path))
              JsonSerializer.Deserialize<User>(file);
          } catch {
          }
      } catch(DirectoryNotFoundException) {
      } catch(FileNotFoundException) {
      } catch {
        throw;
      }
    }

    const string __DIRECTORY_PATH = "data/users";
    string __FilePath => $"{__DIRECTORY_PATH}/{Name}.json";
    public void Save() {
      Directory.CreateDirectory(__DIRECTORY_PATH);
      using(var file = File.Create(__FilePath))
        JsonSerializer.Serialize(file, this);
    }
    public void Delete() {
      __users.Remove(this);
      File.Delete(__FilePath);
    }
  }
}
