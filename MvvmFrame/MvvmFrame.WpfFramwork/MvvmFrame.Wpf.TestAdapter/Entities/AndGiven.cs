using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MvvmFrame.Wpf.TestAdapter.Entities
{
    /// <summary>
    /// Аn object storing a link to the finished frame
    /// </summary>
    public class AndGiven: Given
    {
        /// <summary>
        /// Previous given
        /// </summary>
        public Given PreviousGiven { get; internal set; }
    }
}
