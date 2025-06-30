﻿// <copyright file="IUserService.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

/*
 * <Your-Product-Name>
 * Copyright (c) <Year-From>-<Year-To> <Your-Company-Name>
 *
 * Please configure this header in your SonarCloud/SonarQube quality profile.
 * You can also set it in SonarLint.xml additional file for SonarLint or standalone NuGet analyzer.
 */

namespace Hexalith.Security.Application.Users;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Defines the contract for user-related operations.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Adds the global administrator role to a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to add the role to.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddGlobalAdministratorAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to delete.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Disables a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to disable.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DisableAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Enables a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to enable.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task EnableAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Finds a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to find.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user details if found, otherwise null.</returns>
    Task<UserDetailsViewModel?> FindAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Finds a user summary asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to find the summary for.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user summary if found, otherwise null.</returns>
    Task<UserSummaryViewModel?> FindSummaryAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves all users asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of user summaries.</returns>
    Task<IEnumerable<UserSummaryViewModel>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to get.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user details.</returns>
    Task<UserDetailsViewModel> GetAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets a user summary asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to get the summary for.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the user summary.</returns>
    Task<UserSummaryViewModel> GetSummaryAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Grants the global administrator role to a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to grant the role to.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task GrantGlobalAdministratorRoleAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Removes the global administrator role from a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to remove the role from.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveGlobalAdministratorAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Updates a user asynchronously.
    /// </summary>
    /// <param name="user">The user details to update.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(UserEditViewModel user, CancellationToken cancellationToken);

    /// <summary>
    /// Adds a role to a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to add the role to.</param>
    /// <param name="roleId">The ID of the role to add.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddRoleAsync(string userId, string roleId, CancellationToken cancellationToken);

    /// <summary>
    /// Removes a role from a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to remove the role from.</param>
    /// <param name="roleId">The ID of the role to remove.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task RemoveRoleAsync(string userId, string roleId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all roles for a user asynchronously.
    /// </summary>
    /// <param name="userId">The ID of the user to get roles for.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of role IDs.</returns>
    Task<IEnumerable<string>> GetUserRolesAsync(string userId, CancellationToken cancellationToken);
}