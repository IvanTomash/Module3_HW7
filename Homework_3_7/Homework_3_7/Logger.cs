using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Homework_3_7;

namespace Homework_2_5
{
    /// <summary>
    /// Used for logging inforamtion.
    /// </summary>
    internal class Logger
    {
        private static readonly Logger Example = new Logger();

        /// <summary>
        /// Store all logs in RAM.
        /// </summary>
        private string allLogs;
        private int logsCounter = 1;
        private Configuration configInfo;

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Logger()
        {
        }

        private Logger()
        {
            using (StreamReader reader = new StreamReader("ConfigInfo.json"))
            {
                var res = reader.ReadToEnd();
                this.configInfo = JsonSerializer.Deserialize<Configuration>(res);
            }
        }

        /// <summary>
        /// Notifies when need to backup.
        /// </summary>
        public event EventHandler Notifying;

        /// <summary>
        /// Gets the instance. Used for Implementing the Singleton Pattern.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                return Example;
            }
        }

        /// <summary>
        /// Gets allLogs.
        /// </summary>
        public string AllLogs
        {
            get { return this.allLogs; }
        }

        /// <summary>
        /// Logs information into the certain file.
        /// </summary>
        /// <param name="message">Text message for logging.</param>
        /// <param name="path">A path for a file.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LogInfoAsync(string message, string path)
        {
            string buf = $"{DateTime.Now.ToString()}\t{message}\n";
            this.allLogs += buf;

            if (this.logsCounter % this.configInfo.N == 0)
            {
                this.NotifyAboutLogging(this, EventArgs.Empty);
                using (StreamWriter reader = new StreamWriter(path))
                {
                    await reader.WriteLineAsync(this.allLogs);
                }
            }

            this.logsCounter++;
        }

        private void NotifyAboutLogging(object sender, EventArgs e)
        {
            if (this.Notifying != null)
            {
                this.Notifying.Invoke(this, e);
            }
        }
    }
}
