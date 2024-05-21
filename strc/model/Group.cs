using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strc.model
{
    public class Group
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        /// <summary>
        /// Фабричный метод для создания класса группы, где
        /// </summary>
        /// <param name="id">Номер группы</param>
        /// <param name="title">Название</param>
        /// <param name="content">Описание</param>
        /// <returns></returns>
        public static Group Create(int id, string title, string content) =>
            new Group() 
            {
                Id = id,
                Title = title,
                Content = content
            };
        

    }
}
