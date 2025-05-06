using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_INSS.Models
{
    public class INSSFaixa
    {
        public decimal Limite { get; }
        public decimal Aliquota { get; }

        public INSSFaixa(decimal limite, decimal aliquota)
        {
            Limite = limite;
            Aliquota = aliquota;
        }
    }
}
