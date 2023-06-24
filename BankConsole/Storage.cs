using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankConsole;

public static class Storage 
{
    static string filepath = AppDomain.CurrentDomain.BaseDirectory + @"\users.json";
    public static void AddUser (User user)
    {
        string json = "", usersInFile = "";

        if (File.Exists(filepath)) //pregunta si ya existe (archivo que se definre arriba en la linea 7)
        { 
            usersInFile = File.ReadAllText(filepath); //si ya existe, la variable userInFile la hace igual a lo que contenga el archivo
        }

        var listUsers = JsonConvert.DeserializeObject<List<object>>(usersInFile); //se crean una lista y se deseriliza (convertir de json a un objeto en particular)
                                                                                //...convierte el contenido del archivo
        if (listUsers == null)
        {
            listUsers = new List<object>();
        }

        listUsers.Add(user);

        JsonSerializerSettings settings = new JsonSerializerSettings {Formatting = Formatting.Indented};
            
        json = JsonConvert.SerializeObject(listUsers, settings); 

        File.WriteAllText(filepath, json);
    }
    public static List<User> GetNewUsers()
    {
        string usersInFile = "";
        var listUsers = new List<User>();

        if (File.Exists(filepath)) 
        { 
            usersInFile = File.ReadAllText(filepath); 
        }

        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile); 

        if (listObjects == null)
        {
            return listUsers;
        }

        foreach (object obj in listObjects)
        {
            User newUser; 
            JObject user = (JObject)obj;

            if (user.ContainsKey("TaxRegime"))
            {
                newUser = user.ToObject<Client>();   
            } else {
                newUser = user.ToObject<Employee>();
            }

            listUsers.Add(newUser);
        }

        var newUserList = listUsers.Where(user => user.GetRegisterDate().Date.Equals(DateTime.Today)).ToList();

        return newUserList;
    }

    public static string DeleteUser(int ID)
    {
       
        string usersInFile="";
        var listUsers = new List<User>();

        if(File.Exists(filepath))
            usersInFile=File.ReadAllText(filepath);

        var listObjects = JsonConvert.DeserializeObject<List<object>>(usersInFile);

        if(listObjects == null)
            return "there are no user in the file";
        
        foreach (object obj in listObjects)
        {
            User newUser;
            JObject user = (JObject)obj;

            if(user.ContainsKey("TaxRegime"))
                newUser = user.ToObject<Client>();
            
            else
                newUser = user.ToObject<Employee>();

            listUsers.Add(newUser);
        }
        var userToDelete = listUsers.Where(user => user.GetID() == ID).Single();

    if(userToDelete !=null)
    {
         listUsers.Remove(userToDelete);

        JsonSerializerSettings settings = new JsonSerializerSettings {Formatting = Formatting.Indented};

        string json = JsonConvert.SerializeObject(listUsers, settings);

        File.WriteAllText(filepath, json);

        return "Success";
    }
    return "No se encontro un usuario con ese ID";
       
    }
}