using System.Collections.Generic;

namespace CircuitBoard.Permissions
{
    public interface IHaveScope
    {
        List<ScopeReference> ScopeReferences { get; set; }
    }
}