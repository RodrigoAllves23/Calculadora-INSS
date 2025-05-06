using Calculadora_INSS.Services;
using Calculadora_INSS.Interfaces;

namespace Calculadora_INSS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o salário bruto: ");
            decimal.TryParse(Console.ReadLine(), out decimal salarioBruto);
            

            Console.Write("Digite a quantidade de dependentes: ");
            int.TryParse(Console.ReadLine(), out int dependentes);

            IINSSCalculator inssCalculator = new INSSCalculator();
            IIRRFCalculator irrfCalculator = new IRRFCalculator();

            var inss = inssCalculator.Calcular(salarioBruto);
            decimal salarioBase = salarioBruto - inss.Valor;

            var irrf = irrfCalculator.Calcular(salarioBase, dependentes);
            decimal salarioLiquido = salarioBruto - inss.Valor - irrf.Valor;

            Console.WriteLine("\nResumo do cálculo:");
            Console.WriteLine($"Salário Bruto: R$ {salarioBruto:N2}");
            Console.WriteLine($"INSS ({inss.Faixa} - {inss.Aliquota}%): R$ {inss.Valor:N2}");
            Console.WriteLine($"IRRF ({irrf.Faixa} - {irrf.Aliquota}%): R$ {irrf.Valor:N2}");
            Console.WriteLine($"Salário Líquido: R$ {salarioLiquido:N2}");
        }
    }
}

