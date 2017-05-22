using System;

namespace Frameworx
{

    /// <summary>
    /// Generic helper functions
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// Converts Integers to enum types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Enum int value</param>
        /// <returns></returns>
        /// <example>
        /// Enums.ConvertToEnum<enum.type>([EnumAsInt]);
        /// </example>
        public static T ConvertToEnum<T>(int value)
        {
            return (T)Enum.ToObject(typeof(T), value);
        }


        /// <summary>
        /// Converts String to enum types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">Enum string value</param>
        /// <returns></returns>
        /// <example>
        /// Enums.ConvertToEnum<enum.type>([EnumAsString]);
        /// </example>
        public static T ConvertToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}