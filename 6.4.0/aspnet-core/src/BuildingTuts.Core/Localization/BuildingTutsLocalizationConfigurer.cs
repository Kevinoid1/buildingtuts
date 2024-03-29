﻿using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BuildingTuts.Localization
{
    public static class BuildingTutsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BuildingTutsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BuildingTutsLocalizationConfigurer).GetAssembly(),
                        "BuildingTuts.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
