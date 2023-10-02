using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Graphs.Abstract;

namespace DataStructures.Graphs
{
    public class Edge<T, TW> : IEdge<T>
    {
        private object weight;
        public Edge(IGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }
        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public W Weight<W>() where W : IComparable => (W)weight;
        
        public override string ToString() => TargetVertexKey.ToString();
    }
}