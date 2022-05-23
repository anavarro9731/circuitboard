using System;
using System.Collections.Generic;
using System.Linq;

namespace CircuitBoard
{
    /// <summary>
    ///     original idea and code from https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    /// </summary>
    public class Enumeration : IComparable, IEquatable<Enumeration>, IComparer<Enumeration>, IEqualityComparer<Enumeration>
    {
        public Enumeration(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public Enumeration()
        {
        }

        public bool? Active { get; set; }

        public string Value { get; set; }

        public string Key { get; set; }

        public int CompareTo(object other) => Key.CompareTo(((Enumeration) other).Key);

        public int Compare(Enumeration x, Enumeration y) => x.Key.CompareTo(y.Key);

        public int GetHashCode(Enumeration obj) => Key.GetHashCode();

        bool IEqualityComparer<Enumeration>.Equals(Enumeration x, Enumeration y) => Equals(x, y);

        public bool Equals(Enumeration other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Key == other.Key;
        }

        public static bool Equals(Enumeration x, Enumeration y) => x?.Key == y?.Key;

        public static bool operator ==(Enumeration left, Enumeration right) => Equals(left, right);

        public static bool operator !=(Enumeration left, Enumeration right) => !Equals(left, right);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Enumeration) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Active.GetHashCode();
                hashCode = (hashCode * 397) ^ (Value != null ? Value.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Key != null ? Key.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString() => $"{Value} ({Key})";

        public static T ToTypedInstance<T>(string key) where T : Enumeration, new()
        {
            var matchingItem = TypedEnumeration<T>.GetAllInstances().FirstOrDefault(i => i.Key == key);

            if (matchingItem == null)
            {
                var message = $"The key '{key}' is not found among enumerations of type {typeof(T)}";
                throw new CircuitException(message);
            }

            return matchingItem;
        }
    }
}
