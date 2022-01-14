using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void Add_ReturnsAplusB()
        {
            var math = new Math();

            var result = math.Add(1, 1);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Max_ReturnsMaxValue()
        {
            var math = new Math();

            var result = math.Max(2, 1);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void GetOddNumbers_ReturnOddNumbers()
        {
            var math = new Math();
            List<int> numbers = new List<int> { 1, 3, 5 };

            var result = math.GetOddNumbers(5);

            Assert.IsTrue(result.SequenceEqual(numbers));
        }



    }
}
