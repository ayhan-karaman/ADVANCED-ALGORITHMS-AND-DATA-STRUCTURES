using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Graphs.Abstract;
using DataStructures.Heaps;

namespace DataStructures.Graphs.MinimumSpanningTree
{
    public class Prims<T, TW>
    where TW : IComparable
    where T : IComparable
    {
        public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            var edges = new List<MSTEdge<T, TW>>();
            Dfs(graph, graph.ReferenceVertex, new BinaryHeap<MSTEdge<T, TW>>(Shared.SortDirection.Ascending), new HashSet<T>(), edges);
            return edges;
        }

        private void Dfs(IGraph<T> graph, IGraphVertex<T> currentVertex, BinaryHeap<MSTEdge<T, TW>> spNeighours, HashSet<T> spVertices, List<MSTEdge<T, TW>> spEdges)
        {
            while (true)
            {
                // kenarlara dikkat
                foreach (var edge in currentVertex.Edges)
                {
                    spNeighours.Add(
                        new MSTEdge<T, TW>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<TW>())
                    );
                }

                // min-edge
                var minEdge = spNeighours.DeleteMinMax(); 

                // val olan kenarları dikkate alma
                while (spVertices.Contains(minEdge.Source) && spVertices.Contains(minEdge.Destination))
                {
                    minEdge = spNeighours.DeleteMinMax();
                    if(spNeighours.Count == 0)
                        return;
                }

                // vertex takibi
                if(!spVertices.Contains(minEdge.Source))
                {
                    spVertices.Add(minEdge.Source);
                }
                spVertices.Add(minEdge.Destination);
                spEdges.Add(minEdge);
                
                currentVertex = graph.GetVertex(minEdge.Destination);

            }
        }
    }
}