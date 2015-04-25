using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatingSystem
{
    class MemoryManager
    {
        public MemoryManager(int memorySize, int[] blockSizes)
        {
            if (blockSizes == null || blockSizes.Length == 0)
                blockSizes = new int[1] { memorySize };

            var blockSizeTotal = 0;
            this.Memory = new List<int[]>();
            foreach (var blockSize in blockSizes)
            {
                this.Memory.Add(new int[blockSize]);
                blockSizeTotal += blockSize;
            }

            if (blockSizeTotal != memorySize)
                throw new Exception("Block sizes specified do not total up to memory size.");
        }

        public List<int[]> Memory { get; set; }

        public bool Allocate(ProcessControlBlock process, AllocationStrategy strategy)
        {
            var retVal = false;
            var totalAvailableMemory = FindTotalAvailableMemory();
            if (totalAvailableMemory < process.MemorySize)
                return retVal;
            switch (strategy)
            {
                case AllocationStrategy.FirstFit:
                    retVal = this.AllocateUsingFirstFit(process);
                    break;
                case AllocationStrategy.BestFit:
                    retVal = this.AllocateUsingBestFit(process);
                    break;
                case AllocationStrategy.WorstFit:
                    retVal = this.AllocateUsingWorstFit(process);
                    break;
            }

            return retVal;
        }

        private int FindTotalAvailableMemory()
        {
            var totalAvailableMemory = 0;
            foreach (var block in this.Memory)
            {
                foreach (var location in block)
                {
                    if (location == 0)
                        totalAvailableMemory++;
                }
            }

            return totalAvailableMemory;
        }

        public int[] GetProcessesInMemory()
        {
            var processes = new int[this.Memory.Count];
            for (var i = 0; i < this.Memory.Count; i++)
            {
                processes[i] = Memory[i][0];
            }

            return processes;
        }

        public string PrintMemory()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < this.Memory.Count; i++)
            {
                var block = this.Memory[i];
                for (var j = 0; j < block.Length; j++)
                {
                    sb.AppendFormat("{0}\t", block[j]);
                }
                sb.Append("\n\r");
            }

            return sb.ToString();
        }

        private bool AllocateUsingFirstFit(ProcessControlBlock process)
        {
            var requiredSize = process.MemorySize;

            try
            {
                var block = this.Memory.First(b => b.Length >= requiredSize && b[0] == 0);
                for (var i = 0; i < requiredSize; i++)
                {
                    block[i] = process.ProcessID;
                }
            }
            catch (InvalidOperationException)
            {
                throw new FragmentationException(String.Format("There was not a large enough empty block at time {0} to accommodate process {1}. Program ending because of fragmentation.", OperatingSystemProgram.GetClockValue(), process.ProcessID));
            }
            return true;
        }

        private bool AllocateUsingBestFit(ProcessControlBlock process)
        {
            var requiredSize = process.MemorySize;

            try
            {
                var blocks = this.Memory.FindAll(b => b.Length >= requiredSize && b[0] == 0);
                if (blocks.Count == 0)
                    throw new InvalidOperationException();

                var delta = blocks[0].Length;
                var index = 0;

                for (var i = 0; i < blocks.Count; i++)
                {
                    var difference = blocks[i].Length - requiredSize;
                    if (difference < delta)
                    {
                        delta = difference;
                        index = i;
                    }
                }

                var block = blocks[index];
                for (var i = 0; i < requiredSize; i++)
                {
                    block[i] = process.ProcessID;
                }
            }
            catch (InvalidOperationException)
            {
                throw new FragmentationException(String.Format("There was not a large enough empty block at time {0} to accommodate process {1}. Program ending because of fragmentation.", OperatingSystemProgram.GetClockValue(), process.ProcessID));
            }
            return true;
        }

        private bool AllocateUsingWorstFit(ProcessControlBlock process)
        {
            var requiredSize = process.MemorySize;

            try
            {
                var blocks = this.Memory.FindAll(b => b.Length >= requiredSize && b[0] == 0);
                if (blocks.Count == 0)
                    throw new InvalidOperationException();

                var delta = blocks[0].Length;
                var index = 0;

                for (var i = 0; i < blocks.Count; i++)
                {
                    var difference = blocks[i].Length - requiredSize;
                    if (difference > delta)
                    {
                        delta = difference;
                        index = i;
                    }
                }

                var block = blocks[index];
                for (var i = 0; i < requiredSize; i++)
                {
                    block[i] = process.ProcessID;
                }
            }
            catch (InvalidOperationException)
            {
                throw new FragmentationException(String.Format("There was not a large enough empty block at time {0} to accommodate process {1}. Program ending because of fragmentation.", OperatingSystemProgram.GetClockValue(), process.ProcessID));
            }
            return true;
        }

        public void Deallocate(int processId)
        {
            for (var i = 0; i < this.Memory.Count; i++)
            {
                var block = this.Memory[i];
                if (block[0] == processId)
                    this.Memory[i] = new int[block.Length];
            }
        }
    }
}
