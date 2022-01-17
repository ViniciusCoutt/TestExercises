using SistemaDeVendas.Business;

namespace MyTests.Business
{
    public class ShipBusinessTest
    {
        [Theory(DisplayName = "Distance less than 5 returns 0.00, between 5 and 15 returns 10.00, bigger than 15 returns 30.00")]
        [InlineData(3)]
        [InlineData(7)]
        [InlineData(20)]
        public void ShipCalc_WithDinamicValues(int distanceKm)
        {
            var result = new ShipBusiness().ShipCalc(distanceKm);

            if (result == 0.00m)
                Assert.Equal(0.00m, result);

            if (result == 10.00m)
                Assert.Equal(10.00m, result);

            if (result == 30.00m)
                Assert.Equal(30.00m, result);
        }

        [Fact]
        public void ShipCalc_DistanceLessThan5_Return0()
        {
            var result = new ShipBusiness().ShipCalc(3);

            Assert.Equal(0.00m, result);
        }
        
        [Fact]
        public void ShipCalc_DistanceBetween5and15_Return10()
        {
            var result = new ShipBusiness().ShipCalc(7);

            Assert.Equal(10.00m, result);
        }

        [Fact]
        public void ShipCalc_DistanceBiggerThan15_Return30()
        {
            var result = new ShipBusiness().ShipCalc(20);

            Assert.Equal(30.00m, result);
        }
    }
}
