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
            this._type = type;
            this._queue = new List<ProcessControlBlock>();
        }

        private List<ProcessControlBlock> _queue;
        private QueueType _type;

        public void AddProcess(ProcessControlBlock process)
        {
            if (this._type == QueueType.Ready)
                process.State = ProcessState.Ready;
            else
                process.State = ProcessState.Waiting;

            this._queue.Add(process);
        }

        public void AddProcess(ProcessControlBlock process, int position)
        {
            if (this._type == QueueType.Ready)
                process.State = ProcessState.Ready;
            else
                process.State = ProcessState.Waiting;

            this._queue.Insert(position - 1, process);
        }

        public void DeleteProcess(int processId)
        {
            foreach (var p in this._queue)
            {
                if (p.ProcessID == processId)
                {
                    this._queue.Remove(p);
                    return;
                }
            }

            throw new ArgumentException("Invalid Process ID");
        }

        public ProcessControlBlock GetNextProcess()
        {
            if (this._queue.Count > 0)
            {
                var process = this._queue[0];
                this._queue.Remove(process);

                return process;
            }

            return null;
        }

        public IEnumerable<ProcessControlBlock> GetProcessesArrivingAtTime(int time)
        {
            var processes = this._queue.FindAll(p => p.StartTime == time);
            return processes;
        }

        public string PrintQueue()
        {
            var sb = new StringBuilder();

            for (var i = 0; i < this._queue.Count; i++)
            {
                var process = this._queue[i];
                sb.AppendFormat("Position: {0}\tProcess ID: {1}\tProcess State: {2}\n\r", i + 1, process.ProcessID, process.State);
            }

            return sb.ToString();
        }

        public int Length { get { return this._queue.Count; } }
    }
}
