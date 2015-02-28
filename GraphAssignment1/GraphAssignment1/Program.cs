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
            int nodeCount = 400;
            float edgeProbability = (float)0.21;
            //var graph = new RandomGraph(nodeCount, edgeProbability);
            //graph.Print();
            //var diameter = graph.GetDiameter();
            var dia2 = 0;
            var dia3 = 0;

            foo(nodeCount, edgeProbability, out dia2, out dia3);

            Console.WriteLine(String.Format("When node count was {1} and edge probability was {2},\r\nDiameter of graph was <= 2: {0}", dia2, nodeCount, edgeProbability));
            Console.WriteLine(String.Format("Diameter of graph was >= 3: {0}", dia3));
        }

        static void foo(int nodeCount, float edgeProbability, out int dia2, out int dia3)
        {
            dia2 = 0;
            dia3 = 0;

            for (var i = 0; i < 1000; i++)
            {
                var graph = new RandomGraph(nodeCount, edgeProbability);
                graph.Print();
                var diameter = graph.GetDiameter();


                if (diameter <= 2)
                    dia2++;
                else
                    dia3++;

            }
        }
    }
}
