using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public interface IProcessQueue
    {
        void AddProcess(ProcessControlBlock process);
        void AddProcess(ProcessControlBlock process, int position);
        void DeleteProcess(int processId);
        ProcessControlBlock GetNextProcess();
        string PrintQueue();
    }
}
