using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class ProcessQueue : IProcessQueue
    {
        public ProcessQueue()
        {
            queue = new List<ProcessControlBlock>();
        }

        private List<ProcessControlBlock> queue;

        public void AddProcess(ProcessControlBlock process)
        {
            queue.Add(process);
        }

        public void AddProcess(ProcessControlBlock process, int position)
        {
            queue.Insert(position - 1, process);
        }

        public void DeleteProcess(int processId)
        {
            var process = queue.Find(p => p.ProcessID == processId);
            queue.Remove(process);
        }

        public ProcessControlBlock GetNextProcess()
        {
            var process = queue[0];
            queue.Remove(process);

            return process;
        }

        public string PrintQueue()
        {
            var sb = new StringBuilder();

            for (var i = 1; i <= queue.Count; i++)
            {
                sb.AppendFormat("Position: {0}\tProcess ID: {1}\n\r", i, queue[i - 1].ProcessID);
            }

            return sb.ToString();
        }
    }
}
