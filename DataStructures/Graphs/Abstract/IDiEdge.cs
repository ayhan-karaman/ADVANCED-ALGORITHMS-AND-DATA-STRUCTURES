using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Abstract
{
    public interface IDiEdge<T> : IEdge<T>
    {
        new  IDiGraphVertex<T> TargetVertex { get; }
    }
}