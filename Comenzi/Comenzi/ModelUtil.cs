using System;

namespace Comenzi
{
    public static class ModelUtil
    {
        /// <summary>
        /// Obtine o valoare int din store.
        /// </summary>
        public static int GetAsInt(SettingsStore store, string key, int defaultValue)
        {
            object value = store.Get(key);
            return value == null ? defaultValue : Convert.ToInt32(value);
        }

        /// <summary>
        /// Obtine o valoare bool din store.
        /// </summary>
        public static bool GetAsBool(SettingsStore store, string key, bool defaultValue)
        {
            object value = store.Get(key);
            return value == null ? defaultValue : Convert.ToBoolean(value);
        }

        /// <summary>
        /// Obtine o valoare string din store.
        /// </summary>
        public static string GetAsString(SettingsStore store, string key, string defaultValue)
        {
            object value = store.Get(key);
            return value == null ? defaultValue : value.ToString();
        }
    }
}
