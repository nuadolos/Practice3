using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Practice3_01.Entities
{
    class TimerUpdate
    {
        private DispatcherTimer timer;

        public DateTime TimeStartBlock { get; set; }

        public TimerUpdate()
        {
            timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(1000);
        }

        public void StartUpdate()
        {
            TimeStartBlock = DateTime.Now.AddSeconds(5);
            timer.Start();
        }

        public void StopUpdate()
        {
            timer.Stop();
        }

        public void TimerMethod(Action<object,EventArgs> method)
        {
            timer.Tick += new EventHandler(method);
        }
    }
}
