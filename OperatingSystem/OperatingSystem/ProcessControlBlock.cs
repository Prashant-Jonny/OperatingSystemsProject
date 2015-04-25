using System;

namespace OperatingSystem
{
    public enum ProcessState
    {
        New,
        Ready,
        Running,
        Waiting,
        Terminated
    }

    public class ProcessControlBlock
    {
        public ProcessControlBlock(int processId)
        {
            ProcessID = processId;
            State = ProcessState.New;
        }

        public ProcessState State { get; set; }
        public int ProcessID { get; private set; }
        public int MemorySize { get; set; }
        public int StartTime { get; set; }
        public int ProcessDuration { get; set; }
        public string Print()
        {
            return String.Format("Process ID: {0}\tProcess State: {1}\n\r", this.ProcessID, this.State);
        }
    }
}
