using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphAssignment1
{
    public class RandomGraph : IGraph
    {
        public RandomGraph(int numberOfNodes, float edgeProbability)
        {
            if (numberOfNodes <= 0)
                throw new ArgumentOutOfRangeException("The graph must have at least one vertex");

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
                    _graph = new int[this.NumberOfNodes, this.NumberOfNodes];

                    if (this.EdgeProbability == 1)
                    {
                        for (var i = 0; i < this.NumberOfNodes; i++)
                        {
                            for (var j = 0; j < this.NumberOfNodes; j++)
                            {
                                _graph[i, j] = 1;
                            }
                        }
                    }
                    else if (this.EdgeProbability == 0)
                    {
                        for (var i = 0; i < this.NumberOfNodes; i++)
                        {
                            for (var j = 0; j < this.NumberOfNodes; j++)
                            {
                                _graph[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        var max = (int)Math.Floor(1 / this.EdgeProbability);
                        if (this.EdgeProbability > 0.5)
                            max = (int)Math.Floor(1 / (1 - this.EdgeProbability));

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
                }

                return _graph;
            }
            set { throw new System.NotImplementedException(); }
        }

        private Dictionary<int, int> _sortedGraph;

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
            this._sortedGraph = nodesAndDegree.OrderBy(x => x.Value * -1).ToDictionary(pair => pair.Key, pair => pair.Value);
            //foreach (var item in foo)
            //{
            //    Console.WriteLine(String.Format(output, item.Key, item.Value));
            //}

            var sortedGraph = new StringBuilder();

            sortedGraph.Append("Sorted by vertex degree\r\n\r\n[\r\n");
            foreach (var item in _sortedGraph.Keys)
            {
                foreach (var item2 in _sortedGraph.Keys)
                {
                    sortedGraph.AppendFormat(" {0}", Graph[item, item2] == 1 ? "1" : "_");
                }
                sortedGraph.Append("\r\n");
            }
            sortedGraph.Append("]\r\n\r\n");

            //using (StreamWriter file = new StreamWriter(@"C:\Users\Ajinkya\Google Drive\CSE 8355 Assignments\scratch.txt", true))
            //{
            //    file.WriteLine(graph);
            //    file.WriteLine(sortedGraph);
            //}

            //Console.WriteLine(graph);   //  ############################################################
            //Console.WriteLine(sortedGraph);   //  ############################################################
        }

        public int GetDiameter()
        {
            int diameter = 0;

            var adjacencyList = new Dictionary<int, List<int>>();

            if (this.NumberOfNodes > 3)
            {
                foreach (var row in this._sortedGraph.Keys)
                {
                    adjacencyList.Add(row, new List<int>());
                    foreach (var col in this._sortedGraph.Keys)
                    {
                        if (_graph[row, col] == 1)
                        {
                            adjacencyList[row].Add(col);
                        }
                    }
                }

                var nodeWithHighestDegree = this._sortedGraph.Keys.First();
                foreach (var col in this._sortedGraph)
                {
                    if (col.Key == nodeWithHighestDegree)
                    {
                        continue;
                    }

                    if (diameter <= 1)
                    {
                        if (adjacencyList[nodeWithHighestDegree].Contains(col.Key))
                        {
                            diameter = 1;
                        }
                        else
                        {
                            diameter = 2;
                            foreach (var recipientNode in adjacencyList[col.Key])
                            {
                                if (adjacencyList[nodeWithHighestDegree].Contains(recipientNode))
                                {
                                    break;
                                }
                                else
                                {
                                    diameter = 3;
                                }
                            }
                        }
                    }
                }

                //foreach (var row in this._sortedGraph.Keys)
                //{
                //    foreach (var col in this._sortedGraph.Keys)
                //    {
                //        if (row == col)
                //            continue;

                //        if (_graph[row, col] == 1)
                //        {
                //            diameter = diameter > 1 ? diameter : 1;
                //        }
                //        else
                //        {
                //            //these nodes are not directly connected.
                //            //therefore diameter must be 0 or at least 2.
                //            diameter = diameter > 0 ? diameter : 0;

                //            foreach (var neighbor in adjacencyList[row])
                //            {
                //                if (adjacencyList[col].Contains(neighbor))
                //                    diameter = 2;
                //                else
                //                    diameter = 3;   //or greater
                //            }
                //        }
                //    }
                //    if (diameter == 1)
                //        break;
                //}
            }
            return diameter;
        }
    }
}
