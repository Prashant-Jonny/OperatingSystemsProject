using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrality
{
    public class Program
    {
        static void Main(string[] args)
        {
            BuildModel();

            foreach (var cut in Cuts)
            {
                CalculateCentrality(cut);
                Console.WriteLine(String.Format("\n\rCut {0}\n\r", cut.ID));

                foreach (var component in cut.LHSComponents)
                {
                    Console.WriteLine(String.Format("LHS Component: {0}\n\rSize: {1}\n\rCentrality: {2}%\n\r", component.ID, component.Nodes.Count, component.Centrality * 100));
                }

                foreach (var component in cut.RHSComponents)
                {
                    Console.WriteLine(String.Format("RHS Component: {0}\n\rSize: {1}\n\rCentrality: {2}%\n\r", component.ID, component.Nodes.Count, component.Centrality * 100));
                }
            }
        }

        public static List<CutLevel> Cuts { get; set; }
        public static List<float> Possible_Z_Values { get; set; }

        public static void BuildModel()
        {
            Cuts = new List<CutLevel>();

            #region Cut1
            var cut1 = new CutLevel();
            cut1.ID = 1;
            cut1.Z_Value = 0.048913F;
            //Z_Values[1][2] = cut1.Z_Value;
            //Z_Values[2][1] = cut1.Z_Value;
            cut1.ComponentsAtLevel = new List<int>() { 1, 2 };
            cut1.LHSComponents = new List<Component>
            {
                new Component()
                {
                    ID = 1,
                    Nodes = new List<int>
                    {
                        1, 4, 5, 12, 16, 17, 22, 31, 34, 36, 47, 64, 65, 66, 77,
                        78, 84, 85, 88, 91, 93, 105, 106, 107, 108, 114, 115, 120
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 126,
                            DestinationComponent = 2,
                            EdgeCount = 93
                        }
                    },
                    ParentComponentID = 1
                }
            };
            cut1.RHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 2,
                    Nodes = new List<int>
                    {
                        2, 3, 6, 7, 8, 9, 10, 11, 13, 14, 15, 18, 19, 20, 21,
                        23, 24, 25, 26, 27, 28, 29, 30, 32, 33, 35, 37, 38, 39, 40,
                        41, 42, 43, 44, 45, 46, 48, 49, 50, 51, 52, 53, 54, 55, 56,
                        57, 58, 59, 60, 61, 62, 63, 67, 68, 69, 70, 71, 72, 73, 74,
                        75, 76, 79, 80, 81, 82, 83, 86, 87, 89, 90, 92, 94, 95, 96,
                        97, 98, 99, 100, 101, 102, 103, 104, 109, 110, 111, 112, 113, 116, 117,
                        118, 119
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 126,
                            DestinationComponent = 1,
                            EdgeCount = 93
                        }
                    },
                    ParentComponentID = 1
                }
            };
            #endregion

            #region Cut2
            var cut2 = new CutLevel();
            cut2.ID = 2;
            cut2.Z_Value = 0.0584541F;
            cut2.ComponentsAtLevel = new List<int>() { 1, 2, 3 };
            cut2.LHSComponents = new List<Component>
            {
                new Component()
                {
                    ID = 2,
                    Nodes = new List<int>
                    {
                        2, 8, 10, 13, 14, 15, 18, 19, 20, 23, 24, 26, 30, 33, 37,
                        38, 39, 43, 48, 51, 53, 54, 55, 56, 58, 62, 67, 68, 70, 71,
                        72, 73, 74, 79, 80, 81, 83, 87, 92, 94, 99, 111, 112, 113, 116,
                        118, 119
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 57,
                            DestinationComponent = 1,
                            EdgeCount = 42,
                        },
                        new Edge()
                        {
                            Capacity = 131,
                            DestinationComponent = 3,
                            EdgeCount = 100,
                        }
                    },
                    ParentComponentID = 1
                }
            };
            cut2.RHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 1,
                    Nodes = new List<int>
                    {
                        1, 4, 5, 12, 16, 17, 22, 31, 34, 36, 47, 64,
                        65, 66, 77, 78, 84, 85, 88, 91, 93, 105, 106, 107, 108,
                        114, 115, 120
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 57,
                            DestinationComponent = 2,
                            EdgeCount = 42,
                        },
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 3,
                            EdgeCount = 51,
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 3,
                    Nodes = new List<int>
                    {
                        3, 6, 7, 9, 11, 21, 25, 27, 28, 29, 32, 35, 40, 41, 42,
                        44, 45, 46, 49, 50, 52, 57, 59, 60, 61, 63, 69, 75, 76, 82,
                        86, 89, 90, 95, 96, 97, 98, 100, 101, 102, 103, 104, 109, 110, 117
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 1,
                            EdgeCount = 51,
                        },
                        new Edge()
                        {
                            Capacity = 131,
                            DestinationComponent = 2,
                            EdgeCount = 100,
                        }
                    },
                    ParentComponentID = 2
                }
            };

            #endregion

            #region Cut3
            var cut3 = new CutLevel();
            cut3.ID = 3;
            cut3.Z_Value = 0.0652174F;
            cut3.ComponentsAtLevel = new List<int>() { 1, 2, 3, 4 };
            cut3.LHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 2,
                    Nodes = new List<int>
                    {
                        2, 10, 13, 14, 15, 18, 19, 20, 23, 24, 26, 30, 33, 37,
                        38, 39, 43, 48, 51, 53, 54, 55, 56, 58, 62, 67, 68, 70, 71,
                        72, 73, 74, 79, 80, 81, 83, 87, 92, 94, 99, 111, 112, 113, 116,
                        118, 119
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 52,
                            DestinationComponent = 1,
                            EdgeCount = 40,
                        },
                        new Edge()
                        {
                            Capacity = 121,
                            DestinationComponent = 3,
                            EdgeCount = 93,
                        },
                        new Edge()
                        {
                            Capacity = 14,
                            DestinationComponent = 4,
                            EdgeCount = 10,
                        }
                    },
                    ParentComponentID = 1
                }
            };
            cut3.RHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 1,
                    Nodes = new List<int>
                    {
                        1, 4, 5, 12, 16, 17, 22, 31, 34, 36, 47, 64,
                        65, 66, 77, 78, 84, 85, 88, 91, 93, 105, 106, 107, 108,
                        114, 115, 120
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 52,
                            DestinationComponent = 2,
                            EdgeCount = 40,
                        },
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 3,
                            EdgeCount = 51,
                        },
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 4,
                            EdgeCount = 2,
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 3,
                    Nodes = new List<int>
                    {
                        3, 6, 7, 9, 11, 21, 25, 27, 28, 29, 32, 35, 40, 41, 42,
                        44, 45, 46, 49, 50, 52, 57, 59, 60, 61, 63, 69, 75, 76, 82,
                        86, 89, 90, 95, 96, 97, 98, 100, 101, 102, 103, 104, 109, 110, 117
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 1,
                            EdgeCount = 51,
                        },
                        new Edge()
                        {
                            Capacity = 121,
                            DestinationComponent = 2,
                            EdgeCount = 93,
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 4,
                            EdgeCount = 7,
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 4,
                    Nodes = new List<int>
                    {
                        8
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 1,
                            EdgeCount = 2,
                        },
                        new Edge()
                        {
                            Capacity = 14,
                            DestinationComponent = 2,
                            EdgeCount = 10,
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 3,
                            EdgeCount = 7,
                        }
                    },
                    ParentComponentID = 2
                }
            };
            #endregion

            #region Cut4
            var cut4 = new CutLevel();
            cut4.ID = 4;
            cut4.Z_Value = 0.0746871F;
            cut4.ComponentsAtLevel = new List<int>() { 1, 2, 3, 4, 5 };
            cut4.LHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 2,
                    Nodes = new List<int>
                    {
                        2, 10, 14, 15, 18, 26, 37, 38, 39, 43, 54, 55, 56, 58, 70,
                        71, 73, 74, 79, 81, 94, 99, 118, 119
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 23,
                            DestinationComponent = 1,
                            EdgeCount = 22,
                        },
                        new Edge()
                        {
                            Capacity = 39,
                            DestinationComponent = 3,
                            EdgeCount = 32,
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 4,
                            EdgeCount = 4,
                        },
                        new Edge()
                        {
                            Capacity = 48,
                            DestinationComponent = 5,
                            EdgeCount = 69,
                        }
                    },
                    ParentComponentID = 1
                }
            };
            cut4.RHSComponents = new List<Component>
            {
                new Component()
                {
                    ID = 1,
                    Nodes = new List<int>
                    {
                        1, 4, 5, 12, 16, 17, 22, 31, 34, 36, 47, 64,
                        65, 66, 77, 78, 84, 85, 88, 91, 93, 105, 106, 107, 108,
                        114, 115, 120
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 23,
                            DestinationComponent = 2,
                            EdgeCount = 22,
                        },
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 3,
                            EdgeCount = 51,
                        },
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 4,
                            EdgeCount = 2,
                        },
                        new Edge()
                        {
                            Capacity = 29,
                            DestinationComponent = 5,
                            EdgeCount = 18,
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 3,
                    Nodes = new List<int>
                    {
                        3, 6, 7, 9, 11, 21, 25, 27, 28, 29, 32, 35, 40, 41, 42,
                        44, 45, 46, 49, 50, 52, 57, 59, 60, 61, 63, 69, 75, 76, 82,
                        86, 89, 90, 95, 96, 97, 98, 100, 101, 102, 103, 104, 109, 110, 117
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 1,
                            EdgeCount = 51
                        },
                        new Edge()
                        {
                            Capacity = 39,
                            DestinationComponent = 2,
                            EdgeCount = 32
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 4,
                            EdgeCount = 7
                        },
                        new Edge()
                        {
                            Capacity = 82,
                            DestinationComponent = 5,
                            EdgeCount = 61
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 4,
                    Nodes = new List<int>
                    {
                        8
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 1,
                            EdgeCount = 2
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 2,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 3,
                            EdgeCount = 7
                        },
                        new Edge()
                        {
                            Capacity = 8,
                            DestinationComponent = 5,
                            EdgeCount = 6
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 5,
                    Nodes = new List<int>
                    {
                        13, 19, 20, 23, 24, 30, 33, 48, 51, 53, 62, 67, 68, 72, 80,
                        83, 87, 92, 111, 112, 113, 116
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 29,
                            DestinationComponent = 1,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 2,
                            EdgeCount = 48
                        },
                        new Edge()
                        {
                            Capacity = 82,
                            DestinationComponent = 3,
                            EdgeCount = 61
                        },
                        new Edge()
                        {
                            Capacity = 8,
                            DestinationComponent = 4,
                            EdgeCount = 6
                        }
                    },
                    ParentComponentID = 2
                }
            };
            #endregion

            #region Cut5
            var cut5 = new CutLevel();
            cut5.ID = 5;
            cut5.Z_Value = 0.0819865F;
            cut5.ComponentsAtLevel = new List<int>() { 1, 2, 3, 4, 5, 6 };
            cut5.LHSComponents = new List<Component>
            {
                new Component()
                {
                    ID = 1,
                    Nodes = new List<int>
                    {
                        1, 4, 5, 12, 16, 17, 22, 31, 34, 36, 47, 64,
                        65, 66, 77, 78, 84, 85, 88, 91, 93, 105, 106, 107, 108,
                        114, 115, 120
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 23,
                            DestinationComponent = 2,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 41,
                            DestinationComponent = 3,
                            EdgeCount = 29
                        },
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 4,
                            EdgeCount = 2
                        },
                        new Edge()
                        {
                            Capacity = 29,
                            DestinationComponent = 5,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 28,
                            DestinationComponent = 6,
                            EdgeCount = 22
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 5,
                    Nodes = new List<int>
                    {
                        13, 19, 20, 23, 24, 30, 33, 48, 51, 53, 62, 67, 68, 72, 80,
                        83, 87, 92, 111, 112, 113, 116
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 29,
                            DestinationComponent = 1,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 2,
                            EdgeCount = 48
                        },
                        new Edge()
                        {
                            Capacity = 72,
                            DestinationComponent = 3,
                            EdgeCount = 52
                        },
                        new Edge()
                        {
                            Capacity = 8,
                            DestinationComponent = 4,
                            EdgeCount = 6
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 6,
                            EdgeCount = 9
                        }
                    },
                    ParentComponentID = 2
                }
            };
            cut5.RHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 2,
                    Nodes = new List<int>
                    {
                        2, 10, 14, 15, 18, 26, 37, 38, 39, 43, 54, 55, 56, 58, 70,
                        71, 73, 74, 79, 81, 94, 99, 118, 119
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 23,
                            DestinationComponent = 1,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 22,
                            DestinationComponent = 3,
                            EdgeCount = 20
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 4,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 48,
                            DestinationComponent = 5,
                            EdgeCount = 69
                        },
                        new Edge()
                        {
                            Capacity = 17,
                            DestinationComponent = 6,
                            EdgeCount = 12
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 3,
                    Nodes = new List<int>
                    {
                        3, 6, 7, 9, 25, 27, 28, 29, 32, 35, 44, 45, 46, 49, 50,
                        52, 57, 59, 60, 69, 82, 86, 89, 90, 95, 100, 101, 102, 103, 104,
                        109, 110, 117
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 41,
                            DestinationComponent = 1,
                            EdgeCount = 29
                        },
                        new Edge()
                        {
                            Capacity = 22,
                            DestinationComponent = 2,
                            EdgeCount = 20
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 4,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 72,
                            DestinationComponent = 5,
                            EdgeCount = 52
                        },
                        new Edge()
                        {
                            Capacity = 46,
                            DestinationComponent = 6,
                            EdgeCount = 36
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 4,
                    Nodes = new List<int>
                    {
                        8
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 1,
                            EdgeCount = 2
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 2,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 3,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 8,
                            DestinationComponent = 5,
                            EdgeCount = 6
                        },
                        new Edge()
                        {
                            Capacity = 4,
                            DestinationComponent = 6,
                            EdgeCount = 3
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 6,
                    Nodes = new List<int>
                    {
                        11, 21, 40, 41, 42, 61, 63, 75, 76, 96, 97, 98
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 28,
                            DestinationComponent = 1,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 17,
                            DestinationComponent = 2,
                            EdgeCount = 12
                        },
                        new Edge()
                        {
                            Capacity = 46,
                            DestinationComponent = 3,
                            EdgeCount = 36
                        },
                        new Edge()
                        {
                            Capacity = 4,
                            DestinationComponent = 4,
                            EdgeCount = 3
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 5,
                            EdgeCount = 9
                        }
                    },
                    ParentComponentID = 3
                }
            };
            #endregion

            #region Cut6
            var cut6 = new CutLevel();
            cut6.ID = 6;
            cut6.Z_Value = 0.0845328F;
            cut6.ComponentsAtLevel = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            cut6.LHSComponents = new List<Component>
            {
                new Component()
                {
                    ID = 1,
                    Nodes = new List<int>
                    {
                        1, 4, 5, 12, 16, 17, 22, 31, 34, 36, 47, 64,
                        65, 66, 77, 78, 84, 85, 88, 91, 93, 105, 106, 107, 108,
                        114, 115, 120
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 23,
                            DestinationComponent = 2,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 41,
                            DestinationComponent = 3,
                            EdgeCount = 29
                        },
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 4,
                            EdgeCount = 2
                        },
                        new Edge()
                        {
                            Capacity = 29,
                            DestinationComponent = 5,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 28,
                            DestinationComponent = 6,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 7,
                            EdgeCount = 0
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 3,
                    Nodes = new List<int>
                    {
                        3, 6, 7, 9, 25, 27, 28, 29, 32, 35, 44, 45, 46, 49, 50,
                        52, 57, 59, 60, 69, 82, 86, 89, 90, 95, 100, 101, 102, 103, 104,
                        109, 110
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 41,
                            DestinationComponent = 1,
                            EdgeCount = 29
                        },
                        new Edge()
                        {
                            Capacity = 20,
                            DestinationComponent = 2,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 4,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 72,
                            DestinationComponent = 5,
                            EdgeCount = 52
                        },
                        new Edge()
                        {
                            Capacity = 46,
                            DestinationComponent = 6,
                            EdgeCount = 36
                        },
                        new Edge()
                        {
                            Capacity = 7,
                            DestinationComponent = 7,
                            EdgeCount = 7
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 4,
                    Nodes = new List<int>
                    {
                        8
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 5,
                            DestinationComponent = 1,
                            EdgeCount = 2
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 2,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 3,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 8,
                            DestinationComponent = 5,
                            EdgeCount = 6
                        },
                        new Edge()
                        {
                            Capacity = 4,
                            DestinationComponent = 6,
                            EdgeCount = 3
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 7,
                            EdgeCount = 0
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 5,
                    Nodes = new List<int>
                    {
                        13, 19, 20, 23, 24, 30, 33, 48, 51, 53, 62, 67, 68, 72, 80,
                        83, 87, 92, 111, 112, 113, 116
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 29,
                            DestinationComponent = 1,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 69,
                            DestinationComponent = 2,
                            EdgeCount = 48
                        },
                        new Edge()
                        {
                            Capacity = 72,
                            DestinationComponent = 3,
                            EdgeCount = 52
                        },
                        new Edge()
                        {
                            Capacity = 8,
                            DestinationComponent = 4,
                            EdgeCount = 6
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 6,
                            EdgeCount = 9
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 7,
                            EdgeCount = 0
                        }
                    },
                    ParentComponentID = 2
                },
                new Component()
                {
                    ID = 6,
                    Nodes = new List<int>
                    {
                        11, 21, 40, 41, 42, 61, 63, 75, 76, 96, 97, 98
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 28,
                            DestinationComponent = 1,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 17,
                            DestinationComponent = 2,
                            EdgeCount = 12
                        },
                        new Edge()
                        {
                            Capacity = 46,
                            DestinationComponent = 3,
                            EdgeCount = 36
                        },
                        new Edge()
                        {
                            Capacity = 4,
                            DestinationComponent = 4,
                            EdgeCount = 3
                        },
                        new Edge()
                        {
                            Capacity = 10,
                            DestinationComponent = 5,
                            EdgeCount = 9
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 7,
                            EdgeCount = 0
                        }
                    },
                    ParentComponentID = 3
                }
            };

            cut6.RHSComponents = new List<Component>()
            {
                new Component()
                {
                    ID = 2,
                    Nodes = new List<int>
                    {
                        2, 10, 14, 15, 18, 26, 37, 38, 39, 43, 54, 55, 56, 58, 70,
                        71, 73, 74, 79, 81, 94, 99, 118, 119
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 23,
                            DestinationComponent = 1,
                            EdgeCount = 22
                        },
                        new Edge()
                        {
                            Capacity = 20,
                            DestinationComponent = 3,
                            EdgeCount = 18
                        },
                        new Edge()
                        {
                            Capacity = 6,
                            DestinationComponent = 4,
                            EdgeCount = 4
                        },
                        new Edge()
                        {
                            Capacity = 48,
                            DestinationComponent = 5,
                            EdgeCount = 69
                        },
                        new Edge()
                        {
                            Capacity = 17,
                            DestinationComponent = 6,
                            EdgeCount = 12
                        },
                        new Edge()
                        {
                            Capacity = 2,
                            DestinationComponent = 7,
                            EdgeCount = 2
                        }
                    },
                    ParentComponentID = 1
                },
                new Component()
                {
                    ID = 7,
                    Nodes = new List<int>
                    {
                        117
                    },
                    Edges = new List<Edge>
                    {
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 1,
                            EdgeCount = 0
                        },
                        new Edge()
                        {
                            Capacity = 2,
                            DestinationComponent = 2,
                            EdgeCount = 2
                        },
                        new Edge()
                        {
                            Capacity = 7,
                            DestinationComponent = 3,
                            EdgeCount = 7
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 4,
                            EdgeCount = 0
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 5,
                            EdgeCount = 0
                        },
                        new Edge()
                        {
                            Capacity = 0,
                            DestinationComponent = 6,
                            EdgeCount = 0
                        }
                    },
                    ParentComponentID = 3
                }
            };
            #endregion

            Cuts.Add(cut1);
            Cuts.Add(cut2);
            Cuts.Add(cut3);
            Cuts.Add(cut4);
            Cuts.Add(cut5);
            Cuts.Add(cut6);
        }

        public static void FindZValue(Component source, Component destination, int cutLevel)
        {
            var sameSideOfCut = false;
            CutLevel cut = null;

            if (cutLevel == 0)
                cut = Cuts[cutLevel];
            else
                cut = Cuts[cutLevel - 1];

            var sourceIsInLHS = cut.LHSComponents.Exists(c => c.ID == source.ID);
            var sourceIsInRHS = cut.RHSComponents.Exists(c => c.ID == source.ID);

            var destinationIsInLHS = cut.LHSComponents.Exists(c => c.ID == destination.ID);
            var destinationIsInRHS = cut.RHSComponents.Exists(c => c.ID == destination.ID);

            var sourceExistsAtThisLevel = sourceIsInLHS || sourceIsInRHS;
            var destinationExistsAtThisLevel = destinationIsInLHS || destinationIsInRHS;

            if (sourceExistsAtThisLevel && destinationExistsAtThisLevel)
            {
                if ((sourceIsInLHS && destinationIsInLHS) || (sourceIsInRHS && destinationIsInRHS))
                    sameSideOfCut = true;

                if (!sameSideOfCut)
                    Possible_Z_Values.Add(cut.Z_Value);

                if (cutLevel == 1)
                    return;

                //if (!(source.ParentComponentID == destination.ParentComponentID || source.ParentComponentID == destination.ID || source.ID == destination.ParentComponentID))
                    FindZValue(source, destination, cutLevel - 1);

                if ((source.ParentComponentID == destination.ParentComponentID))
                {
                    if (source.ID < destination.ID)
                        FindZValue(source, FindParent(cut, destination), cutLevel - 1);
                    else
                        FindZValue(destination, FindParent(cut, source), cutLevel - 1);
                }
            }
            else if (sourceExistsAtThisLevel)
            {
                var destinationParent = cut.LHSComponents.Find(c => c.ID == destination.ParentComponentID);
                if (destinationParent == null)
                    destinationParent = cut.RHSComponents.Find(c => c.ID == destination.ParentComponentID);

                FindZValue(source, destinationParent, cutLevel);
            }
            else if (destinationExistsAtThisLevel)
            {
                var sourceParent = cut.LHSComponents.Find(c => c.ID == source.ParentComponentID);
                if (sourceParent == null)
                    sourceParent = cut.RHSComponents.Find(c => c.ID == source.ParentComponentID);

                FindZValue(sourceParent, destination, cutLevel);
            }
            else
            {
                var sourceParent = sourceIsInLHS ? cut.LHSComponents.Find(c => c.ID == source.ParentComponentID) : cut.RHSComponents.Find(c => c.ID == source.ParentComponentID);
                var destinationParent = destinationIsInLHS ? cut.LHSComponents.Find(c => c.ID == destination.ParentComponentID) : cut.RHSComponents.Find(c => c.ID == destination.ParentComponentID);
                FindZValue(sourceParent, destinationParent, cutLevel);
            }
        }

        private static Component FindParent(CutLevel cut, Component child)
        {
            var parent = cut.LHSComponents.Find(c => c.ID == child.ParentComponentID);
            if (parent == null)
                parent = cut.RHSComponents.Find(c => c.ID == child.ParentComponentID);

            return parent;
        }

        public static void CalculateCentrality(CutLevel cut)
        {
            var allComponents = new List<Component>();
            allComponents.AddRange(cut.LHSComponents);
            allComponents.AddRange(cut.RHSComponents);
            foreach (var sourceComponent in allComponents)
            {
                var totalFlow = 0F;
                var totalCapacity = 0;

                foreach (var edge in sourceComponent.Edges)
                {
                    var destinationComponent = allComponents.Find(c => c.ID == edge.DestinationComponent);
                    Possible_Z_Values = new List<float>();
                    FindZValue(sourceComponent, destinationComponent, cut.ID);
                    var flow = Possible_Z_Values.Min() * destinationComponent.Nodes.Count * sourceComponent.Nodes.Count;
                    totalFlow += flow;
                    totalCapacity += edge.Capacity;
                }

                sourceComponent.Centrality = (totalCapacity - totalFlow) / totalCapacity;
                if (sourceComponent.Centrality < 1e-6)
                    sourceComponent.Centrality = 0;
                if (sourceComponent.Centrality > 0.999999)
                    sourceComponent.Centrality = 1;
            }
        }
    }

    public class Component
    {
        public int ID { get; set; }
        public List<int> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
        public float Centrality { get; set; }
        public int ParentComponentID { get; set; }
    }

    public class Edge
    {
        public int DestinationComponent { get; set; }
        public int Capacity { get; set; }
        public int EdgeCount { get; set; }
    }

    public class CutLevel
    {
        public float Z_Value { get; set; }
        public List<int> ComponentsAtLevel { get; set; }
        public List<Component> LHSComponents { get; set; }
        public List<Component> RHSComponents { get; set; }
        public int ID { get; set; }
    }
}
