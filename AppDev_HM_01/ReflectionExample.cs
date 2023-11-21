using System;
using System.Reflection;

namespace AppDev_HM_01
{
    public static class ReflectionExample
    {
        public static void ObjectToString(object obj)
        {
            Type type = obj.GetType();
            foreach (FieldInfo field in type.GetFields())
            {
                var customAttr = field.GetCustomAttribute<CustomNameAttribute>();
                if (customAttr != null)
                {
                    Console.WriteLine($"{customAttr.CustomFieldName}:{field.GetValue(obj)}");
                }
            }
        }

        public static void StringToObject(object obj, string propertyName, string value)
        {
            Type type = obj.GetType();
            foreach (FieldInfo field in type.GetFields())
            {
                var customAttr = field.GetCustomAttribute<CustomNameAttribute>();
                if (customAttr != null && customAttr.CustomFieldName == propertyName)
                {
                    object convertedValue = Convert.ChangeType(value, field.FieldType);
                    field.SetValue(obj, convertedValue);
                    break;
                }
            }
        }
    }
}
