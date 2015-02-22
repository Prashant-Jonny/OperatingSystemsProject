using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GraphAssignment1
{
    public interface IGraph
    {
        int NumberOfNodes { get; }
        float EdgeProbability { get; }
        int[,] Graph { get; set; }
        void Print();
    }


    public class RandomGraph : IGraph
    {
        public RandomGraph(int numberOfNodes, float edgeProbability)
        {
            this._numberOfNodes = numberOfNodes;
            this._edgeProbability = edgeProbability;
            _generator = new Random();
        }

        private Random _generator;
        private int _numberOfNodes;
        public int NumberOfNodes
        {
            get
            {
                return _numberOfNodes;
            }
        }

        private float _edgeProbability;
        public float EdgeProbability
        {
            get
            {
                return this._edgeProbability;
            }
        }

        private int[,] _graph;
        public int[,] Graph
        {
            get
            {
                if (_graph == null)
                {
                    var max = (int)Math.Floor(1 / this.EdgeProbability);
                    if (this.EdgeProbability > 0.5)
                        max = (int)Math.Floor(1 / (1 - this.EdgeProbability));

                    _graph = new int[this.NumberOfNodes, this.NumberOfNodes];

                    for (var i = 0; i < this.NumberOfNodes; i++)
                    {
                        for (var j = 0; j < this.NumberOfNodes; j++)
                        {
                            if (i < j)
                            {
                                _graph[i, j] = _generator.Next(max) == 0 ? 1 : 0;
                                if (this.EdgeProbability > 0.5)
                                    _graph[i, j] = _generator.Next(max) == 0 ? 0 : 1;
                            }
                            else if (i > j)
                                _graph[i, j] = _graph[j, i];
                            else
                                _graph[i, j] = 0;
                        }
                    }
                }

                return _graph;
            }
            set { throw new System.NotImplementedException(); }
        }

        public void Print()
        {
            var graph = new StringBuilder(String.Format("Graph G has {0} vertice(s) and an edge probability of {1}", this.NumberOfNodes, this.EdgeProbability));

            graph.Append("\r\n\r\n[\r\n");
            for (var i = 0; i < this.NumberOfNodes; i++)
            {
                for (var j = 0; j < this.NumberOfNodes; j++)
                {
                    graph.AppendFormat(" {0}", Graph[i, j] == 1 ? "1" : "_");
                }
                graph.Append("\r\n");
            }
            graph.Append("]\r\n\r\n");

            var nodesAndDegree = new Dictionary<int, int>();

            //string output = "\t{0}: {1}";
            //Console.WriteLine("Vertex degree:\r\n");
            for (var i = 0; i < this.NumberOfNodes; i++)
            {
                var degree = 0;
                for (var j = 0; j < this.NumberOfNodes; j++)
                {
                    degree += _graph[i, j];
                }
                nodesAndDegree.Add(i, degree);

                //Console.WriteLine(String.Format(output, i, degree));
            }

            //Console.WriteLine("\r\nVertex degree in order:\r\n");
            var sortedNodesAndDegre = nodesAndDegree.OrderBy(x => x.Value * -1).ToDictionary(pair => pair.Key, pair => pair.Value);
            //foreach (var item in foo)
            //{
            //    Console.WriteLine(String.Format(output, item.Key, item.Value));
            //}

            var sortedGraph = new StringBuilder();

            sortedGraph.Append("Sorted by vertex degree\r\n\r\n[\r\n");
            foreach (var item in sortedNodesAndDegre.Keys)
            {
                foreach (var item2 in sortedNodesAndDegre.Keys)
                {
                    sortedGraph.AppendFormat(" {0}", Graph[item, item2] == 1 ? "1" : "_");
                }
                sortedGraph.Append("\r\n");
            }
            sortedGraph.Append("]\r\n\r\n");

            using (StreamWriter file = new StreamWriter(@"C:\Users\Ajinkya\Google Drive\CSE 8355 Assignments\1v b.txt", true))
            {
                file.WriteLine(graph);
                file.WriteLine(sortedGraph);
            }

            //Console.WriteLine(graph);   //  ############################################################
            //Console.WriteLine(sortedGraph);   //  ############################################################
        }

        public int GetDiameter()
        {
            int retVal = 0;

            if (this.NumberOfNodes < 4)
                retVal = 1;

            return retVal;
        }

    }
}
