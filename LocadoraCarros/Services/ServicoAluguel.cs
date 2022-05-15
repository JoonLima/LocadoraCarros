using LocadoraCarros.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraCarros.Services
{
    class ServicoAluguel
    {
        public double ValorPorHora { get; private set; }
        public double ValorPorDia { get; private set; }

        private IServicoDeTaxa _serviçoTaxa;

        public ServicoAluguel(double valorPorHora, double valorPorDia, IServicoDeTaxa servicoDeTaxa)
        {
            ValorPorHora = valorPorHora;
            ValorPorDia = valorPorDia;
            _serviçoTaxa = servicoDeTaxa;
        }

        public void ProcessarFatura(AluguelCarro aluguelCarro)
        {
            TimeSpan duracao = aluguelCarro.Fim.Subtract(aluguelCarro.Inicio);

            double pagamentoBasico = 0;

            if (duracao.TotalHours <= 12.0)
            {
                pagamentoBasico = ValorPorHora * Math.Ceiling(duracao.TotalHours);
            }
            else
            {
                pagamentoBasico = ValorPorDia * Math.Ceiling(duracao.TotalDays);
            }

            double taxa = _serviçoTaxa.Taxa(pagamentoBasico);

            aluguelCarro.Fatura = new Fatura(pagamentoBasico, taxa);

        }
    }
}
