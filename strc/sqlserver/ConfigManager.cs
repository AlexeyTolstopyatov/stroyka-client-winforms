using strc.config;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strc.sqlserver
{
    public class ConfigManager
    {
        /// <summary>
        /// Проверяет состояние соединения. Возвращает <code>true (если соединение успешно)</code> 
        /// </summary>
        /// <returns>Состояние выполненной операции</returns>
        public static async Task<bool> HasConnection()
        {
            if (string.IsNullOrEmpty(Settings.Default.connection))
            {
                return false;
            }

            using (SqlConnection connection = new SqlConnection(Settings.Default.connection))
            {
                try 
                {
                    await connection.OpenAsync();
                }
                catch 
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверяет колличество записей в таблице учетных данных
        /// </summary>
        /// <returns>true (если учетные данные в таблице есть)</returns>
        public static async Task<bool> HasAccounts()
        {
            object result = 
                await QueryManager.ExecuteInt32Async("SELECT COUNT(Id) FROM [users]");

            if (( int )result == 0 || ( int )result == -1)
                return false;
            else
                return true;

        }
    }
}
