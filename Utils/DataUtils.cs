using permiakov_lab4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace permiakov_lab4.Utils
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
                UserStorage userStorage = GenerateSampleUsers();
                SaveUsers(userStorage);

                return userStorage;
            }
        }

        private static UserStorage GenerateSampleUsers()
        {
            List<Person> users = new();
            Random random = new();

            for (int i = 0; i < 50; i++)
            {
                string firstName = $"User{i + 1}";
                string lastName = $"LastName{i + 1}";
                string email = $"user{i + 1}@example.com";
                DateTime birthDate = DateTime.Now.AddYears(-random.Next(18, 100));

                users.Add(new Person(firstName, lastName, email, birthDate));
            }

            return new UserStorage(users);
        }
    }
}
