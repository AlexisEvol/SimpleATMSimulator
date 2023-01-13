using ElectronicCashier.DTOs;
using ElectronicCashier.Utils;
using Newtonsoft.Json;

namespace ElectronicCashier
{
    internal class WriteJson
    {
        public void WriteJsonFile(List<User> usersList)
        {
            string usersListString = JsonConvert.SerializeObject(usersList);
            File.WriteAllTextAsync(Constants.path, usersListString);
        }   
    }
}