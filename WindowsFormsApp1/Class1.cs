using System;
using System.ComponentModel;
using System.Threading;

namespace WindowsFormsApp1
{
    public delegate void CustomEventHandler(object sender, CustomEventArgs e);

    public class CustomEventArgs : EventArgs
    {
        public string Message { get; set; }
        public CustomEventArgs(string message)
        {
            Message = message;
        }
    }

    public class Class1
    {
        int sec;
        BackgroundWorker bw;
        public event CustomEventHandler RaiseCustomEvent;

        public void Start(int seconds)
        {
            sec = seconds;
            bw = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnRaiseCustomEvent(new CustomEventArgs("Timer Done"));
        }

        private void OnRaiseCustomEvent(CustomEventArgs eventArgs)
        {
            CustomEventHandler raiseEvent = RaiseCustomEvent;
            if (raiseEvent != null)
            {
                raiseEvent(this, eventArgs);
            }
        }
        public void Stop()
        {
            if (bw.IsBusy)
            {
                bw.CancelAsync();
            }
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime nw = DateTime.Now;
            while(nw.AddSeconds(sec) < DateTime.Now)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Thread.Sleep(1000);
            }
        }
    }


}
