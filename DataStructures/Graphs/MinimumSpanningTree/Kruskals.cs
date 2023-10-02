using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Graphs.Abstract;
using DataStructures.Sets;

namespace DataStructures.Graphs.MinimumSpanningTree
{
    public class Kruskals<T, TW>
    where T : IComparable
    where TW : IComparable
    {
        public List<MSTEdge<T, TW>> FindMinimumSpanningTree(IGraph<T> graph)
        {
            // 1. Kenar listesi (dfs)
            var edges = new List<MSTEdge<T, TW>>();
            Dfs(graph.ReferenceVertex, new HashSet<T>(), new Dictionary<T, HashSet<T>>(), edges);

            // 2. Kenar sıralaması
            var heap = new Heaps.BinaryHeap<MSTEdge<T,TW>>(Shared.SortDirection.Ascending);
            foreach (var edge in edges)
                heap.Add(edge);

                
            var sortedEdgearr = new MSTEdge<T, TW>[edges.Count];
            for (int i = 0; i < edges.Count; i++)
                sortedEdgearr[i] = heap.DeleteMinMax();

            // 3. MakeSet - FindSet - Union
            var disJointSet = new DisJointSet<T>();
            foreach (var vertex in graph.VericesAsEnumerable)
            {
                disJointSet.MakeSet(vertex.Key);
            }
            var resultEdgeList = new List<MSTEdge<T, TW>>();
            for (int i = 0; i < edges.Count; i++)
            {
               var currentEdge = sortedEdgearr[i];
               var setA = disJointSet.FindSet(currentEdge.Source);
               var setB = disJointSet.FindSet(currentEdge.Destination);
               if(setA.Equals(setB))
                    continue;
               resultEdgeList.Add(currentEdge);
               disJointSet.Union(setA, setB);
            }
 
            return resultEdgeList;
        }

        private void Dfs(IGraphVertex<T> currentVertex, HashSet<T> visitedVertices, Dictionary<T, HashSet<T>> visitedEdges, List<MSTEdge<T, TW>> edges)
        {
            if(!visitedVertices.Contains(currentVertex.Key))
            {
                visitedVertices.Add(currentVertex.Key);
                foreach (var edge in currentVertex.Edges)
                {
                    if(!visitedEdges.ContainsKey(currentVertex.Key) || !visitedEdges[currentVertex.Key].Contains(edge.TargetVertexKey))
                    {
                        // Kenar ekleme
                        edges.Add(new MSTEdge<T, TW>(currentVertex.Key, edge.TargetVertexKey, edge.Weight<TW>()));

                        // Kenar güncelleme(visitedEdges) -- source
                        if(!visitedEdges.ContainsKey(currentVertex.Key))
                        {
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());
                        }
                        visitedEdges[currentVertex.Key].Add(edge.TargetVertexKey);

                        // Kenar güncelleme(visitedEdges) -- destination
                        if(!visitedEdges.ContainsKey(currentVertex.Key))
                        {
                            visitedEdges.Add(currentVertex.Key, new HashSet<T>());
                        }

                        visitedEdges[currentVertex.Key].Add(currentVertex.Key);

                        Dfs(edge.TargetVertex, visitedVertices, visitedEdges, edges);
                    }
                }
            }
        }
    }
}