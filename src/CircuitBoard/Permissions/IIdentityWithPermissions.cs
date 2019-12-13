using System;
using System.Collections.Generic;

namespace CircuitBoard.Permissions
{
    public interface IIdentityWithPermissions
    {
        // ReSharper disable once InconsistentNaming
        Guid id { get; set; } //lowercase to support entities persisted in cosmosdb, grr!

        string UserName { get; set; }

        bool HasPermission(IPermission permission);

        void AddPermission(IPermissionInstance permissionInstance);

        void RemovePermission(IPermissionInstance permissionInstance);

        IList<IPermissionInstance> PermissionInstances { get; }

    }
}