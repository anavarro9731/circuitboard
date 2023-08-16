using System.Linq;
using CircuitBoard;
using Newtonsoft.Json;
using Xunit;

namespace Soap.UnitTests
{

    public class CanBeUsedWithEnumerationsProperty
    {
        [Fact]
        public void ItShouldNotThrowAnErrorWhenUnTyped()
        {
            var x = new EnumerationAndFlags(StatesSample.One, StatesSample.GetAllInstances().Cast<Enumeration>().ToList())
            {
                AllowMultipleSelections = true
            };
            x.AddFlag(StatesSample.Three);
            var json = JsonConvert.SerializeObject(x);
            var y = JsonConvert.DeserializeObject<EnumerationAndFlags>(json);
            Assert.Equal(2, y.SelectedKeys.Count);
            Assert.Equal(StatesSample.Three, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
            Assert.Equal(3, y.AllEnumerations.Count);
            Assert.Equal(StatesSample.One, y.AllEnumerations.First());
        }
        
        [Fact]
        public void ItShouldNotThrowAnErrorWhenTyped()
        {
            var x = new TypedEnumerationAndFlags<StatesSample>(StatesSample.One, true)
            {
                AllowMultipleSelections = true
            };
            x.AddFlag(StatesSample.Three);
            var json = JsonConvert.SerializeObject(x);
            var y = JsonConvert.DeserializeObject<TypedEnumerationAndFlags<StatesSample>>(json);
            Assert.Equal(2, y.SelectedKeys.Count);
            Assert.Equal(StatesSample.Three, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
            Assert.Equal(3, y.AllEnumerations.Count);
            Assert.Equal(StatesSample.One, y.AllEnumerations.First());
        }
    }

    public class CanConvertBetweenTypedAndUnTyped
    {
        [Fact]
        public void ItShouldNotThrowAnError()
        {
            var x = new TypedEnumerationAndFlags<StatesSample>(StatesSample.One, true)
            {
                AllowMultipleSelections = true
            };
            x.AddFlag(StatesSample.Three);
            var json = JsonConvert.SerializeObject(x);
            var y = JsonConvert.DeserializeObject<EnumerationAndFlags>(json);
            Assert.Equal(2, y.SelectedKeys.Count);
            Assert.Equal(StatesSample.Three, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
            Assert.Equal(3, y.AllEnumerations.Count);
            Assert.Equal(StatesSample.One, y.AllEnumerations.First());
        }
    }
    

    public class CanBeUsedWithoutEnumerationsProperty
    {
        [Fact]
        public void ItShouldNotThrowAnError()
        {
            var x = new EnumerationAndFlags(StatesSample.One);
            Assert.Empty(x.AllEnumerations);
            var json = JsonConvert.SerializeObject(x);
            var y = JsonConvert.DeserializeObject<EnumerationAndFlags>(json);
            Assert.Single(y.SelectedKeys);
            Assert.Equal(StatesSample.One, StatesSample.GetInstanceFromKey(y.SelectedKeys.Last()));
            Assert.Empty(x.AllEnumerations);
        }
    }
}
