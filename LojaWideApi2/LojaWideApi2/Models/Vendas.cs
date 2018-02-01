using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWideApi2.Models
{
    public class Vendas
    {
        public int idVenda { get; set; }
        public string cpf_cliente { get; set; }
        public string produto { get; set; }
        public DateTime Data_venda { get; set; }
        public int quantidade { get; set; }
        public string metodo_pagamento { get; set; }
        public int numero_parcelas { get; set; }
        public double valor_total { get; set; }

    }
}