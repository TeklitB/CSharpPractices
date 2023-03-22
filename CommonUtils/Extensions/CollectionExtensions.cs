using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils.Extensions
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Serializing list of objects to csv using reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string GenerateCsv<T>(this ICollection<T> items, string delimiter = ",")
        {
            var properties = typeof(T).GetProperties();
            var header = properties.Select(x => x.Name)
                .Aggregate((a, b) => a + delimiter + b);

            using var sw = new StringWriter();
            sw.WriteLine(header);

            foreach (var item in items)
            {
                var row = properties.Select(x => x.GetValue(item, null))
                    .Select(x => x == null ? "null" : x.ToString())
                    .Aggregate((a, b) => a + delimiter + b);
                sw.WriteLine(row);
            }

            return sw.ToString();
        }

        /// <summary>
        /// Parse the properties of T, simply define what properties 
        /// you want to include in the where linq clause.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static IEnumerable<System.Reflection.PropertyInfo> GetSpecific<T>(this T entity)
        {
            var properties = typeof(T).GetProperties()
                .Where(n => n.PropertyType == typeof(string)
                || n.PropertyType == typeof(bool)
                || n.PropertyType == typeof(char)
                || n.PropertyType == typeof(byte)
                || n.PropertyType == typeof(decimal)
                || n.PropertyType == typeof(int)
                || n.PropertyType == typeof(DateTime)
                || n.PropertyType == typeof(DateTime?));

            return properties;
        }
    }
}
