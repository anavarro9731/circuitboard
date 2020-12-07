using System.Linq;

namespace CircuitBoard
{
    public class TypedEnumerationAndFlags<T> : EnumerationAndFlags where T : Enumeration, new()
    {
        public TypedEnumerationAndFlags(T initialState = null, bool populateAllEnumerations = false, bool allowMultipleSelections = true) :
            base(initialState,
                populateAllEnumerations ? TypedEnumeration<T>.GetAllInstances().Cast<Enumeration>().ToList() : null,
                allowMultipleSelections)
        {
        }
    }
}
