using permiakov_lab4.Models;
using System;
using System.IO;
using System.Text.Json;

namespace permiakov_lab4.DataUtils
{
    class DataUtils
    {
        private static readonly string RootDirectory = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.ApplicationData), "PermiakovLab4");
        private static readonly string dataFilePath = Path.Combine(RootDirectory, "users.json");

        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        public static void SaveUsers(UserStorage userStorage)
        {
            _ = Directory.CreateDirectory(RootDirectory);

            string jsonData = JsonSerializer.Serialize(userStorage, options);
            File.WriteAllText(dataFilePath, jsonData);
        }

        public static UserStorage LoadUsers()
        {
            if (File.Exists(dataFilePath))
            {
                string jsonData = File.ReadAllText(dataFilePath);
                return JsonSerializer.Deserialize<UserStorage>(jsonData, options);
            }
            else
            {
                return new UserStorage();
            }
        }
    }
}
