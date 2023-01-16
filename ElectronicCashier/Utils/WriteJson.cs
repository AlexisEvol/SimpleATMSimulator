using ElectronicCashier.DTOs;
using Newtonsoft.Json;

namespace ElectronicCashier
{
    internal class WriteJson
    {
        public void WriteJsonFile<T>(List<T> usersList, string path)
        {
            string usersListString = JsonConvert.SerializeObject(usersList);
            File.WriteAllText(path, usersListString);
        }   
    }
}