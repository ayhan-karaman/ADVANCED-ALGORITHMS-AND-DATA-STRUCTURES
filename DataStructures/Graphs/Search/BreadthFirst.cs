using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Graphs.Abstract;

namespace DataStructures.Graphs.Search
{
    public class BreadthFirst<T>
    {
        public HashSet<T> BfsTree { get; private set; }
        public BreadthFirst()
        {
            BfsTree =  new HashSet<T>();   
        }
        public bool Find(IGraph<T> graph, T vertexKey)
        {
            return Bfs(graph.ReferenceVertex, new HashSet<T>(), vertexKey);
        }

        private bool Bfs(IGraphVertex<T> referenceVertex, HashSet<T> visited, T searchVertexKey)
        {
            var queue = new Queues.Queue<IGraphVertex<T>>();
            queue.Enqueue(referenceVertex);
            visited.Add(referenceVertex.Key);
            
      
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                BfsTree.Add(current.Key);
                
                if(current.Key.Equals(searchVertexKey))
                    return true;
                foreach (var edge in current.Edges)
                {
                    if(visited.Contains(edge.TargetVertexKey))
                        continue;
                    visited.Add(edge.TargetVertexKey);
                    queue.Enqueue(edge.TargetVertex);
                }
            }
            return false;
        }
    }
}