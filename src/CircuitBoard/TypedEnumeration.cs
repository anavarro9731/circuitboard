using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CircuitBoard
{
    //* the typed version is here to facilitate static constraints and intellisense
    public class TypedEnumeration<T> : Enumeration where T : Enumeration, new()
    {
        public static T Create(string key, string value)
        {
            var t = new T
            {
                Value = value, Key = key
            };

            return t;
        }

        public static IEnumerable<T> GetAllInstances()
        {
            var type = typeof(T);
            
            var fields = type.GetRuntimeFields().Where(x => x.IsPublic && x.IsStatic && x.DeclaringType == type);
            
            //var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var fieldInfo in fields)
            {
                var instance = new T();
                var locatedValue = fieldInfo.GetValue(instance) as T;

                if (locatedValue != null) yield return locatedValue;
            }
        }

        public static T GetInstanceFromKey(string key) => ToTypedInstance<T>(key);
    }
}
