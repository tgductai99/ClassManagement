using TaskQLLH.Debugging;

namespace TaskQLLH
{
    public class TaskQLLHConsts
    {
        public const string LocalizationSourceName = "TaskQLLH";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "5180786e544e4573a665bbf79754708d";
    }
}
