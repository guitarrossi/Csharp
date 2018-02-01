using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Classes
{
    public partial class Cliente
    {
        private bool _isNew;

        public bool IsNew
        {
            get { return _isNew; }
            
        }

        private bool _IsModified;

        public bool IsModified
        {
            get { return _IsModified; }
            
        }


        private int _codigo;

        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (value < 0)
                {
                    throw new Excecoes.ExcecoesCliente.ValidacaoException("O Codigo do" +
                        "cliente não pode ser negativo");
                    _codigo = 0;
                }
                _codigo = value;
                this._IsModified = true;
            }
        }

        // '?' indica que pode receber null, caso contrario nao
        private string _nome;

        public string Nome
        {
            get {
                return _nome; }
            set {
                if (value.Length <= 3)
                {
                    throw new Excecoes.ExcecoesCliente.ValidacaoException("O nome inserido deve" +
                        "ter no mínimo 4 caracteres");
                }
                _nome = value; this._IsModified = true;
            }
        }


        private int _tipo;

        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; this._IsModified = true; }
        }

        private DateTime _datacadastro;

        public DateTime DataCadastro
        {
            get { return _datacadastro; }
            set { _datacadastro = value; this._IsModified = true; }
        }

  
        public List<Contato> Contatos { get; set; }

    }
}
