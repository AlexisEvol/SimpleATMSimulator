using ElectronicCashier.Utils;
using System.IO;

namespace ElectronicCashier
{
    internal class ReadJson
    {
        public string ReadJsonFile()
        {
            string jsonFileContent = File.ReadAllText(Constants.path);
            return jsonFileContent;
        }
    }
}
