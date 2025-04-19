// <copyright file="RoleService.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Servers.Roles;

using System.Threading;
using System.Threading.Tasks;

using Hexalith.IdentityStores.Models;
using Hexalith.IdentityStores.Services;
using Hexalith.Security.Application;

using Microsoft.AspNetCore.Identity;

/// <summary>
/// Service for managing roles.
/// </summary>
/// <param name="roleCollectionService">The role collection service.</param>
/// <param name="roleStore">The role store.</param>
public class RoleService(
    IRoleCollectionService roleCollectionService,
    IRoleStore<CustomRole> roleStore) : IRoleService
{
    private readonly IRoleCollectionService _roleCollectionService = roleCollectionService ?? throw new ArgumentNullException(nameof(roleCollectionService));
    private readonly IRoleStore<CustomRole> _roleStore = roleStore ?? throw new ArgumentNullException(nameof(roleStore));

    /// <summary>
    /// Creates a role with the specified name.
    /// </summary>
    /// <param name="roleName">The name of the role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the role summary view model.</returns>
    public async Task<RoleSummaryViewModel> CreateAsync(string roleName, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(roleName);

        var role = new CustomRole { Name = roleName };
        _ = await _roleStore.CreateAsync(role, cancellationToken).ConfigureAwait(false);
        return new RoleSummaryViewModel(role.Id, role.Name);
    }

    /// <summary>
    /// Deletes a role with the specified identifier.
    /// </summary>
    /// <param name="roleId">The role identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the role with the specified identifier is not found.</exception>
    public async Task DeleteAsync(string roleId, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(roleId);

        CustomRole? role = await _roleStore.FindByIdAsync(roleId, cancellationToken).ConfigureAwait(false)
            ?? throw new InvalidOperationException($"Role with ID '{roleId}' not found.");
        _ = await _roleStore.DeleteAsync(role, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Gets all roles asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of role summary view models.</returns>
    public async Task<IEnumerable<RoleSummaryViewModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        IEnumerable<string> ids = await _roleCollectionService.AllAsync().ConfigureAwait(false);
        List<Task<CustomRole?>> roleTasks = [];
        foreach (string id in ids)
        {
            roleTasks.Add(_roleStore.FindByIdAsync(id, cancellationToken));
        }

        return (await Task.WhenAll(roleTasks).ConfigureAwait(false))
                .OfType<CustomRole>()
                .Select(p => new RoleSummaryViewModel(p.Id, p.Name))
                .OrderBy(p => p.Name);
    }

    /// <summary>
    /// Gets a role by its identifier.
    /// </summary>
    /// <param name="roleId">The role identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the role summary view model, or null if the role was not found.</returns>
    public async Task<RoleSummaryViewModel?> GetByIdAsync(string roleId, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(roleId);

        CustomRole? role = await _roleStore.FindByIdAsync(roleId, cancellationToken).ConfigureAwait(false);
        return role == null
            ? null
            : new RoleSummaryViewModel(role.Id, role.Name);
    }

    /// <summary>
    /// Updates a role with the specified identifier and name.
    /// </summary>
    /// <param name="roleId">The role identifier.</param>
    /// <param name="roleName">The new name of the role.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated role summary view model.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the role with the specified identifier is not found.</exception>
    public async Task<RoleSummaryViewModel> UpdateAsync(string roleId, string roleName, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(roleId);
        ArgumentException.ThrowIfNullOrWhiteSpace(roleName);

        CustomRole? role = await _roleStore.FindByIdAsync(roleId, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException($"Role with ID '{roleId}' not found.");
        await _roleStore.SetRoleNameAsync(role, roleName, cancellationToken).ConfigureAwait(false);
        _ = await _roleStore.UpdateAsync(role, cancellationToken).ConfigureAwait(false);

        return new RoleSummaryViewModel(role.Id, role.Name);
    }
}