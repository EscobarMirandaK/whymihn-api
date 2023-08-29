using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;

namespace API.Extensions
{
    public static class ConvertExtension
    {
        public static T ToObject<T>(this DataRow dataRow) where T : new()
        {
            T item = new();

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = GetProperty(typeof(T), column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value && dataRow[column].ToString() != "NULL")
                {
                    property.SetValue(item, ChangeType(dataRow[column].ToString().Trim(), property.PropertyType), null);
                }
            }

            return item;
        }

        private static PropertyInfo GetProperty(Type type, string attributeName)
        {
            PropertyInfo property = type.GetProperty(attributeName);

            if (property != null)
            {
                return property;
            }

            return type.GetProperties()
                 .Where(p => p.IsDefined(typeof(ColumnAttribute), false) && p.GetCustomAttributes(typeof(ColumnAttribute), false).Cast<ColumnAttribute>().Single().Name == attributeName)
                 .FirstOrDefault();
        }

        public static object ChangeType(object value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                return Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }

            return Convert.ChangeType(value, type);
        }
    }
}
