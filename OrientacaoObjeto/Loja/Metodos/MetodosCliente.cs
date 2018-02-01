using System;
using System.Collections.Generic;
using System.Data.dll;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class MetodosExtensao
{

    public static int Metade(this int Valor)
    {

        return Valor / 2;
    }

    public static double Juros(this double Valor)
    {

        return Valor + 30;
    }

    public static string PrimeiraMaiscula(this string Valor)
    {

        return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
    }

    public static string PrimeiraMaiscula(this string Valor, bool UltimasMinusculas)
    {

        if (UltimasMinusculas)
        {

            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1).ToLower();
        }
        else
        {

            return Valor.Substring(0, 1).ToUpper() + Valor.Substring(1, Valor.Length - 1);
        }
    }
}

namespace Loja.Classes
{
    public partial class Cliente : IDisposable
    {
        public void Insert()
        {
            using (SqlConnection cn = new SqlConnection("" +
                            "Server=ANDRADE-PC;Database=loja;Trusted_Connection=true"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Insert into Cliente (Codigo, Nome, Tipo, Datacadastro) VALUES (@codigo, @nome, @tipo, @datacadastro)";
                    cmd.Connection = cn;

                    // inserindo
                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._datacadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        this._isNew = false;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public void Update()
        {
            using (SqlConnection cn = new SqlConnection("" +
                            "Server=ANDRADE-PC;Database=loja;Trusted_Connection=true"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Update Cliente Set Nome = @nome, Tipo = @tipo, DataCadastro = @datacadastro Where Codigo = @codigo";
                    cmd.Connection = cn;

                    // inserindo
                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._datacadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        this._IsModified = false;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        public void Gravar()
        {
            if (this._isNew)
                Insert();
            else if (this._IsModified)
                Update();
        }

        public static Int32 Proximo()
        {
            Int32 _return = 0;
            using (SqlConnection cn = new SqlConnection("" +
                "Server=ANDRADE-PC;Database=loja;Trusted_Connection=true"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select MAX(Codigo) + 1 from Cliente";
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            _return = dr.GetInt32(0);
                        }
                    }
                   
                }
                return _return;
            }
        }

        public static List<Cliente> Todos()
        {
            List<Cliente> _return = null;
            using (SqlConnection cn = new SqlConnection("" +
                "Server=ANDRADE-PC;Database=loja;Trusted_Connection=true"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Cliente;
                    

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Cliente cli = new Cliente();
                                cli._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                                cli._nome = dr.GetString(dr.GetOrdinal("Nome"));
                                cli._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                                cli._datacadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));

                                if (_return == null)
                                    _return = new List<Cliente>();

                                _return.Add(cli);
                            }
                            
                            
                        }
                    }
                   
                }

            }
            return _return;
        }
        public void Apagar()
        {
            using (SqlConnection cn = new SqlConnection("" +
                           "Server=ANDRADE-PC;Database=loja;Trusted_Connection=true"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Delete from Cliente Where Codigo = @codigo";
                    cmd.Connection = cn;

                    // inserindo
                    cmd.Parameters.AddWithValue("@codigo", this._codigo);
                    cmd.Parameters.AddWithValue("@nome", this._nome);
                    cmd.Parameters.AddWithValue("@tipo", this._tipo);
                    cmd.Parameters.AddWithValue("@datacadastro", this._datacadastro);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        public void Dispose()
        {
            this.Gravar();
        }

        public Cliente()
        {
            this._codigo = Proximo();
            this._isNew = true;
            this._IsModified = false;
        }

        public Cliente(int codigo)
        {
            //TODO: Criar procedimento de leitura baseado no parametro codigo
            using (SqlConnection cn = new SqlConnection("" +
                "Server=ANDRADE-PC;Database=loja;Trusted_Connection=true"))
            {
                try
                {
                    cn.Open();
                }
                catch (Exception)
                {

                    throw;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "Select * from Cliente WHERE Codigo = @codigo";
                    cmd.Parameters.AddWithValue("@codigo", codigo);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            this._codigo = dr.GetInt32(dr.GetOrdinal("Codigo"));
                            this._nome = dr.GetString(dr.GetOrdinal("Nome"));
                            this._tipo = dr.GetInt32(dr.GetOrdinal("Tipo"));
                            this._datacadastro = dr.GetDateTime(dr.GetOrdinal("DataCadastro"));
                        }
                    }
                    this._isNew = false;
                    this._IsModified = false;
                }

            }
        }
    }
}
