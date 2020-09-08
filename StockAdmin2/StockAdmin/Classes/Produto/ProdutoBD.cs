/*****************************************************************************
* Nome           : ProdutoBD
* Classe         : Representação da classe que se conecta com o banco através 
*                  da entidade Produto
* Data  Criação  : 13/02/2020
* Data Alteração : -
* Escrito por    : Victor Henrique
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
    class ProdutoBD
    {
        //13/02/2020 - Victor Henrique - ToDo: criar uma classe de funções gerais (FuncGeral)

        /*****************************************************************************
        * Nome           : Incluir
        * Procedimento   : Responsável por incluir o Objeto na Base de Dados
        *                  Método para inclui um registro na tabela Produto
        * Parametros     : Objeto da Classe Produto
        * Data  Criação  : 05/11/2019
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public int Incluir(Produto aobj_Produto)
        {
            //13/02/2020 - Victor Henrique - Criar objeto de conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //13/02/2020 - Victor Henrique - Criar a variável que contém a instrução SQL
            string varSql = "INSERT INTO TB_PRODUTO " +
                            "(" +
                            " I_COD_CATEGORIA,  " +
                            " S_NM_PRODUTO,   " +
                            " D_VLV_PRODUTO,   " +
                            " D_VLC_PRODUTO,   " +
                            " I_NF_PRODUTO   " +
                            ")" +
                            "VALUES " +
                            "(" +
                            " @I_COD_CATEGORIA,  " +
                            " @S_NM_PRODUTO,   " +
                            " @D_VLV_PRODUTO,  " +
                            " @D_VLC_PRODUTO,   " +
                            " @I_NF_PRODUTO   " +
                            "); " +
                            "SELECT ident_current('TB_PRODUTO') as 'id'";

            //13/02/2020 - Victor Henrique - Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_Produto.COD_PRODUTO);
            objCmd.Parameters.AddWithValue("@I_COD_CATEGORIA", aobj_Produto.COD_CATEGORIA);
            objCmd.Parameters.AddWithValue("@S_NM_PRODUTO", aobj_Produto.NM_PRODUTO);
            objCmd.Parameters.AddWithValue("@D_VLV_PRODUTO", aobj_Produto.VLV_PRODUTO);
            objCmd.Parameters.AddWithValue("@D_VLC_PRODUTO", aobj_Produto.VLC_PRODUTO);
            objCmd.Parameters.AddWithValue("@I_NF_PRODUTO", aobj_Produto.NF_PRODUTO);
            try
            {
                //13/02/2020 - Victor Henrique - Abrir a conexão com o banco de dados
                objCon.Open();

                //13/02/2020 - Victor Henrique - Executar o comando Escalar
                int _id = Convert.ToInt16(objCmd.ExecuteScalar());

                //(13/02/2020-Victor Henrique) fechar a conexão
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
        *                  Método para Alteração de um registro na tabela Produto
        * Parametros     : Objeto da Classe Produto
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Alterar(Produto aobj_Produto)
        {


            if (aobj_Produto.COD_PRODUTO != -1)
            {
                //(08/11/2018-Victor Henrique) Criar objeto de conexão com o banco de dados
                SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

                //(15/06/2018-Victor Henrique) Criar a variável que contém a instrução SQL
                string varSql = "UPDATE TB_PRODUTO SET " +
                                "I_COD_PRODUTO = @I_COD_PRODUTO," +
                                "I_COD_CATEGORIA = @I_COD_CATEGORIA, " +
                                "S_NM_PRODUTO = @S_NM_PRODUTO,  " +
                                "D_VLV_PRODUTO = @D_VLV_PRODUTO,  " +
                                "D_VLC_PRODUTO = @D_VLC_PRODUTO,  " +
                                "I_NF_PRODUTO = @I_NF_PRODUTO  " +
                                "WHERE I_COD_PRODUTO = @I_COD_PRODUTO";

                //(08/11/2019-Victor Henrique) Criar objeto para executar o comando
                SqlCommand objCmd = new SqlCommand(varSql, objCon);
                objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_Produto.COD_PRODUTO);
                objCmd.Parameters.AddWithValue("@I_COD_CATEGORIA", aobj_Produto.COD_CATEGORIA);
                objCmd.Parameters.AddWithValue("@S_NM_PRODUTO", aobj_Produto.NM_PRODUTO);
                objCmd.Parameters.AddWithValue("@D_VLV_PRODUTO", aobj_Produto.VLV_PRODUTO);
                objCmd.Parameters.AddWithValue("@D_VLC_PRODUTO", aobj_Produto.VLC_PRODUTO);
                objCmd.Parameters.AddWithValue("@I_NF_PRODUTO", aobj_Produto.NF_PRODUTO);
                try
                {
                    //(13/02/2020-Victor Henrique) Abrir a conexão com o banco de dados
                    objCon.Open();

                    //(13/02/2020-Victor Henrique) Executar o comando
                    objCmd.ExecuteNonQuery();

                    //(13/02/2020-Victor Henrique) fechar a conexão
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
        * Parametros     : Objeto da Classe Produto
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Excluir(Produto aobj_Produto)
        {
            //(13/02/2020-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection ObjCon = new SqlConnection(Connection.ConnectionPath());

            //(13/02/2020-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " DELETE FROM TB_PRODUTO " +
                            " WHERE I_COD_PRODUTO = @I_COD_PRODUTO";

            //(13/02/2020-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, ObjCon);
            objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_Produto.COD_PRODUTO);

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
        * Nome           : FindByCodProduto
        * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
        *                  Método para Buscar um registro na tabela TB_PRODUTO
        * Parametros     : Objeto da Classe Produto
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Produto FindByCodProduto(Produto aobj_Produto)
        {
            //(13/02/2020-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(13/02/2020-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_PRODUTO " +
                            " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            //(13/02/2020-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@I_COD_PRODUTO", aobj_Produto.COD_PRODUTO);

            try
            {
                //(13/02/2020-Victor Henrique) Abrir a conexão com o banco de dados
                objCon.Open();

                //(13/02/2020-Victor Henrique) Criar um objeto DataReader que irá receber os dados
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    //Ler os dados que estão no objeto DataReader 
                    objDtr.Read();

                    //(13/02/2020-Victor Henrique) Recupero os valores (Tipo um Popula Objeto)
                    aobj_Produto.COD_PRODUTO = Convert.ToInt16(objDtr["I_COD_PRODUTO"]);
                    aobj_Produto.COD_CATEGORIA = Convert.ToInt16(objDtr["I_COD_CATEGORIA"]);
                    aobj_Produto.NM_PRODUTO = objDtr["S_NM_PRODUTO"].ToString();
                    aobj_Produto.VLV_PRODUTO = Convert.ToDouble(objDtr["D_VLV_PRODUTO"]);
                    aobj_Produto.VLC_PRODUTO = Convert.ToDouble(objDtr["D_VLC_PRODUTO"]);
                    aobj_Produto.NF_PRODUTO = Convert.ToInt16(objDtr["I_NF_PRODUTO"]);
                }

                objCon.Close();
                objDtr.Close();
                return aobj_Produto;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_Produto;
            }
        }


        /****************************************************************************
        * Nome           : FindAllProduto
        * Procedimento   : Responsável por encontrar todos os Objetos na Base de Dados
        *                   Método para Buscar uma lista de registros 
        * Parametros     : Objeto da Classe Produto
        * Data Criação   : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique(Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public List<Produto> FindAllProduto()
        {
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());
            string varSql = " SELECT * FROM TB_PRODUTO ";
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Produto> aLista = new List<Produto>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Produto aobj_Produto = new Produto();

                        aobj_Produto.COD_PRODUTO = Convert.ToInt16(objDtr["I_COD_PRODUTO"]);
                        aobj_Produto.COD_CATEGORIA = Convert.ToInt16(objDtr["I_COD_CATEGORIA"]);
                        aobj_Produto.NM_PRODUTO = objDtr["S_NM_PRODUTO"].ToString();
                        aobj_Produto.VLV_PRODUTO = Convert.ToDouble(objDtr["D_VLV_PRODUTO"]);
                        aobj_Produto.VLC_PRODUTO = Convert.ToDouble(objDtr["D_VLC_PRODUTO"]);
                        aobj_Produto.NF_PRODUTO = Convert.ToInt16(objDtr["I_NF_PRODUTO"]);

                        aLista.Add(aobj_Produto);

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
