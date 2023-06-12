using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteringWpf.ViewModels
{
    /// <summary>
    /// Provides the text value to the UI to demonstrate how to data bind to different methods of outputting text.
    /// </summary>
    public class TextViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the text value to be used to demonstrate how to data bind to different methods of outputting text.
        /// </summary>
        public string Text { get; set; } = "Efficient";
    }
}
