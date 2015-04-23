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
            foreach (var blockSize in blockSizes)
            {
                blockSizeTotal += blockSize;
            }

            if (blockSizeTotal != memorySize)
                throw new Exception("Block sizes specified do not total up to memory size.");

            Memory = new List<int[]>();
            foreach (var blockSize in blockSizes)
            {
                this.Memory.Add(new int[blockSize]);
            }
        }

        public List<int[]> Memory { get; set; }

        public void Allocate(ProcessControlBlock process, AllocationStrategy strategy)
        {
            switch (strategy)
            {
                case AllocationStrategy.FirstFit:
                    this.AllocateUsingFirstFit(process);
                    break;
                case AllocationStrategy.BestFit:
                    this.AllocateUsingBestFit(process);
                    break;
                case AllocationStrategy.WorstFit:
                    this.AllocateUsingWorstFit(process);
                    break;
            }
        }

        public string PrintMemory()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < this.Memory.Count; i++)
            {
                var block = Memory[i];
                for (var j = 0; j < block.Length; j++)
                {
                    sb.AppendFormat("{0}\t", block[j]);
                }
                sb.Append("\n\r");
            }

            return sb.ToString();
        }

        private void AllocateUsingFirstFit(ProcessControlBlock process)
        {
            var requiredSize = process.MemorySize;

            try
            {
                var block = Memory.First(b => b.Length >= requiredSize && b[0] == 0);
                for (var i = 0; i < requiredSize; i++)
                {
                    block[i] = process.ProcessID;
                }
            }
            catch (InvalidOperationException)
            {
                throw new FragmentationException(String.Format("There was not a large enough empty block at time {0} to accommodate this process {1}. Program ending because of fragmentation.", OperatingSystemProgram.GetClockValue(), process.ProcessID));
            }
            return;
        }

        private void AllocateUsingBestFit(ProcessControlBlock process)
        {
            var requiredSize = process.MemorySize;

            try
            {
                var blocks = Memory.FindAll(b => b.Length >= requiredSize && b[0] == 0);
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
                throw new FragmentationException(String.Format("There was not a large enough empty block at time {0} to accommodate this process {1}. Program ending because of fragmentation.", OperatingSystemProgram.GetClockValue(), process.ProcessID));
            }
            return;
        }

        private void AllocateUsingWorstFit(ProcessControlBlock process)
        {
            var requiredSize = process.MemorySize;

            try
            {
                var blocks = Memory.FindAll(b => b.Length >= requiredSize && b[0] == 0);
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
                throw new FragmentationException(String.Format("There was not a large enough empty block at time {0} to accommodate this process {1}. Program ending because of fragmentation.", OperatingSystemProgram.GetClockValue(), process.ProcessID));
            }
            return;
        }

        public bool Deallocate(int time)
        {


            return true;
        }
    }
}
