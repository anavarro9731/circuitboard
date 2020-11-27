﻿using System.Linq;
using CircuitBoard;
using Newtonsoft.Json;
using Xunit;

namespace Soap.UnitTests
{
    public class StatesSample : TypedEnumeration<StatesSample>
    {
        public static StatesSample One = Create("1", nameof(One));

        public static StatesSample Three = Create("3", nameof(Three));

        public static StatesSample Two = Create("2", nameof(Two));
    }

    public class EnumerationFlagsTests
    {
        public class WhenWeAddASecondState
        {
            private readonly EnumerationFlags x;

            public WhenWeAddASecondState()
            {
                x = new EnumerationFlags(StatesSample.One);
                x.AddFlag(StatesSample.Two);
            }

            [Fact]
            public void ItShouldContainTheDefaultState() => Assert.True(x.HasFlag(StatesSample.One));

            [Fact]
            public void ItShouldContainTheNewState() => Assert.True(x.HasFlag(StatesSample.Two));

            [Fact]
            public void ItShouldNotContainAnyOtherStates() => Assert.Equal(2, x.Count());
        }

        public class WhenWeCreateAFlaggedState
        {
            private readonly EnumerationFlags x;

            public WhenWeCreateAFlaggedState()
            {
                x = new EnumerationFlags(StatesSample.One);
            }

            [Fact]
            public void ItShouldContainNoOtherStates() => Assert.Equal(1, x.Count());

            [Fact]
            public void ItShouldContainTheDefaultState() => Assert.True(x.HasFlag(StatesSample.One));
        }

        public class WhenWeDeserialize
        {
            [Fact]
            public void ItShouldWork()
            {
                var x = new EnumerationFlags(StatesSample.One);
                var json = JsonConvert.SerializeObject(x);
                var y = JsonConvert.DeserializeObject<EnumerationFlags>(json);
                Assert.True(y.HasFlag(StatesSample.One));
            }
        }

        public class WhenWeConvertIntoFlagsAndBackToEnumerationItems
        {
            [Fact]
            public void ItShouldWork()
            {
                var x = new EnumerationFlags(StatesSample.One);
                x.AddFlag(StatesSample.Three);
                var json = JsonConvert.SerializeObject(x);
                var y = JsonConvert.DeserializeObject<EnumerationFlags>(json);
                Assert.Equal(2, y.SelectedKeys.Count);
                Assert.Equal(StatesSample.Three, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
            }
        }

        public class WhenWeRemoveAllStates
        {
            [Fact]
            public void ItShouldNotThrowAnError()
            {
                var x = new EnumerationFlags(StatesSample.One);
                x.RemoveFlag(StatesSample.One);
            }
        }
        
        
        public class CanTakeEnumerations
        {
            [Fact]
            public void ItShouldNotThrowAnError()
            {
                var x = new EnumerationAndFlags(StatesSample.One, StatesSample.GetAllInstances().Cast<Enumeration>().ToList());
                x.AddFlag(StatesSample.Three);
                var json = JsonConvert.SerializeObject(x);
                var y = JsonConvert.DeserializeObject<EnumerationAndFlags>(json);
                Assert.Equal(2, y.SelectedKeys.Count);
                Assert.Equal(StatesSample.Three, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
                Assert.Equal(3, y.AllEnumerations.Count);
                Assert.Equal(StatesSample.One, y.AllEnumerations.First());
            }
        }
        
        public class CanBeUsedWithoutEnumerations
        {
            [Fact]
            public void ItShouldNotThrowAnError()
            {
                var x = new EnumerationAndFlags(StatesSample.One);
                Assert.Null(x.AllEnumerations);
                var json = JsonConvert.SerializeObject(x);
                var y = JsonConvert.DeserializeObject<EnumerationAndFlags>(json);
                Assert.Equal(1, y.SelectedKeys.Count);
                Assert.Equal(StatesSample.One, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
                Assert.Null(x.AllEnumerations);
            }
        }


        public class WhenWeRemoveAState
        {
            private readonly EnumerationFlags x;

            public WhenWeRemoveAState()
            {
                x = new EnumerationFlags(StatesSample.One);
                x.AddFlag(StatesSample.Two);
                x.RemoveFlag(StatesSample.One);
            }

            [Fact]
            public void ItShouldNotRemoveAnyOtherStates() => Assert.Equal(1, x.Count());

            [Fact]
            public void ItShouldRemoveTheState() => Assert.True(!x.HasFlag(StatesSample.One));
        }
    }
}
