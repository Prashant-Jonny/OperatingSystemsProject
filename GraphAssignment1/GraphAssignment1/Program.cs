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
            int nodeCount = 20;
            float edgeProbability = (float)0.25;
            var graph = new RandomGraph(nodeCount, edgeProbability);
            Console.WriteLine(String.Format("Graph G has {0} vertice(s) and an edge probability of {1}", nodeCount, edgeProbability));
            graph.Print();
        }
    }
}
