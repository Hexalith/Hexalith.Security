// <copyright file="PartitionService.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.UI.Components.Partitions;

using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Service for managing users.
/// </summary>
public class PartitionService : IPartitionViewModelService
{
    /// <summary>
    /// Gets all users asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of user summary view models.</returns>
    public Task<IEnumerable<PartitionSummaryViewModel>> GetAllAsync(CancellationToken cancellationToken)
        => Task.FromResult<IEnumerable<PartitionSummaryViewModel>>([
            new PartitionSummaryViewModel("1", "Partition 1"),
            new PartitionSummaryViewModel("2", "Partition 2"),
            new PartitionSummaryViewModel("3", "Partition 3")
        ]);
}