using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

using strc.config;
using strc.model;
using System.Data;

namespace strc.sqlserver
{

    /// <summary>
    /// Адаптер SqlClient для быстрого использования объектов базы данных без точной настройки.
    /// </summary>
    public class QueryManager
    {
        /// <summary>
        /// Выполняет запрос. Если результат -1, смотрите ErrorManager.LastReportAsync().
        /// </summary>
        /// <param name="query">текст запроса</param>
        /// <returns>Результат (первая строка и первый столбец от всей таблицы)</returns>
        public static async Task<object> ExecuteInt32Async(string query)
        {
            using (SqlConnection connecton = new SqlConnection(Settings.Default.connection))
            using (SqlCommand command = new SqlCommand(query, connecton))
            {
                await connecton.OpenAsync();

                try
                {
                    object result =
                        await command.ExecuteScalarAsync();

                    return result;
                }
                catch (Exception e)
                {
                    await ErrorManager.ReportAsync(e);
                    return -1;
                }
            }
        }

        /// <summary>
        /// Возвращает одномерный массив строк (с одним столбцом). [имя, {0оег, леха, ром, текила}]
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns></returns>
        public static async Task<string[]> ExecuteVectorAsync(string query)
        {
            List<string> vec = new List<string>();

            using (SqlConnection connection = new SqlConnection(Settings.Default.connection))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                        while (await reader.ReadAsync())
                            vec.Add(reader.GetString(0));
                }
                catch (Exception e)
                {
                    await ErrorManager.ReportAsync(e);
                }
            }

            return vec.ToArray();
        }

        /// <summary>
        /// Возвращает таблицу в виде DataTable
        /// </summary>
        /// <param name="query">запрос</param>
        /// <returns></returns>
        public static async Task<DataTable> ExecuteMapAsync(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection c = new SqlConnection(Settings.Default.connection))
            using (SqlCommand command = new SqlCommand(query, c))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                try
                {
                    await c.OpenAsync();
                    adapter.Fill(table);
                }
                catch (Exception e)
                {
                    await ErrorManager.ReportAsync(e);
                }
            }

            return table;
        }

        /// <summary>
        /// Выполняет вставку пользователя
        /// </summary>
        /// <param name="user">модель пользователя</param>
        /// <returns></returns>
        public static async Task<bool> InsertUserAsync(User user)
        {
            object result = await ExecuteInt32Async("SELECT COUNT(*) FROM [users]");

            int count = ( int )result + 1;

            using (SqlConnection c = new SqlConnection(Settings.Default.connection))
            using (SqlCommand command = new SqlCommand("", c))
            {
                await c.OpenAsync();

                try 
                {
                    command.CommandText =
                    $"INSERT [users] (id, name, sname, phone, gid)" +
                    $"VALUES ({count}, '{user.Name}', '{user.Surname}', '{user.Phone}', {user.Gid})";

                    await command.ExecuteNonQueryAsync();

                    return true;
                }
                catch (Exception e) 
                {
                    await ErrorManager.ReportAsync(e);
                    return false;
                }

            }
        }


        /// <summary>
        /// Выполняет вставку группы пользователей
        /// </summary>
        /// <param name="group">модель группы</param>
        /// <returns></returns>
        public static async Task<bool> InsertGroupAsync(Group group)
        {
            string query = 
                 "INSERT [groups] (id, title, content)" + 
                $"VALUES ({group.Id}, '{group.Title}', '{group.Content}')";

            using (SqlConnection c = new SqlConnection(Settings.Default.connection))
            using (SqlCommand command = new SqlCommand(query, c))
            {
                await c.OpenAsync();

                try 
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch(Exception e) 
                {
                    await ErrorManager.ReportAsync(e);
                    return false;
                }

                return true;
            }
        }
    }
}
