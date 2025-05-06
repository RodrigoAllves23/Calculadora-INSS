using Calculadora_INSS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora_INSS.Models;


namespace Calculadora_INSS.Services
{
    public class INSSCalculator : IINSSCalculator
    {
        private readonly List<INSSFaixa> _faixas = new()
        {
            new INSSFaixa(1518.00m, 0.075m),
            new INSSFaixa(2793.88m, 0.09m),
            new INSSFaixa(4190.83m, 0.12m),
            new INSSFaixa(8157.41m, 0.14m)
        };

        private const decimal TetoINSS = 951.62m;

        public DescontoResult Calcular(decimal salarioBruto)
        {
            decimal total = 0;
            decimal salarioRestante = salarioBruto;
            decimal valorAnterior = 0;

            for (int i = 0; i < _faixas.Count; i++)
            {
                var faixa = _faixas[i];
                if (salarioBruto > faixa.Limite)
                {
                    decimal faixaBase = faixa.Limite - valorAnterior;
                    total += faixaBase * faixa.Aliquota;
                    valorAnterior = faixa.Limite;
                }
                else
                {
                    decimal faixaBase = salarioBruto - valorAnterior;
                    total += faixaBase * faixa.Aliquota;
                    break;
                }
            }

            if (salarioBruto > _faixas.Last().Limite)
                total = TetoINSS;

            return new DescontoResult
            {
                Valor = Math.Round(total, 2),
                Aliquota = Math.Round((total / salarioBruto) * 100, 2),
                Faixa = "Progressiva"
            };
        }
    }
}
