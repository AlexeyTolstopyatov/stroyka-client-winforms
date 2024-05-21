using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strc.model
{
    public class User
    {

        /// <summary>
        /// Фабричный метод. Создает экземпляр класса модели пользователя, где
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="phone">Телефон</param>
        /// <param name="gid">Номер группы</param>
        /// <returns></returns>
        public static User Create(string name, string surname, string phone, int gid)
        => new User() 
        {
            Name = name,
            Phone = phone,
            Gid = gid,
            Surname = surname,
        };

        public string Name { get; private set; }
        public string Phone { get; private set; }
        public int Gid { get; private set; }
        public string Surname { get; private set; }
    }
}
