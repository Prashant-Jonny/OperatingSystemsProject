using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.Write("\n\r\n\r[\n\r");
            for (var i = 0; i < this.NumberOfNodes; i++)
            {
                for (var j = 0; j < this.NumberOfNodes; j++)
                {
                    Console.Write(String.Format(" {0}", Graph[i, j]==1?"1":"_"));
                }
                Console.Write("\n\r");
            }
            Console.Write("]\n\r\n\r");
            var nodesAndDegree = new Dictionary<int, int>();

            //string output = "\t{0}: {1}\n\r";
            //Console.WriteLine("Vertex degree:\n\r");
            for (var i = 0; i < this.NumberOfNodes; i++)
            {
                var degree = 0;
                for (var j = 0; j < this.NumberOfNodes; j++)
                {
                    degree += _graph[i, j];
                }
                nodesAndDegree.Add(i, degree);

                //Console.Write(String.Format(output, i, degree));
            }

            //Console.WriteLine("\n\rVertex degree in order:\n\r");
            var foo = nodesAndDegree.OrderBy(x => x.Value * -1).ToDictionary(pair => pair.Key, pair => pair.Value);
            //foreach (var item in foo)
            //{
            //    Console.Write(String.Format(output, item.Key, item.Value));
            //}


            Console.Write("\n\r\n\r[\n\r");
            foreach (var item in foo.Keys)
            {
                foreach (var item2 in foo.Keys)
                {
                    Console.Write(String.Format(" {0}", Graph[item, item2] == 1 ? "1" : "_"));
                }
                Console.Write("\n\r");
            }
            Console.Write("]\n\r\n\r");
        }
    }
}
