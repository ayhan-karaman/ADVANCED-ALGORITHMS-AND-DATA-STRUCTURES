using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Graphs.Abstract;

namespace DataStructures.Graphs.Search
{
    public class DepthFirst<T>
    {
        public HashSet<T> DfsTree { get; private set; }
        public DepthFirst()
        {
            DfsTree = new HashSet<T>();
        }
        public bool Find(IGraph<T> graph, T vertexKey)
        {
            return Dfs(graph.ReferenceVertex, new HashSet<T>(), vertexKey);
        }
        private bool Dfs(IGraphVertex<T> current, HashSet<T> visited, T searchVertexKey)
        {
            visited.Add(current.Key);
            DfsTree.Add(current.Key);
            if(current.Key.Equals(searchVertexKey))
                 return true;
            foreach (var edge in current.Edges)
            {
                if(visited.Contains(edge.TargetVertexKey))
                    continue;
                if(Dfs(edge.TargetVertex, visited, searchVertexKey))
                    return true;
            }
            return false;
        }
    }
}