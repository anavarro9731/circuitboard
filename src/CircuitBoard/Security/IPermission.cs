using System;

namespace CircuitBoard.Security
{
    public interface IPermission
    {
        int DisplayOrder { get; set; }

        Guid Id { get; set; }

        string PermissionName { get; set; }

        Guid PermissionRequiredToAdministerThisPermission { get; set; }
    }
}