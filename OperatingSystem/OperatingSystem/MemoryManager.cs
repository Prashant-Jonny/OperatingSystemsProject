using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    class MemoryManager
    {
        public MemoryManager(int memorySize, int[] blockSizes)
        {
            if (blockSizes.Length == 0)
                blockSizes[0] = memorySize;

            var blockSizeTotal = 0;
            foreach(var blockSize in blockSizes)
            {
                blockSizeTotal += blockSize;
            }

            if (blockSizeTotal != memorySize)
                throw new Exception("Block sizes specified do not total up to memory size.");

            _memory = new List<int[]>();
            foreach(var blockSize in blockSizes)
            {
                _memory.Add(new int[blockSize]);
            }
        }

        private List<int[]> _memory;

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
            for (var i = 0; i < _memory.Count; i++)
            {
                var block = _memory[i];
                for (var j = 0; j < block.Length; j++)
                {
                    sb.AppendFormat("{0}\t", block[j]);
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
