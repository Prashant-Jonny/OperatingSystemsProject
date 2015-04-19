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
            foreach (var p in this.queue)
            {
                if (p.ProcessID == processId)
                {
                    this.queue.Remove(p);
                    return;
                }
            }

            throw new ArgumentException("Invalid Process ID");
        }

        public ProcessControlBlock GetNextProcess()
        {
            if (this.queue.Count > 0)
            {
                var process = this.queue[0];
                this.queue.Remove(process);

                return process;
            }

            return null;
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
