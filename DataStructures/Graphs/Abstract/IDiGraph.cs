using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Abstract
{
    public interface IDiGraph<T> : IGraph<T>
    {
       new IDiGraphVertex<T> ReferenceVertex { get; }
       new IEnumerable<IDiGraphVertex<T>> VericesAsEnumerable { get; }
       new IDiGraphVertex<T> GetVertex(T key);
    }
}