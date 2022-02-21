using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Practice3_01.Entities
{
    /// <summary>
    /// Класс TimerUpdate предназначен
    /// для создании таймера и его управления
    /// </summary>
    class TimerUpdate
    {
        private DispatcherTimer timer;

        /// <summary>
        /// Свойство TimeStartBlock, определяющее конечное значение таймера
        /// </summary>
        public DateTime TimeStartBlock { get; set; }
        /// <summary>
        /// Свойство TimerForSeconds, служащее для установки 
        /// таймера на определенный промежуток времени
        /// </summary>
        public int TimerForSeconds { get; set; }

        /// <summary>
        /// Конструктор TimerUpdate, создающий экземляр класса DispatcherTimer
        /// </summary>
        public TimerUpdate()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(1000);

            TimerForSeconds = 5;
        }

        /// <summary>
        /// Включение таймера на определенный промежуток времени
        /// </summary>
        public void StartUpdate()
        {
            TimeStartBlock = DateTime.Now.AddSeconds(TimerForSeconds);
            timer.Start();
        }

        /// <summary>
        /// Остановка текущего таймера
        /// </summary>
        public void StopUpdate()
        {
            timer.Stop();
        }

        /// <summary>
        /// Установка выполняемого метода на ежесекундное выполнение
        /// </summary>
        /// <param name="method"></param>
        public void TimerMethod(Action<object,EventArgs> method)
        {
            timer.Tick += new EventHandler(method);
        }
    }
}
