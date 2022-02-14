using Practice3_01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practice3_01.Utilities
{
    static class Transition
    {
        public static Frame MainFrame { get; set; }

        private static ManufactureDBEntities context;
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
