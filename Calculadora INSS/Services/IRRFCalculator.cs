using Calculadora_INSS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora_INSS.Models;


namespace Calculadora_INSS.Services
{
    public class IRRFCalculator : IIRRFCalculator
    {
        private readonly List<IRRFFaixa> _faixas = new()
        {
            new IRRFFaixa(0.00m, 2428.80m, 0m, 0m),
            new IRRFFaixa(2428.81m, 2826.65m, 0.075m, 182.16m),
            new IRRFFaixa(2826.66m, 3751.05m, 0.15m, 394.16m),
            new IRRFFaixa(3751.06m, 4664.68m, 0.225m, 675.49m),
            new IRRFFaixa(4664.69m, decimal.MaxValue, 0.275m, 908.73m)
        };

        public DescontoResult Calcular(decimal salarioBase, int dependentes)
        {
            const decimal deducaoPorDependente = 189.59m;
            decimal baseComDependentes = salarioBase - (dependentes * deducaoPorDependente);

            var faixa = _faixas.FirstOrDefault(f => baseComDependentes >= f.Minimo && baseComDependentes <= f.Maximo);

            if (faixa == null || faixa.Aliquota == 0)
            {
                return new DescontoResult { Valor = 0, Aliquota = 0, Faixa = "Isento" };
            }

            decimal imposto = (baseComDependentes * faixa.Aliquota) - faixa.ParcelaADeduzir;
            return new DescontoResult
            {
                Valor = Math.Round(imposto, 2),
                Aliquota = faixa.Aliquota * 100,
                Faixa = $"{faixa.Aliquota * 100}%"
            };
        }
    }
}
