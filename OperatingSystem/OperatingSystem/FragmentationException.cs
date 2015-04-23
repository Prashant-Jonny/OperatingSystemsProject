using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystem
{
    public class FragmentationException : Exception
    {
        public FragmentationException(string message) : base(message) { }
    }
}
