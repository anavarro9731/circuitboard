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

        IList<IPermissionInstance> AsIPermissionInstances();

    }

    public interface IIdentityWithPermissions<T> where T: IPermissionInstance, IIdentityWithPermissions
    {
        // ReSharper disable once InconsistentNaming
        Guid id { get; set; } //lowercase to support entities persisted in cosmosdb, grr!

        List<T> Permissions { get; set; }

        string UserName { get; set; }

        
        bool HasPermission(IPermission permission);
    }
}