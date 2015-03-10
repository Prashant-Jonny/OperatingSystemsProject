using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class ProcessControlBlock
    {
        public enum ProcessState
        {
            New,
            Ready,
            Running,
            Waiting,
            Terminated
        }
        
        public ProcessState State { get; set; }
        public int ProcessID { get; set; }
        public int ProgramCounter { get; set; }
        public object Registers { get; set; }   //  TODO: Figure out how to represent registers
        public int MemorySize { get; set; }
        public string Print()
        {
            return String.Format("Process ID: {0}", this.ProcessID);
        }
    }
}
