using ElectronicCashier.DTOs;
using Newtonsoft.Json;

namespace ElectronicCashier
{
    internal class WriteJson
    {
        public void WriteJsonFile(List<User> usersList, string path)
        {
            string usersListString = JsonConvert.SerializeObject(usersList);
            File.WriteAllText(path, usersListString);
            Console.WriteLine("Your money has been succesfully updated.");
        }   
    }
}