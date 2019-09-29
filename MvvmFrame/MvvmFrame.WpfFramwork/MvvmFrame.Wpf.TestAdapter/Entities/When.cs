using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// When info
    /// </summary>
    public class When
    {
        internal Queue<Func<ValueTask>> FuncsQueue { get; set; }
        /// <summary>
        /// Discription
        /// </summary>
        public string Discription { get; set; }
        /// <summary>
        /// Given
        /// </summary>
        public Given Given { get; internal set; }
    }
}
