﻿using System.Collections.Generic;

namespace CircuitBoard
{
    //* the typed version is here to facilitate static constraints and intellisense
    public class TypedEnumerationFlags<T> : EnumerationFlags where T : Enumeration, new()
    {
        public TypedEnumerationFlags(T initialState = null) :
            base(initialState)
        {
        }

        public TypedEnumerationFlags(IEnumerable<T> initialStates = null)
            : base(initialStates)
        {
        }

        public TypedEnumerationFlags()
        {
        }
    }
}
