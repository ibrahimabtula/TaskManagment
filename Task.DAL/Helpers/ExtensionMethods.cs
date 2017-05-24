using System;
using System.Data;

namespace Task.DAL
{
    internal static class ExtensionMethods
    {
        public static DateTime? GetNullabelDateTime(this IDataReader reader, int ordinal)
        {
            if (reader.IsDBNull(ordinal))
                return null;
            return reader.GetDateTime(ordinal);
        }
    }
}
