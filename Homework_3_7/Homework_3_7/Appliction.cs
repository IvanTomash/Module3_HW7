using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Homework_2_5;

namespace Homework_3_7
{
    /// <summary>
    /// Application class.
    /// </summary>
    internal sealed class Appliction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Appliction"/> class.
        /// </summary>
        public Appliction()
        {
            Logger.Instance.Notifying += this.Notify;
        }

        /// <summary>
        /// Starts a program performing.
        /// </summary>
        public void Run()
        {
            Task t1 = this.MethodAsync();
            Task t2 = this.MethodAsync();
        }

        private async Task MethodAsync()
        {
            for (int i = 0; i < 50; i++)
            {
                await Logger.Instance.LogInfoAsync(i.ToString(), this.CreatePath());
            }
        }

        private void Notify(object sender, EventArgs e)
        {
            Console.WriteLine("You need you to back up the log file.");
        }

        private string CreatePath()
        {
            string dir = "Backup";
            string name = $"{DateTime.Now.ToString("yyyy-M-dd-hh-mm-ss-ffffff")}.txt";
            string res = Path.Combine(dir, name);
            if (!File.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return res;
        }
    }
}
