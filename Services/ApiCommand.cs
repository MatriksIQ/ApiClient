using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Matriks.API.Shared;

namespace Matriks.ApiClient.Services
{
    public abstract class ApiCommand
    {
        protected int RequestedCommand { get; set; }

        public void Run(Packet pack)
        {
            try
            {
                var watch = Stopwatch.StartNew();

                Initialize(pack);

                Deserialize(pack);

                Execute();

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Initialize(Packet pack)
        {
            RequestedCommand = pack.ApiCommands;
        }

        protected abstract void Deserialize(Packet pack);

        protected abstract void Execute();
        protected abstract void UnExecute();

    }
}
