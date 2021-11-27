﻿using System.Collections.Generic;
using Souvenir;

public class Config
{
    public bool ExcludeVanillaModules;
    public bool ExcludeIgnoredModules;
    public bool ExcludeMysteryModule;
    public bool ExcludeSouvenir;
    public string Language;

    /// <summary>Checks if a modded(!) module is excluded. This function does not check for vanilla modules.</summary>
    public bool IsExcluded(KMBombModule module, HashSet<string> ignoredModules) => module.ModuleType switch
    {
        "mysterymodule" => ExcludeMysteryModule,
        "SouvenirModule" => ExcludeSouvenir,
        _ => ExcludeIgnoredModules && ignoredModules.Contains(module.ModuleDisplayName),
    };

    public static readonly Dictionary<string, object>[] TweaksEditorSettings = Ut.NewArray(
        new Dictionary<string, object>
        {
            ["Filename"] = "Souvenir-settings.txt",
            ["Name"] = "Souvenir",
            ["Listings"] = Ut.NewList(
                new Dictionary<string, object> { ["Key"] = "ExcludeVanillaModules", ["Text"] = "Exclude vanilla modules", ["Description"] = "avoid questions about vanilla modules" },
                new Dictionary<string, object> { ["Key"] = "ExcludeIgnoredModules", ["Text"] = "Exclude ignored modules", ["Description"] = "avoid questions about boss modules (except other Souvenirs)" },
                new Dictionary<string, object> { ["Text"] = "Exclude specific modules", ["Type"] = "Section" },
                new Dictionary<string, object> { ["Key"] = "ExcludeMysteryModule", ["Text"] = "Mystery Module" },
                new Dictionary<string, object> { ["Key"] = "ExcludeSouvenir", ["Text"] = "Souvenir", ["Description"] = "avoid questions about other Souvenirs on the same bomb" })
        }
    );
}
