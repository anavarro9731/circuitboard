﻿using System;

namespace CircuitBoard.Permissions
{
    public class ScopeReference : IEquatable<ScopeReference>
    {
        public static bool operator ==(ScopeReference a, ScopeReference b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b)) return true;

            // If one is null, but not both, return false.
            if ((object) a == null || (object) b == null) return false;

            // Return true if the fields match:
            return a.PropertiesAreEqual(b);
        }

        public static bool operator !=(ScopeReference a, ScopeReference b)
        {
            return !(a == b);
        }

        public ScopeReference(Guid idOfScopeObject, string typeOfOwner, DateTime? addedOn = null, string referenceId = null)
        {
            ScopeObjectObjectId = idOfScopeObject;
            ScopeObjectType = typeOfOwner;
            ReferenceId = referenceId;
            ScopeReferenceCreatedOn = addedOn ?? DateTime.UtcNow;
        }

        public ScopeReference()
        {
        }

        public string ReferenceId { get; set; }

        public Guid ScopeObjectObjectId { get; set; }

        public string ScopeObjectType { get; set; }

        public DateTime ScopeReferenceCreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            //if the object passed is null return false;
            if (ReferenceEquals(null, obj)) return false;

            //if the objects are the same instance return true
            if (ReferenceEquals(this, obj)) return true;

            //if the objects are of different types return false
            if (obj.GetType() != GetType()) return false;

            //check on property equality
            return PropertiesAreEqual((ScopeReference) obj);
        }

        public override int GetHashCode()
        {
            var hash = 13;
            hash = hash * 7 + ScopeObjectObjectId.GetHashCode();
            hash = hash * 7 + ScopeObjectType.GetHashCode();
            return hash;
        }

        bool IEquatable<ScopeReference>.Equals(ScopeReference other)
        {
            return Equals(other);
        }

        protected bool PropertiesAreEqual(ScopeReference other)
        {
            return ScopeObjectObjectId.Equals(other.ScopeObjectObjectId) && ScopeObjectType.Equals(other.ScopeObjectType);
        }
    }
}