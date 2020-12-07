using System.Collections.Generic;

namespace CircuitBoard
{
    public class EnumerationAndFlags : EnumerationFlags
    {
        public EnumerationAndFlags(Enumeration initialState = null, List<Enumeration> allEnumerations = null,
            bool allowMultipleSelections = true) :
            base(initialState, allowMultipleSelections)
        {
            AllEnumerations = allEnumerations;
        }

        public List<Enumeration> AllEnumerations { get; set; }
    }
}
