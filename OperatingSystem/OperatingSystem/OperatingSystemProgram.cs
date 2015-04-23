using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class OperatingSystemProgram
    {
        public static void Main(string[] args)
        {
            var textFromFile = ReadInputFromFile();
            InitializeOS(textFromFile);
            Clock = 0;

            var memoryManager = new MemoryManager(_memorySize, _memoryBlocks);

            IncrementClock();
            while (ReadyQueue.Length > 0)
            {
                var processes = ReadyQueue.GetProcessesArrivingAtTime(Clock);
                foreach (var process in processes)
                {
                    try
                    {
                        memoryManager.Allocate(process, AllocationStrategy.FirstFit);
                        Console.WriteLine(memoryManager.PrintMemory());
                        Console.WriteLine(ReadyQueue.PrintQueue());
                    }

                    catch (FragmentationException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }

                }
            }

            Console.WriteLine(String.Format("----------------------------------\n\r\n\rFinal clock value: {0}", Clock));

            //Phase1();
        }

        private static int _memorySize;
        private static int[] _memoryBlocks;

        private static void InitializeOS(string textFromFile)
        {
            var lines = textFromFile.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var firstLine = lines[0];

            var piecesOfFirstLine = firstLine.Split(new char[] { ' ' });
            _memorySize = Int32.Parse(piecesOfFirstLine[0]);
            _memoryBlocks = new int[piecesOfFirstLine.Length - 1];

            for (var i = 1; i < piecesOfFirstLine.Length; i++)
            {
                _memoryBlocks[i - 1] = Int32.Parse(piecesOfFirstLine[i]);
            }
        }

        private static string ReadInputFromFile()
        {
            var fileText = System.IO.File.ReadAllText(@"D:\Ajinkya\Code\Git Repos\OperatingSystem\OperatingSystem\data\OperatingSystemInput.txt");
            return fileText;
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

        private static int Clock { get; set; }

        public static int IncrementClock()
        {
            Clock++;
            return Clock;
        }

        private static ProcessQueue _readyQueue;
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
    }
}
