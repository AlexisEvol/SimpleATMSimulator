namespace SimpleATM.Utils
{
    internal class ReadJson
    {
        public string ReadJsonFile(string path)
        {
            var jsonFileContent = File.ReadAllText(path);
            
            return jsonFileContent;
        }
    }
}
