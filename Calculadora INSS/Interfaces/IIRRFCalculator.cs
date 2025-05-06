using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculadora_INSS.Models;


namespace Calculadora_INSS.Interfaces
{
    public interface IIRRFCalculator
    {
        DescontoResult Calcular(decimal salarioBase, int dependentes);
    }
}
