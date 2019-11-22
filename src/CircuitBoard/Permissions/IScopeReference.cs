using System;

namespace CircuitBoard.Permissions
{
    public interface IScopeReference
    {
        Guid ScopeObjectId { get; }

        string ScopeObjectType { get; }

        DateTime ScopeReferenceCreatedOn { get; }
    }
}