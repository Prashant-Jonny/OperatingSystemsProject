
namespace GraphAssignment1
{
    public interface IGraph
    {
        int NumberOfNodes { get; }
        float EdgeProbability { get; }
        int[,] Graph { get; set; }
        void Print();
    }
}
