using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_7
{
    /// <summary>
    /// d.
    /// </summary>
    internal class Configuration
    {
        private int n;
        private string info;

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>S
        /// <param name="n">a.</param>
        /// /// <param name="info">d.</param>
        public Configuration(int n, string info)
        {
            this.n = n;
            this.info = info;
        }

        /// <summary>
        /// Gets or sets n.
        /// </summary>
        public int N
        {
            get { return this.n; }
            set { this.n = value; }
        }

        /// <summary>
        /// Gets or sets str.
        /// </summary>
        public string Info
        {
            get { return this.info; }
            set { this.info = value; }
        }
    }
}
