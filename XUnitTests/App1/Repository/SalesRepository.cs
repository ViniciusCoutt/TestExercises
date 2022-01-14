using SistemaDeVendas.Entities;

namespace SistemaDeVendas.Repository
{
    public class SalesRepository : ISalesRepository
    {
        public IList<Sales> FindSales(short month, short year)
        {
            return new List<Sales>
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
        }
    }
}
