using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_INSS.Models
{
    public class IRRFFaixa
    {
        public decimal Minimo { get; }
        public decimal Maximo { get; }
        public decimal Aliquota { get; }
        public decimal ParcelaADeduzir { get; }

        public IRRFFaixa(decimal minimo, decimal maximo, decimal aliquota, decimal parcelaADeduzir)
        {
            Minimo = minimo;
            Maximo = maximo;
            Aliquota = aliquota;
            ParcelaADeduzir = parcelaADeduzir;
        }
    }
}
