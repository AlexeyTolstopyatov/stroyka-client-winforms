using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strc.model
{
    /// <summary>
    /// Модель ошибки
    /// </summary>
    public class Error
    {
        
        private Exception _exception;

        public Error(Exception exception) 
        {
            _exception = exception;
        }

        public string Message 
        { 
            get 
            {
                return _exception.Message;
            }
        }

    }
}
