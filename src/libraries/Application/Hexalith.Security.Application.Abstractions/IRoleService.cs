// <copyright file="IRoleService.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Defines the contract for role-related operations.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Creates a new role asynchronously.
    /// </summary>
    /// <param name="roleName">The name of the role to create.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created role summary.</returns>
    Task<RoleSummaryViewModel> CreateAsync(string roleName, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a role asynchronously.
    /// </summary>
    /// <param name="roleId">The ID of the role to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(string roleId, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all roles asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of role summaries.</returns>
    Task<IEnumerable<RoleSummaryViewModel>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a role by ID asynchronously.
    /// </summary>
    /// <param name="roleId">The ID of the role to get.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the role summary.</returns>
    Task<RoleSummaryViewModel?> GetByIdAsync(string roleId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates a role asynchronously.
    /// </summary>
    /// <param name="roleId">The ID of the role to update.</param>
    /// <param name="roleName">The new name for the role.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated role summary.</returns>
    Task<RoleSummaryViewModel> UpdateAsync(string roleId, string roleName, CancellationToken cancellationToken);
}