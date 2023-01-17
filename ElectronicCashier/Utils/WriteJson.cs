using Newtonsoft.Json;

namespace SimpleATM.Utils
{
    internal class WriteJson
    {
        public void WriteJsonFile<T>(List<T> list, string path)
        {
            string usersListString = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, usersListString);
        }   
    }
}