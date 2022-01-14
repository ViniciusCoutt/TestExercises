using SistemaDeVendas.Repository;

namespace SistemaDeVendas.Business
{
    public class SalesBusiness 
    {

        private readonly ISalesRepository _salesRepository;

        public SalesBusiness(ISalesRepository salesRepo)
        {
            _salesRepository = salesRepo;
        }

        public decimal AverageMonthCalc(short month, short year)
        {
            var sales = _salesRepository.FindSales(month, year);

            var monthlySales = sales.Sum(s => s.Value) / sales.Count();

            return Math.Round(monthlySales, 2);
        }
    }
}
