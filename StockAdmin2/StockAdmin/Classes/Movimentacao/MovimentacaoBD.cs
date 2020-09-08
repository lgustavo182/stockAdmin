/*****************************************************************************
* Nome           : MovimentacaoBD
* Classe         : Representação da classe que se conecta com o banco através 
*                  da entidade Movimentacao
* Data  Criação  : 13/02/2020
* Data Alteração : -
* Escrito por    : Gabriel Prado
* Observações    : 
* ***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Dynamic;

namespace PROJETO_UC10
{
    class MovimentacaoBD
    {
        //13/02/2020 - Gabriel Prado - ToDo: criar uma classe de funções gerais (FuncGeral)

        /*****************************************************************************
        * Nome           : Incluir
        * Procedimento   : Responsável por incluir o Objeto na Base de Dados
        *                  Método para inclui um registro na tabela Movimentacao
        * Parametros     : Objeto da Classe Movimentacao
        * Data  Criação  : 05/11/2019
        * Data Alteração : -
        * Escrito por    : Gabriel Prado
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public int Incluir(Movimentacao aobj_Movimentacao)
        {
            //13/02/2020 - Gabriel Prado - Criar objeto de conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //13/02/2020 - Gabriel Prado - Criar a variável que contém a instrução SQL
            string varSql = "INSERT INTO TB_MOVIMENTACAO " +
                            "(" +
                            " I_COD_MOVIMENTACAO, " +
                            " S_NM_PRODUTO,   " +
                            " S_TIT_CATEGORIA,  " +
                            " I_COD_PRODUTO " +
                            ")" +
                            "VALUES " +
                            "(" +
                            " @I_COD_MOVIMENTACAO, " +
                            " @S_NM_PRODUTO,   " +
                            " @S_TIT_CATEGORIA,  " +
                            " @I_COD_PRODUTO " +
                            "); " +
                            "SELECT ident_current('TB_MOVIMENTACAO') as 'id'";

            //13/02/2020 - Gabriel Prado - Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAO", aobj_Movimentacao.COD_MOVIMENTACAO);
            objCmd.Parameters.AddWithValue("@S_NM_PRODUTO", aobj_Movimentacao.NM_PRODUTO);
            objCmd.Parameters.AddWithValue("@S_TIT_CATEGORIA", aobj_Movimentacao.TIT_CATEGORIA);
            objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_Movimentacao.COD_PRODUTO);
            try
            {
                //13/02/2020 - Gabriel Prado - Abrir a conexão com o banco de dados
                objCon.Open();

                //13/02/2020 - Gabriel Prado - Executar o comando Escalar
                int _id = Convert.ToInt16(objCmd.ExecuteScalar());

                //(13/02/2020-Gabriel Prado) fechar a conexão
                objCon.Close();

                return _id;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }


        /*****************************************************************************
        * Nome           : Alterar
        * Procedimento   : Responsável por editar o Objeto na Base de Dados
        *                  Método para Alteração de um registro na tabela Movimentacao
        * Parametros     : Objeto da Classe Movimentacao
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Gabriel Prado
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Alterar(Movimentacao aobj_Movimentacao)
        {


            if (aobj_Movimentacao.COD_PRODUTO != -1)
            {
                //(08/11/2018-Gabriel Prado) Criar objeto de conexão com o banco de dados
                SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

                //(15/06/2018-Gabriel Prado) Criar a variável que contém a instrução SQL
                string varSql = "UPDATE TB_MOVIMENTACAO SET " +
                                "I_COD_MOVIMENTACAO = @I_COD_MOVIMENTACAO," +
                                "S_NM_PRODUTO = @S_NM_PRODUTO,  " +
                                "S_TIT_CATEGORIA = @S_TIT_CATEGORIA,  " +
                                "I_COD_PRODUTO = @I_COD_PRODUTO  " +
                                "WHERE I_COD_PRODUTO = @I_COD_PRODUTO";

                //(08/11/2019-Gabriel Prado) Criar objeto para executar o comando
                SqlCommand objCmd = new SqlCommand(varSql, objCon);
                objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAO", aobj_Movimentacao.COD_MOVIMENTACAO);
                objCmd.Parameters.AddWithValue("@S_NM_PRODUTO", aobj_Movimentacao.NM_PRODUTO);
                objCmd.Parameters.AddWithValue("@S_TIT_CATEGORIA", aobj_Movimentacao.TIT_CATEGORIA);
                objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_Movimentacao.COD_PRODUTO);
                
                try
                {
                    //(13/02/2020-Gabriel Prado) Abrir a conexão com o banco de dados
                    objCon.Open();

                    //(13/02/2020-Gabriel Prado) Executar o comando
                    objCmd.ExecuteNonQuery();

                    //(13/02/2020-Gabriel Prado) fechar a conexão
                    objCon.Close();

                    return true;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }


        /*****************************************************************************
        * Nome           : Excluir
        * Procedimento   : Responsável por Apagar o Objeto na Base de Dados
        *                  Método para deletar um registro na tabela Receita
        * Parametros     : Objeto da Classe Movimentacao
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Gabriel Prado
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Excluir(Movimentacao aobj_Movimentacao)
        {
            //(13/02/2020-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection ObjCon = new SqlConnection(Connection.ConnectionPath());

            //(13/02/2020-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " DELETE FROM TB_MOVIMENTACAO " +
                            " WHERE I_COD_MOVIMENTACAO = @I_COD_MOVIMENTACAO";

            //(13/02/2020-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, ObjCon);
            objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAO", aobj_Movimentacao.COD_MOVIMENTACAO);

            try
            {
                //(13/02/2020-Victor Henrique) Abrir a conexão com o banco de dados
                ObjCon.Open();

                //(13/02/2020-Victor Henrique) Executar o comando para excluir o registro
                objCmd.ExecuteNonQuery();

                //(13/02/2020-Victor Henrique) Fechar a conexão com o banco de dados
                ObjCon.Close();

                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /*****************************************************************************
        * Nome           : FindByCodMovimentacao
        * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
        *                  Método para Buscar um registro na tabela TB_MOVIMENTACAO
        * Parametros     : Objeto da Classe Movimentacao
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Gabriel Prado
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Movimentacao FindByCodMovimentacao(Movimentacao aobj_Movimentacao)
        {
            //(13/02/2020-Gabriel Prado) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(13/02/2020-Gabriel Prado) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_MOVIMENTACAO " +
                            " WHERE I_COD_MOVIMENTACAO = @I_COD_MOVIMENTACAO ";

            //(13/02/2020-Gabriel Prado) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@I_COD_MOVIMENTACAO", aobj_Movimentacao.COD_MOVIMENTACAO);

            try
            {
                //(13/02/2020-Gabriel Prado) Abrir a conexão com o banco de dados
                objCon.Open();

                //(13/02/2020-Gabriel Prado) Criar um objeto DataReader que irá receber os dados
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    //Ler os dados que estão no objeto DataReader 
                    objDtr.Read();

                    //(13/02/2020-Gabriel Prado) Recupero os valores (Tipo um Popula Objeto)
                    aobj_Movimentacao.COD_MOVIMENTACAO = Convert.ToInt16(objDtr["I_COD_MOVIMENTACAO"]);
                    aobj_Movimentacao.NM_PRODUTO = objDtr["S_NM_PRODUTO"].ToString();
                    aobj_Movimentacao.TIT_CATEGORIA = objDtr["S_TIT_CATEGORIA"].ToString();
                    aobj_Movimentacao.COD_PRODUTO = Convert.ToInt16(objDtr["I_COD_PRODUTO"]);
                }

                objCon.Close();
                objDtr.Close();
                return aobj_Movimentacao;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_Movimentacao;
            }
        }


        /****************************************************************************
        * Nome           : FindAllMovimentacao
        * Procedimento   : Responsável por encontrar todos os Objetos na Base de Dados
        *                   Método para Buscar uma lista de registros 
        * Parametros     : Objeto da Classe Movimentacao
        * Data Criação   : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Gabriel Prado(Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public List<Movimentacao> FindAllMovimentacao()
        {
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());
            string varSql = " SELECT * FROM TB_MOVIMENTACAO ";
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Movimentacao> aLista = new List<Movimentacao>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Movimentacao aobj_Movimentacao = new Movimentacao();

                        aobj_Movimentacao.COD_MOVIMENTACAO = Convert.ToInt16(objDtr["I_COD_MOVIMENTACAO"]);
                        aobj_Movimentacao.NM_PRODUTO = objDtr["S_NM_PRODUTO"].ToString();
                        aobj_Movimentacao.TIT_CATEGORIA = objDtr["S_TIT_CATEGORIA"].ToString();
                        aobj_Movimentacao.COD_PRODUTO = Convert.ToInt16(objDtr["I_COD_PRODUTO"]);

                        aLista.Add(aobj_Movimentacao);

                    }

                    objCon.Close();
                    objDtr.Close();
                    return aLista;

                }
                else
                {
                    objCon.Close();
                    objDtr.Close();
                    return null;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
