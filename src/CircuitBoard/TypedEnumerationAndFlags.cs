using System.Linq;

namespace CircuitBoard
{
    public class TypedEnumerationAndFlags<T> : EnumerationAndFlags where T : Enumeration, new()
    {
        public TypedEnumerationAndFlags(T initialState) : base(initialState)
        {
            AllEnumerations =  TypedEnumeration<T>.GetAllInstances().Cast<Enumeration>().ToList();
        }
        
        public TypedEnumerationAndFlags(bool populateAllEnumerations = false)
        {
            if (populateAllEnumerations) AllEnumerations =  TypedEnumeration<T>.GetAllInstances().Cast<Enumeration>().ToList();
        }

        public TypedEnumerationAndFlags()
        {
            
        }
    }
}
