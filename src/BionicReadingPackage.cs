﻿global using System;
global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;

namespace BionicReading
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.BionicReadingString)]
    [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), Vsix.Name, "General", 0, 0, true, SupportsProfiles = true)]
    public sealed class BionicReadingPackage : ToolkitPackage
    {
        //protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        //{
        //    await this.RegisterCommandsAsync();
        //}
    }
}