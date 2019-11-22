using System.Collections.Generic;

namespace CircuitBoard.Permissions
{
    public interface IHaveScope
    {
        List<IScopeReference> ScopeReferences { get; set; }
    }
}