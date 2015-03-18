using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var readyQueue = new ProcessQueue(QueueType.Ready);

            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1000 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1001 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1002 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1003 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1004 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1005 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1006 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1007 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1008 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1009 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1010 }, 3);
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1011 }, 7);

            readyQueue.DeleteProcess(8);

            var waitingQueue = new ProcessQueue(QueueType.Waiting);
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2000 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2001 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2002 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2003 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2004 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2005 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2006 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2007 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2008 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2009 });
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2010 }, 5);
            waitingQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2011 }, 8);

            var processToMove = readyQueue.GetNextProcess();
            waitingQueue.AddProcess(processToMove);

            var process = readyQueue.GetNextProcess();
            Console.WriteLine("\n\rNext process in the ready Queue");
            Console.WriteLine(process.Print());
            
            process = readyQueue.GetNextProcess();
            Console.WriteLine("\n\rNext process in the ready Queue");
            Console.WriteLine(process.Print());

            Console.WriteLine("\n\rReady Queue");
            Console.WriteLine(readyQueue.PrintQueue());

            Console.WriteLine("\n\rWaiting Queue");
            Console.WriteLine(waitingQueue.PrintQueue());
        }
    }
}
