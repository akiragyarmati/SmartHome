using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartHome
{
    public class SmartHomeDatabase
    {
        private string rootPath;

        public SmartHomeDatabase(string dbName)
        {
            this.rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dbName);

            DirectoryInfo directoryInfo = new DirectoryInfo(rootPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

        }

        public void SaveDevice(SmartDevice device)
        {
            string fileName = $"{device.Id}_{device.Name}.json";

            string filePath = Path.Combine(rootPath, fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };

            string json = JsonSerializer.Serialize(device, device.GetType(), options);

            FileInfo fileInfo = new FileInfo(filePath);

            File.WriteAllText(fileInfo.FullName, json);
            Console.WriteLine($"Mentve: {fileName}");

        }

    }

}
