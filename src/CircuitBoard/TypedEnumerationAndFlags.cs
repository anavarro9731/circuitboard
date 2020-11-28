using System.Linq;

namespace CircuitBoard
{
    public class TypedEnumerationAndFlags<T> : EnumerationAndFlags where T : Enumeration, new()
    {
        public TypedEnumerationAndFlags(T initialState) : base(initialState)
        {
            AllEnumerations =  TypedEnumeration<T>.GetAllInstances().Cast<Enumeration>().ToList();
        }

        public TypedEnumerationAndFlags()
        {
        }
    }
}