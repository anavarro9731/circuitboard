using System.Linq;

namespace CircuitBoard
{
    public class TypedEnumerationAndFlags<T> : EnumerationAndFlags where T : Enumeration, new()
    {
        public TypedEnumerationAndFlags(T initialState = null, bool populateAllEnumerations = false) :
            base(initialState,
                populateAllEnumerations ? TypedEnumeration<T>.GetAllInstances().Cast<Enumeration>().ToList() : null)
        {
            AllowMultipleSelections = false;
        }

        public TypedEnumerationAndFlags()
        {
        }
    }
}
