using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrientacaoObjeto.Classes;

namespace OrientacaoObjeto.Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            /*using (Loja.Classes.Cliente novoCliente2 = new Loja.Classes.Cliente(2))
            {

            }
           /* using (Cliente novoCliente = new Cliente())
            {
                novoCliente.Codigo = 2;
                novoCliente.Nome = "Pedrinho";
                novoCliente.Tipo = 2;
                novoCliente.DataCadastro = DateTime.Now;
                // o bloco using chama automaticamente o metodo dispose, q possui gravar
            }
            //try
            //{
            //    Cliente novoCliente = new Cliente();
            //    //novoCliente.Codigo = Convert.ToInt32("3");
            //    novoCliente.Codigo = 1;
            //    novoCliente.Nome = "adão".PrimeiraMaiscula();
            //    novoCliente.Tipo = 1;
            //    novoCliente.DataCadastro = DateTime.Now;
            //    novoCliente.Dispose();
            //}
            //catch (Excecoes.ExcecoesCliente.ValidacaoException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    throw;
            //}

            // Convert.ToDateTime("string");

            /*
            Cliente outroCliente = new Cliente(5);
            outroCliente.Dispose(); // desconstrutor da classe, que possui o gravar()
            */

            // bloco using, realiza o q ta dentro, depois vai pro dispose()
            
            /*using (Cliente outroCliente = new Cliente(5))
            {
                outroCliente.Nome = "Outro nome novo";
            }


            Contato contatoCliente1 = new Contato();
            contatoCliente1.Codigo = 1;
            contatoCliente1.DadosContato = "4028-4736";
            contatoCliente1.Tipo = "Telefone";

            Contato contatoCliente2 = new Contato();
            contatoCliente2.Codigo = 2;
            contatoCliente2.DadosContato = "amiza123@yahoo.com.br";
            contatoCliente2.Tipo = "Email";
            

            /*novoCliente.Contatos = new List<Contato>();

            novoCliente.Contatos.Add(contatoCliente1);
            novoCliente.Contatos.Add(contatoCliente2);

            //exibir

            /*foreach (Contato cont in novoCliente.Contatos)
            {
                Console.WriteLine(cont.DadosContato);
            } */

            //novoCliente.Contatos.ForEach(cont => Console.WriteLine(cont.DadosContato));

            // para gravar

            //novoCliente.Contatos.ForEach(cont => cont.Gravar());

            /*
            Console.WriteLine(contatoCliente.DadosContato);
            Console.WriteLine(novoCliente.Nome);
            Console.ReadKey(); */

            // Contatos = list
           /* Console.WriteLine(novoCliente.Contatos.FirstOrDefault(
                                            x => x.Tipo == "Email")
                                            .DadosContato);
            Console.ReadKey();*/
        }
    }
}
