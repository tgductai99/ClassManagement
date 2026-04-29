using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TaskQLLH.Localization
{
    public static class TaskQLLHLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TaskQLLHConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TaskQLLHLocalizationConfigurer).GetAssembly(),
                        "TaskQLLH.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
