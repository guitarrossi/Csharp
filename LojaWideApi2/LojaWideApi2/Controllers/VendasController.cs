using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LojaWideApi2.Models;
namespace LojaWideApi2.Controllers
{
    [Route("api")]
    public class VendasController : ApiController
    {

        public Vendas[] vendas = new Vendas[]
        {
            new Vendas
            {
                idVenda = 1,
                cpf_cliente = "123.456.789-10",
                produto = "Iphone 5s",
                Data_venda = DateTime.Now,
                quantidade = 1,
                metodo_pagamento = "A Vista",
                numero_parcelas = 1,
                valor_total = 2500

            },

            new Vendas{

                idVenda = 2,
                cpf_cliente = "450.292.528-43",
                produto = "Galaxy S7",
                Data_venda = DateTime.Now,
                quantidade = 1,
                metodo_pagamento = "Parcelado",
                numero_parcelas = 10,
                valor_total = 3000
            }
        };

        private static List<Vendas> itensVendidos = new List<Vendas>();


        new Vendas[]
        [AcceptVerbs("GET")]
        [Route("ConsultaPorCPF/{cpf}")]
        public Vendas ConsultaPorCPF(string cpf)
        {
            Vendas venda = itensVendidos.Where(n => n.cpf_cliente == cpf).Select(n => n).FirstOrDefault();
            
            return venda;
        }

        // POST: api/Vendas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Vendas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Vendas/5
        public void Delete(int id)
        {
        }
    }
}
