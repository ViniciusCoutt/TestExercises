namespace CreditConsult
{
    public class CreditAnalysis
    {
        private ICreditConsultService _creditConsultServ;

        public CreditAnalysis(ICreditConsultService creditConsultServ)
        {
            _creditConsultServ = creditConsultServ;
        }

        public CreditConsultStatus CPF_SituationConsult(string cpf)
        {
            try
            {
                var pendencies = _creditConsultServ.PendenciesConsultByCPF(cpf);

                if (pendencies == null)
                    return CreditConsultStatus.ParametroEnvioInvalido;
                else if (pendencies.Count == 0)
                    return CreditConsultStatus.SemPendencias;
                else
                    return CreditConsultStatus.Inadimplente;
            }
            catch
            {
                return CreditConsultStatus.ErroComunicacao;
            }
        }

    }
}