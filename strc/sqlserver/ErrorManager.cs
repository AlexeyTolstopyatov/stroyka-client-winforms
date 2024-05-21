using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using strc.model;

namespace strc.sqlserver
{

    /// <summary>
    /// Адаптер между окном и моделью данных ошибки, для обработки исключительных ситуаций
    /// </summary>
    public class ErrorManager
    {
        private static List<Error> _errors = new List<Error>();

        /// <summary>
        /// Создает отчет об ошибке
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Task ReportAsync(Exception e)
        {
            _errors.Add(
                new Error(e)
            );

            Journal.errBox.Text += _errors.Last().Message + "\r\n";

            return Task.CompletedTask;
        }

        /// <summary>
        /// Удаляет отчет под указанным номером
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Task RemoveAsync(int index)
        {
            _errors.RemoveAt(index);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Возвращает последнее сообщение
        /// </summary>
        /// <returns></returns>
        public static Task<string> LatestReportAsync()
        {
            return Task.FromResult(_errors.Last().Message);
        }

        /// <summary>
        /// Фиксированный экземпляр окна вывода сообщений об ошибках. (плохо)
        /// </summary>
        public static JournalForm Journal { get; set; } = new JournalForm(); 
    }
}
