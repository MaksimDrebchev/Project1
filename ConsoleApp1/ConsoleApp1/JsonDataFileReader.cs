using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class JsonDataFileReader
    {
        public static string DirectoryName { get; set; } = "JsonData";

        public static JObject GetJObject(string fileName) => JObject.Parse(GetFileTextContent(fileName));

        public static JArray GetJArray(string fileName) => JArray.Parse(GetFileTextContent(fileName));

        private static string GetFileTextContent(string fileName)
        {
            string directoryPath = GetDirectoryPath(DirectoryName);
            string filePath = $"{directoryPath}\\{fileName}";
            string textContent = File.ReadAllText(filePath);
            return textContent;
        }
        private static string GetDirectoryPath(string directoryName)
        {
            string relativePath = $"\\{directoryName}";
            string baseDirPath = AppDomain.CurrentDomain.BaseDirectory;
            baseDirPath = baseDirPath.Replace("\\bin\\Debug\\net5.0\\", "");
            string absolutePath = baseDirPath + relativePath;
            return absolutePath;
        }
    }
}
