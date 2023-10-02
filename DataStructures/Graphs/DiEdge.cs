using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStructures.Graphs.Abstract;

namespace DataStructures.Graphs
{
    public class DiEdge<T, TW> : IDiEdge<T>
    {
        private object weight;
        public IDiGraphVertex<T> TargetVertex { get; private set;}

        public DiEdge(IDiGraphVertex<T> target, TW weight)
        {
            TargetVertex = target;
            this.weight = weight;
        }

        public T TargetVertexKey => TargetVertex.Key;

        IGraphVertex<T> IEdge<T>.TargetVertex => TargetVertex as IGraphVertex<T>;

        public W Weight<W>() where W : IComparable
        {
             return (W)weight;
        }
        public override string ToString() => $"{TargetVertexKey}";
    }
}