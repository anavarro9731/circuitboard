using System;

namespace CircuitBoard.Permissions
{
    public interface IApplicationPermission : IHaveScope
    {
        int DisplayOrder { get; set; }

        Guid Id { get; set; }

        string PermissionName { get; set; }

        Guid PermissionRequiredToAdministerThisPermission { get; set; }
    }
}