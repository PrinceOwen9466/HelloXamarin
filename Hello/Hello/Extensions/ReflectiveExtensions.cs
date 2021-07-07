using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Hello.Extensions
{
    public static class ReflectiveExtensions
    {
        public static IEnumerable<(MemberInfo source, TValue value)> GetValuesAtRuntime<TFrom, TValue>()
        {
            var fields = typeof(TFrom).GetRuntimeFields();
            var props = typeof(TFrom).GetRuntimeProperties();

            Func<MemberInfo, bool> isAcceptable = (info) =>
            {
                if (info.GetCustomAttribute<ObsoleteAttribute>() != null)
                    return false;

                if (info is PropertyInfo prop)
                {
                    var getInfo = prop.GetMethod;
                    if (getInfo.IsPublic && getInfo.IsStatic && getInfo.ReturnType == typeof(TValue))
                        return true;
                }
                else if (info is FieldInfo field)
                {
                    if (field.IsPublic && field.IsStatic && field.FieldType == typeof(TValue))
                        return true;
                }

                return false;
            };

            foreach (var field in fields)
            {
                if (!isAcceptable(field)) continue;
                yield return (field, (TValue)field.GetValue(null));
            }

            foreach (var prop in props)
            {
                if (!isAcceptable(prop)) continue;
                yield return (prop, (TValue)prop.GetValue(null));
            }
        }
    }
}
