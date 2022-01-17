using SistemaDeVendas;
using Moq;
using SistemaDeVendas.Business;
using System.Collections.Generic;
using SistemaDeVendas.Entities;
using System;

namespace MyTests.Business
{
    public class SalesBusinessTest
    {
        SalesBusiness _salesBusiness;

        readonly Mock<ISalesRepository> _salesRepositoryMock;

        public SalesBusinessTest()
        {
            var sales = new List<Sales>
            {
                new Sales
                {
                    Date = new DateTime(2021, 04, 02),
                    Value = 500.00m
                },
                new Sales
                {
                    Date = new DateTime(2021, 04, 05),
                    Value = 50.00m
                },
                new Sales
                {
                    Date = new DateTime(2021, 04, 10),
                    Value = 353.10m
                }
            };

            _salesRepositoryMock = new Mock<ISalesRepository>();
            _salesRepositoryMock.Setup(x => x.FindSales(It.IsAny<short>(), It.IsAny<short>()))
                .Returns(sales);

            _salesBusiness = new SalesBusiness(_salesRepositoryMock.Object);
        }

        [Fact(DisplayName = "Calculo de venda mensal")]
        public void AverageMonthCalcTest()
        {
            var monthlyValue = _salesBusiness.AverageMonthCalc(4, 2021);

            Assert.Equal(301.03m, monthlyValue);
        }

    }
}
