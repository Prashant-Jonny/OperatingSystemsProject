using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class MemoryManager
    {
        public MemoryManager(int memorySize)
        {
            _memory = new int[memorySize];
        }

        private int[] _memory;

        public bool Allocate(int PID, AllocationStrategy strategy)
        {
            switch(strategy)
            {
                case AllocationStrategy.FirstFit:
                    return this.AllocateUsingFirstFit(PID);
                case AllocationStrategy.BestFit:
                    return this.AllocateUsingBestFit(PID);
                case AllocationStrategy.WorstFit:
                    return this.AllocateUsingWorstFit(PID);
            }

            return false;
        }

        public string PrintMemory()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < _memory.Length; i += 10)
            {
                for (var j = 0; j < 10; j++)
                {
                    sb.AppendFormat("{0}\t");
                }
                sb.Append("\n\r");
            }

            return sb.ToString();
        }

        private bool AllocateUsingFirstFit(int PID)
        {
            return false;
        }

        private bool AllocateUsingBestFit(int PID)
        {
            return false;
        }

        private bool AllocateUsingWorstFit(int PID)
        {
            return false;
        }

        public bool Deallocate(int time)
        {


            return true;
        }
    }
}
