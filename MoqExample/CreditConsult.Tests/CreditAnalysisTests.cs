using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CreditConsult.Tests
{
    public class CreditAnalysisTests
    {
        private Mock<ICreditConsultService> mock;

        private const string CPF_INVALIDO = "123A";
        private const string CPF_ERRO_COMUNICACAO = "76217486300";
        private const string CPF_SEM_PENDENCIAS = "60487583752";
        private const string CPF_INADIMPLENTE = "82226651209";

        public CreditAnalysisTests()
        {
            mock = new Mock<ICreditConsultService>(MockBehavior.Strict);

            mock.Setup(s => s.PendenciesConsultByCPF(CPF_INVALIDO))
                .Returns(() => null);

            mock.Setup(s => s.PendenciesConsultByCPF(CPF_ERRO_COMUNICACAO))
                .Throws(new ("Testing comunication error"));

            mock.Setup(s => s.PendenciesConsultByCPF(CPF_SEM_PENDENCIAS))
                .Returns(() => new List<Pendency>());


            Pendency pendency = new()
            {
                CPF = CPF_INADIMPLENTE,
                NomePessoa = "Cliente Teste",
                NomeReclamante = "Empresas ACME",
                DescricaoPendencia = "Parcela não paga",
                VlPendencia = 900.50
            };

            List<Pendency> pendencies = new List<Pendency>();
            pendencies.Add(pendency);

            mock.Setup(s => s.PendenciesConsultByCPF(CPF_INADIMPLENTE))
                .Returns(() => pendencies);

        }
        private CreditConsultStatus GetCreditAnalysisStatus(string cpf)
        {
            CreditAnalysis analysis = new CreditAnalysis(mock.Object);
            return analysis.CPF_SituationConsult(cpf);
        }

        [Fact]
        public void TestarCPFInvalidoMoq()
        {
            CreditConsultStatus status =
                GetCreditAnalysisStatus(CPF_INVALIDO);
            status.Should().Be(CreditConsultStatus.ParametroEnvioInvalido,
                "Resultado incorreto para um CPF inválido");
        }

        [Fact]
        public void TestarErroComunicacaoMoq()
        {
            CreditConsultStatus status =
                GetCreditAnalysisStatus(CPF_ERRO_COMUNICACAO);
            status.Should().Be(CreditConsultStatus.ErroComunicacao,
                "Resultado incorreto para um erro de comunicação");
        }

        [Fact]
        public void TestarCPFSemPendenciasMoq()
        {
            CreditConsultStatus status =
                GetCreditAnalysisStatus(CPF_SEM_PENDENCIAS);
            status.Should().Be(CreditConsultStatus.SemPendencias,
                "Resultado incorreto para um CPF sem pendências");
        }

        [Fact]
        public void TestarCPFInadimplenteMoq()
        {
            CreditConsultStatus status =
                GetCreditAnalysisStatus(CPF_INADIMPLENTE);
            status.Should().Be(CreditConsultStatus.Inadimplente,
                "Resultado incorreto para um CPF inadimplente");
        }
    }
}