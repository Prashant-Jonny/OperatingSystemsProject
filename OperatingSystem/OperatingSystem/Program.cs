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
            var readyQueue = new ProcessQueue();

            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 0 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 1 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 2 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 3 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 4 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 5 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 6 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 7 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 8 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 9 });
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 10 }, 3);
            readyQueue.AddProcess(new ProcessControlBlock() { ProcessID = 11 }, 7);

            readyQueue.DeleteProcess(8);


            var process = readyQueue.GetNextProcess();
            Console.WriteLine(process.Print());
            
            process = readyQueue.GetNextProcess();
            Console.WriteLine(process.Print());

            Console.WriteLine(readyQueue.PrintQueue());
        }
    }
}
