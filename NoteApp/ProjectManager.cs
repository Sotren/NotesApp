using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс менеджера проекта
    /// </summary>
    public class ProjectManager
    {
        /// <summary>
        ///Сохранение по умолчанию
        /// </summary>
        public static string PathFile()
        {
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return filepath + @"\NoteApp\NoteApp.json";
        }

        /// <summary>
        /// Создание по умолачанию
        /// </summary>
        public static string PathDirectory()
        {
            var filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return filepath + @"\NoteApp";
        }

        /// <summary>
        /// Сериализация данных сохранение
        /// </summary>
        /// <param name="data">Данные для сериализации</param>
        /// <param name="filepath">Путь к файлу</param>
        public static void SaveToFile(Project data, string filepath, string directoryPath)
        {
            if (!File.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }

        /// <summary>
        /// Сериализация данных загрузка
        /// </summary>
        /// <param name="filepath">Путь к файлу</param>
        /// <returns></returns>
        public static Project LoadFromFile(string filepath)
        {
            Project project;
            if (!File.Exists(filepath))
            {
                return new Project();
            }
            var serializer = new JsonSerializer();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                using (JsonReader reader = new JsonTextReader(sr))
                    project = serializer.Deserialize<Project>(reader);
            }
            catch 
            {
                return new Project();
            }
            return project;
        }
    }
}

