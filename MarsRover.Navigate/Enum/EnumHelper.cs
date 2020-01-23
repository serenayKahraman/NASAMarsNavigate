using System;
using System.ComponentModel;

namespace MarsRover.Navigate.Enum
{
   public static class EnumHelper
    {
        public static T GetValueFromDescription<T>(this string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }
        public static string ToDescription(this System.Enum value)
        {
            if (value == null)
                return null;
            var field = (value.GetType().GetField(value.ToString()));
            if (field == null) return null;
            var da = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }
}
