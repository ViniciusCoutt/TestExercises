namespace CreditConsult
{
    public interface ICreditConsultService
    {
        IList<Pendency> PendenciesConsultByCPF(string cpf);
    }
}