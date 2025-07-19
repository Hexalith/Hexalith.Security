// <copyright file="SecurityMenu.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Hexalith.Security.Application.Menu;

using Hexalith.UI.Components;
using Hexalith.UI.Components.Icons;

using Labels = Resources.Modules.SecurityMenu;

/// <summary>
/// Represents the Manhole menu.
/// </summary>
public static class SecurityMenu
{
    /// <summary>
    /// Gets the menu information.
    /// </summary>
    public static MenuItemInformation Menu => new(
                    Labels.SecurityMenuItem,
                    string.Empty,
                    new IconInformation("Shield", 20, IconStyle.Regular),
                    true,
                    0,
                    null,
                    [
                        new MenuItemInformation(
                            Labels.LoginMenuItem,
                            "Account/Login",
                            new IconInformation("ShieldCheckmark", 20, IconStyle.Regular),
                            false,
                            100,
                            null,
                            []),
                        new MenuItemInformation(
                            Labels.LogoutMenuItem,
                            "Logout",
                            new IconInformation("ShieldDismiss", 20, IconStyle.Regular),
                            false,
                            90,
                            null,
                            []),
                        new MenuItemInformation(
                            Labels.RegisterUserMenuItem,
                            "Account/Register",
                            new IconInformation("ShieldAdd", 20, IconStyle.Regular),
                            false,
                            80,
                            null,
                            []),
                        new MenuItemInformation(
                            Labels.ManageAccountMenuItem,
                            "Account/Manage",
                            new IconInformation("BuildingRetailShield", 20, IconStyle.Regular),
                            false,
                            70,
                            null,
                            []),
                        new MenuItemInformation(
                            Labels.ClaimsMenuItem,
                            "/Security/Claim",
                            new IconInformation("ShieldKeyhole", 20, IconStyle.Regular),
                            false,
                            60,
                            null,
                            []),
                        new MenuItemInformation(
                            Labels.UsersMenuItem,
                            "/Security/User",
                            new IconInformation("PersonKey", 20, IconStyle.Regular),
                            false,
                            50,
                            SecurityPolicies.Readers,
                            []),
                        new MenuItemInformation(
                            Labels.RolesMenuItem,
                            "/Security/Role",
                            new IconInformation("PanelLeftHeaderKey", 20, IconStyle.Regular),
                            false,
                            40,
                            SecurityPolicies.Readers,
                            []),
                    ]);
}