using Xunit;

namespace MyTests.GivenMyCalculator
{
    public class ShipBusinessTest
    {
        [Fact]
        public void ThenTheyShouldAddProperly()
        {
            var calc = new MyLibrary.Calculator();
            var add1 = 2;
            var add2 = 3;

            var result = calc.Sum(add1, add2);

            Assert.Equal(5, result);

        }
    }
}
