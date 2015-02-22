using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphAssignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodeCount = 40;
            float edgeProbability = (float)0.3;
            var graph = new RandomGraph(nodeCount, edgeProbability);
            graph.Print();
        }
    }
}
