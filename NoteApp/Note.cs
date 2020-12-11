using System;
using System.Runtime.CompilerServices;

namespace NoteApp
{
    /// <summary>
    /// Класс заметка, здесь хранится информация о название заметки,ее категории
    /// содержании,даты создания и дате изменения
    /// </summary>
    public class Note : ICloneable
    {
        /// <summary>
        /// Название заметки
        /// </summary>
        private string _title;

        /// <summary>
        /// Свойство имени заметки.
        /// Проверка на длину длину символом: менее 50 символов.
        /// </summary>
        public string Title
        {
            get => _title; 
            set
            {
                if (value.Length >= 50)
                {
                    throw new ArgumentException("Имя заметки должно быть не более 50 символов!");
                }
                else
                {
                    if (value !="")
                    {
                        _title = value;
                    }
                    else _title = "Безымянный";
                }
            }
        }
        /// <summary>
        /// Свойство категории заметки
        /// </summary>
        public NotesCategory NoteCategory { get; set; }

        /// <summary>
        /// Свойство имени заметки. Изменяет время после изменения имени.
        /// </summary>
        public string NoteDescription { get; set; }

        /// <summary>
        /// Свойство для времени создания
        /// </summary>
        public DateTime TimeCreated { get; set; } = DateTime.Now;

        /// <summary>
        /// Свойство для изменения времени
        /// </summary>
        public DateTime TimeRecentUpdate { get; set; } = DateTime.Now;

        /// <summary>
        /// Метод клонирования
        /// </summary>
        public object Clone()
        {
            return new Note
            {
                Title = Title,
                NoteDescription = NoteDescription,
                TimeRecentUpdate = TimeRecentUpdate,
                TimeCreated = TimeCreated,
                NoteCategory = NoteCategory
            };
        }

     

    }
}
