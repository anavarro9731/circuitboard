using System.Collections.Generic;

namespace CircuitBoard
{
    public class EnumerationAndFlags : EnumerationFlags
    {
        public EnumerationAndFlags(Enumeration initialState, List<Enumeration> allEnumerations = null) :
            base(initialState)
        {
            AllEnumerations = allEnumerations;
        }

        public EnumerationAndFlags()
        {
        }

        public List<Enumeration> AllEnumerations { get; set; }
    }
}