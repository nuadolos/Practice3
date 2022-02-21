using Practice3_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practice3_01.Utilities
{
    /// <summary>
    /// Класс Transition управляет элементом управления Frame для навигации страниц,
    /// а также осуществляет взаимодействие с подключенной базой данных
    /// </summary>
    static class Transition
    {
        /// <summary>
        /// Свойство MainFrame предзначено для навигации страниц
        /// </summary>
        public static Frame MainFrame { get; set; }


        private static ManufactureDBEntities context;
        /// <summary>
        /// Свойство Context, через которое происходит взаимодействие с базой данных
        /// </summary>
        public static ManufactureDBEntities Context
        {
            get
            {
                if (context == null)
                    context = new ManufactureDBEntities();

                return context;
            }
        }
    }
}
