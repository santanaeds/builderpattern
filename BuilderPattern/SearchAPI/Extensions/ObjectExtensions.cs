using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace SearchAPI.Extensions
{
    public static class ObjectExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj is IDictionary<string, object> objects)
            {
                return objects;
            }

            if (obj is IDictionary<string, string> data)
            {
                var result = new Dictionary<string, object>();

                foreach (var key in data.Keys)
                {
                    result.Add(key, data[key]);
                }

                return result;
            }

            if (obj is JObject o)
            {
                var deserialized = JsonConvert.DeserializeObject<Dictionary<string, object>>(o.ToString());
                return deserialized;
            }

            if (obj is string stringVal)
            {
                return new Dictionary<string, object> { { "Value", stringVal } };
            }

            var result2 = new Dictionary<string, object>();
            var members = obj.GetType().GetMembers();

            var filteredMembers = members.Where(info => info.MemberType == MemberTypes.Method && info.Name.StartsWith("get_"));
            foreach (var member in filteredMembers)
            {
                var field = member as MethodInfo;
                var name = field?.Name.Replace("get_", "");
                var value = field?.Invoke(obj, null);

                if (name == null) continue;

                result2.Add(name, value);
            }

            return result2;
        }

        public static string Description(this Enum tEnum)
        {
            var fieldInfo = tEnum.GetType().GetField(tEnum.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : tEnum.ToString();
        }

        public static bool IsTimeValid(this string time)
        {
            if (string.IsNullOrWhiteSpace(time)) return true;
            return DateTime.TryParseExact(time, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt);
        }

        public static string ToLowerString(this bool _bool) => _bool.ToString().ToLower();

        public static string TrimLastCharacter(this string str)
        {
            return string.IsNullOrEmpty(str) ? str : str.TrimEnd(str[str.Length - 1]);
        }
    }
}
