using System.Collections.Generic;
using System.Linq;

namespace CircuitBoard
{
    public class EnumerationAndFlags : EnumerationFlags
    {
        public EnumerationAndFlags(Enumeration initialState = null, List<Enumeration> allEnumerations = null) :
            base(initialState)
        {
            AllEnumerations = allEnumerations;
            AllowMultipleSelections = false;
        }

        public EnumerationAndFlags()
        {
        }

        public List<Enumeration> AllEnumerations { get; set; }
    }

    public static class EnumerationAndFlagsExt
    {
        public static EnumerationAndFlags AddFlagIfItExistsInAllEnumerations(this EnumerationAndFlags flags, string key)
        {
            if (flags.AllEnumerations.Any(f => f.Key == key)) flags.AddFlag(flags.AllEnumerations.Single(x => x.Key == key));

            return flags;
        }

        public static EnumerationAndFlags AddFlagsIfTheyExistInAllEnumerations(this EnumerationAndFlags flags, List<string> keys)
        {
            keys = keys ?? new List<string>();
            var knownKeys = keys.Where(key => flags.AllEnumerations.Any(f => f.Key == key)).ToList();
            foreach (var key in knownKeys) flags.AddFlag(flags.AllEnumerations.Single(x => x.Key == key));

            return flags;
        }
    }
}
