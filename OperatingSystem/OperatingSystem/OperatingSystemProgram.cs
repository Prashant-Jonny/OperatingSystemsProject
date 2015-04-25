using System;
using System.Collections.Generic;
using System.Linq;

namespace OperatingSystem
{
    public class OperatingSystemProgram
    {
        public static void Main(string[] args)
        {
            var textFromFile = ReadInputFromFile();
            InitializeOS(textFromFile, AllocationStrategy.BestFit);
            var memoryManager = new MemoryManager(_memorySize, _memoryBlocks);

            while (ReadyQueue.Length > 0)
            {
                var processes = ReadyQueue.GetProcessesArrivingAtTime(Clock);
                var processIdsOfProcessesInMemory = memoryManager.GetProcessesInMemory();
                var processesInMemory = _allProcesses.FindAll(p => processIdsOfProcessesInMemory.Contains(p.ProcessID));

                foreach (var process in processesInMemory)
                {
                    if (process.StartTime + process.ProcessDuration <= Clock)
                        memoryManager.Deallocate(process.ProcessID);
                }

                foreach (var process in processes)
                {
                    try
                    {
                        var success = memoryManager.Allocate(process, _allocationStrategy);
                        if (success)
                            ReadyQueue.DeleteProcess(process.ProcessID);

                        Console.WriteLine(String.Format("Clock: {0}", Clock));
                        Console.WriteLine(memoryManager.PrintMemory());
                        Console.WriteLine(ReadyQueue.PrintQueue());
                    }

                    catch (FragmentationException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
                IncrementClock();
            }

            Console.WriteLine(String.Format("----------------------------------\n\r\n\rAll processes have been allocated memory. Final clock value: {0}\n\r", Clock - 1));
        }

        private static int _memorySize;
        private static int[] _memoryBlocks;

        private static void InitializeOS(string textFromFile, AllocationStrategy allocationStrategy)
        {
            _allocationStrategy = allocationStrategy;
            var lines = textFromFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var firstLine = lines[0];
            var piecesOfFirstLine = firstLine.Split(new char[] { ' ' });
            _memorySize = Int32.Parse(piecesOfFirstLine[0]);
            _memoryBlocks = new int[piecesOfFirstLine.Length - 1];
            var blockSizes = String.Empty;

            for (var i = 1; i < piecesOfFirstLine.Length; i++)
            {
                var blockSize = Int32.Parse(piecesOfFirstLine[i]);
                _memoryBlocks[i - 1] = blockSize;
                blockSizes = String.Format("{0}\t{1}", blockSizes, blockSize);
            }

            _allProcesses = new List<ProcessControlBlock>();
            for (var i = 1; i < lines.Length; i++)
            {
                var pieces = lines[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                var processId = Int32.Parse(pieces[0]);
                if (processId == 0)
                    throw new Exception("Process ID 0 is not allowed. Please change the input data and try again.");

                var arrivalTime = Int32.Parse(pieces[1]);
                var duration = Int32.Parse(pieces[2]);
                var memorySize = Int32.Parse(pieces[3]);
                var process = new ProcessControlBlock(processId);
                process.StartTime = arrivalTime;
                process.ProcessDuration = duration;
                process.MemorySize = memorySize;

                ReadyQueue.AddProcess(process);
                _allProcesses.Add(process);
            }
            Clock = 0;

            Console.WriteLine(String.Format("Initializing operating system\n\rTotal memory size: {0}\n\rMemory allocation strategy: {1}\n\rBlock sizes:{2}\n\r\n\r", _memorySize, _allocationStrategy, blockSizes));
        }

        private static string ReadInputFromFile()
        {
            var fileText = System.IO.File.ReadAllText(@"D:\Ajinkya\Code\Git Repos\OperatingSystem\OperatingSystem\data\OperatingSystemInput2.txt");
            return fileText;
        }

        private static int Clock { get; set; }

        public static int IncrementClock()
        {
            Clock++;
            return Clock;
        }

        private static ProcessQueue _readyQueue;
        private static List<ProcessControlBlock> _allProcesses;
        private static AllocationStrategy _allocationStrategy;
        public static ProcessQueue ReadyQueue
        {
            get
            {
                if (_readyQueue == null)
                    _readyQueue = new ProcessQueue(QueueType.Ready);

                return _readyQueue;
            }

            set
            {
                _readyQueue = value;
            }
        }

        public static int GetClockValue()
        {
            return Clock;
        }
 
        private static void Phase1()
        {
            var readyQueue = new ProcessQueue(QueueType.Ready);
            //readyQueue.GetNextProcess();
            readyQueue.AddProcess(new ProcessControlBlock(1000));
            readyQueue.AddProcess(new ProcessControlBlock(1001));
            readyQueue.AddProcess(new ProcessControlBlock(1002));
            readyQueue.AddProcess(new ProcessControlBlock(1003));
            readyQueue.AddProcess(new ProcessControlBlock(1004));
            readyQueue.AddProcess(new ProcessControlBlock(1005));
            readyQueue.AddProcess(new ProcessControlBlock(1006));
            readyQueue.AddProcess(new ProcessControlBlock(1007));
            readyQueue.AddProcess(new ProcessControlBlock(1008));
            readyQueue.AddProcess(new ProcessControlBlock(1009));
            readyQueue.AddProcess(new ProcessControlBlock(1010), 3);
            readyQueue.AddProcess(new ProcessControlBlock(1011), 7);

            readyQueue.DeleteProcess(1008);

            var waitingQueue = new ProcessQueue(QueueType.Waiting);
            waitingQueue.AddProcess(new ProcessControlBlock(2000));
            waitingQueue.AddProcess(new ProcessControlBlock(2001));
            waitingQueue.AddProcess(new ProcessControlBlock(2002));
            waitingQueue.AddProcess(new ProcessControlBlock(2003));
            waitingQueue.AddProcess(new ProcessControlBlock(2004));
            waitingQueue.AddProcess(new ProcessControlBlock(2005));
            waitingQueue.AddProcess(new ProcessControlBlock(2006));
            waitingQueue.AddProcess(new ProcessControlBlock(2007));
            waitingQueue.AddProcess(new ProcessControlBlock(2008));
            waitingQueue.AddProcess(new ProcessControlBlock(2009));
            waitingQueue.AddProcess(new ProcessControlBlock(2010), 5);
            waitingQueue.AddProcess(new ProcessControlBlock(2011), 8);

            var processToMove = readyQueue.GetNextProcess();
            waitingQueue.AddProcess(processToMove);

            var process = new ProcessControlBlock(3000);

            Console.WriteLine("\n\rNew process:");
            Console.WriteLine(process.Print());

            Console.WriteLine("12 processes have been added to the ready queue. 1 process (PID 1008) was deleted.");

            process = readyQueue.GetNextProcess();
            Console.WriteLine("\n\rNext process in the ready queue");
            Console.WriteLine(process.Print());

            process = readyQueue.GetNextProcess();
            Console.WriteLine("\n\rNext process in the ready queue");
            Console.WriteLine(process.Print());

            Console.WriteLine("12 processes have been added to the waiting queue.");
            process = waitingQueue.GetNextProcess();
            Console.WriteLine("\n\rNext process in the waiting queue");
            Console.WriteLine(process.Print());

            process = waitingQueue.GetNextProcess();
            Console.WriteLine("\n\rNext process in the waiting queue");
            Console.WriteLine(process.Print());

            Console.WriteLine("\n\rReady Queue");
            Console.WriteLine(readyQueue.PrintQueue());

            Console.WriteLine("\n\rWaiting Queue");
            Console.WriteLine(waitingQueue.PrintQueue());
        }
    }
}
