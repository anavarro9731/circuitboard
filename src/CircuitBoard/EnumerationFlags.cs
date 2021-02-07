using System;
using System.Collections.Generic;
using System.Linq;

namespace CircuitBoard
{
    /* stores a list of "selected values" from a typed enumeration in a single serialisable class
     could be used to:
        avoids lots of bool properties
        represent a single current state in a state-machine
        represent a selection of items from a list
     */
    public static class EnumerationFlagsMethods
    {

        public static EnumerationFlags AddFlag<T>(this EnumerationFlags flags, T value) where T : Enumeration
        {
            if (flags.AllowMultipleSelections == false && flags.SelectedKeys.Count == 1)
                throw new ArgumentOutOfRangeException("Cannot add item, multiple selections are not allowed");
            if (flags.SelectedKeys.Contains(value.Key)) throw new ArgumentException("State already flagged");

            flags.SelectedKeys.Add(value.Key);

            return flags;
        }

        public static int Count(this EnumerationFlags flags) => flags.SelectedKeys.Count;

        public static bool HasFlag(this EnumerationFlags flags, Enumeration item) => flags.SelectedKeys.Contains(item.Key);

        public static bool HasFlag(this EnumerationFlags flags, string key) => flags.SelectedKeys.Exists(x => x == key);

        public static EnumerationFlags RemoveFlag<T>(this EnumerationFlags flags, T value) where T : Enumeration
        {
            flags.SelectedKeys.Remove(value.Key);

            return flags;
        }

        public static void ReplaceFlag(this EnumerationFlags flags, Enumeration old, Enumeration @new)
        {
            flags.RemoveFlag(old);
            flags.AddFlag(@new);
        }
    }

    public class EnumerationFlags
    {
        public EnumerationFlags(Enumeration initialState = null, bool allowMultipleSelections = true)
        {
            if (initialState != null) this.AddFlag(initialState);
            AllowMultipleSelections = allowMultipleSelections;
        }
        
        public EnumerationFlags() {}

        //* nullable for soap
        public bool? AllowMultipleSelections { get; set; }

        //* don't inherit from List<string> to ensure simplest serialisation
        public List<string> SelectedKeys { get; set; } = new List<string>();
    }
    
    
    public class TypedEnumerationFlags<T> : EnumerationFlags where T : Enumeration, new()
    {
        public TypedEnumerationFlags(T initialState = null, bool allowMultipleSelections = true)
        {
            if (initialState != null) this.AddFlag(initialState);
            AllowMultipleSelections = allowMultipleSelections;
        }
        
        public TypedEnumerationFlags() {}
        
    }
}
