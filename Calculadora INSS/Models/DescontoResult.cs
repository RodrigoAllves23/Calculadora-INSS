using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_INSS.Models
{
    public class DescontoResult
    {
        public decimal Valor { get; set; }
        public decimal Aliquota { get; set; }
        public string Faixa { get; set; } = string.Empty;
    }
}
