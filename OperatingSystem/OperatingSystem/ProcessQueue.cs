using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public enum QueueType
    {
        Ready,
        Waiting
    }

    public class ProcessQueue : IProcessQueue
    {
        public ProcessQueue(QueueType type)
        {
            this.type = type;
            this.queue = new List<ProcessControlBlock>();
        }

        private List<ProcessControlBlock> queue;
        private QueueType type;

        public void AddProcess(ProcessControlBlock process)
        {
            if (this.type == QueueType.Ready)
                process.State = ProcessState.Ready;
            else
                process.State = ProcessState.Waiting;

            this.queue.Add(process);
        }

        public void AddProcess(ProcessControlBlock process, int position)
        {
            if (this.type == QueueType.Ready)
                process.State = ProcessState.Ready;
            else
                process.State = ProcessState.Waiting;

            this.queue.Insert(position - 1, process);
        }

        public void DeleteProcess(int processId)
        {
            var process = this.queue.Find(p => p.ProcessID == processId);
            this.queue.Remove(process);
        }

        public ProcessControlBlock GetNextProcess()
        {
            var process = this.queue[0];
            this.queue.Remove(process);

            return process;
        }

        public string PrintQueue()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < this.queue.Count; i++)
            {
                var process = this.queue[i];
                sb.AppendFormat("Position: {0}\tProcess ID: {1}\tProcess State: {2}\n\r", i + 1, process.ProcessID, process.State);
            }

            return sb.ToString();
        }
    }
}
