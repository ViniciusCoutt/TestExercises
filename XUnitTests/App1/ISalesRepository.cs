using SistemaDeVendas.Entities;

namespace SistemaDeVendas
{
    public interface ISalesRepository
    {
        IList<Sales> FindSales(short month, short year);
    }
}
