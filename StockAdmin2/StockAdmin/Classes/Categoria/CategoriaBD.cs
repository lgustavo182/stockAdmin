/*****************************************************************************
* Nome           : CategoriaBD
* Classe         : Representação da classe que se conecta com o banco através 
*                  da entidade Categoria
* Data  Criação  : 13/11/2020
* Data Alteração : -
* Escrito por    : 
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
    class CategoriaBD
    {
        //12/11/2019 - Victor Henrique - ToDo: criar uma classe de funções gerais (FuncGeral)

        /*****************************************************************************
        * Nome           : Incluir
        * Procedimento   : Responsável por incluir o Objeto na Base de Dados
        *                  Método para inclui um registro na tabela Categoria
        * Parametros     : Objeto da Classe Categoria
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : 
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public int Incluir(Categoria aobj_Categoria)
        {
            //12/11/2019 - Victor Henrique - Criar objeto de conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //12/11/2019 - Victor Henrique - Criar a variável que contém a instrução SQL
            string varSql = "INSERT INTO TB_CATEGORIA " +
                            "(" +
                            " S_TIT_CATEGORIA,  " +
                            " T_DESC_CATEGORIA   " +
                            ")" +
                            "VALUES " +
                            "(" +
                            " @S_TIT_CATEGORIA,  " +
                            " @T_DESC_CATEGORIA   " +
                            "); " +
                            "SELECT ident_current('TB_CATEGORIA') as 'id'";

            //12/11/2019 - Victor Henrique - Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_CATEGORIA", aobj_Categoria.COD_CATEGORIA);
            objCmd.Parameters.AddWithValue("@S_TIT_CATEGORIA", aobj_Categoria.TIT_CATEGORIA);
            objCmd.Parameters.AddWithValue("@T_DESC_CATEGORIA", aobj_Categoria.DESC_CATEGORIA);
            try
            {
                //12/11/2019 - Victor Henrique - Abrir a conexão com o banco de dados
                objCon.Open();

                //12/11/2019 - Victor Henrique - Executar o comando Escalar
                int _id = Convert.ToInt16(objCmd.ExecuteScalar());

                //(12/11/2019-Victor Henrique) fechar a conexão
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
        *                  Método para Alteração de um registro na tabela Categoria
        * Parametros     : Objeto da Classe Categoria
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Alterar(Categoria aobj_Categoria)
        {


            if (aobj_Categoria.COD_CATEGORIA != -1)
            {
                //(08/11/2018-Victor Henrique) Criar objeto de conexão com o banco de dados
                SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

                //(15/06/2018-Victor Henrique) Criar a variável que contém a instrução SQL
                string varSql = "UPDATE TB_CATEGORIA SET " +
                                "I_COD_CATEGORIA = @I_COD_CATEGORIA," +
                                "S_TIT_CATEGORIA = @S_TIT_CATEGORIA, " +
                                "T_DESC_CATEGORIA = @T_DESC_CATEGORIA,  " +
                                "WHERE I_COD_CATEGORIA = @I_COD_CATEGORIA";

                //(08/11/2019-Victor Henrique) Criar objeto para executar o comando
                SqlCommand objCmd = new SqlCommand(varSql, objCon);
                objCmd.Parameters.AddWithValue("@I_COD_CATEGORIA", aobj_Categoria.COD_CATEGORIA);
                objCmd.Parameters.AddWithValue("@S_TIT_CATEGORIA", aobj_Categoria.COD_CATEGORIA);
                objCmd.Parameters.AddWithValue("@T_DESC_CATEGORIA", aobj_Categoria.COD_CATEGORIA);
                try
                {
                    //(12/11/2019-Victor Henrique) Abrir a conexão com o banco de dados
                    objCon.Open();

                    //(12/11/2019-Victor Henrique) Executar o comando
                    objCmd.ExecuteNonQuery();

                    //(12/11/2019-Victor Henrique) fechar a conexão
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
        * Parametros     : Objeto da Classe Categoria
        * Data  Criação  : 12/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Excluir(Categoria aobj_Categoria)
        {
            //(12/11/2019-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection ObjCon = new SqlConnection(Connection.ConnectionPath());

            //(12/11/2019-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " DELETE FROM TB_CATEGORIA " +
                            " WHERE I_COD_CATEGORIA = @I_COD_CATEGORIA";

            //(12/11/2019-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, ObjCon);
            objCmd.Parameters.AddWithValue("@I_COD_CATEGORIA", aobj_Categoria.COD_CATEGORIA);

            try
            {
                //(12/11/2019-Victor Henrique) Abrir a conexão com o banco de dados
                ObjCon.Open();

                //(12/11/2019-Victor Henrique) Executar o comando para excluir o registro
                objCmd.ExecuteNonQuery();

                //(12/11/2019-Victor Henrique) Fechar a conexão com o banco de dados
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
        * Nome           : FindByCodCategoria
        * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
        *                  Método para Buscar um registro na tabela TB_CATEGORIA
        * Parametros     : Objeto da Classe Categoria
        * Data  Criação  : 12/11/2019
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Categoria FindByCodCategoria(Categoria aobj_Categoria)
        {
            //(12/11/2019-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(12/11/2019-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_CATEGORIA " +
                            " WHERE I_COD_CATEGORIA = @I_COD_CATEGORIA ";

            //(12/11/2019-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@I_COD_CATEGORIA", aobj_Categoria.COD_CATEGORIA);

            try
            {
                //(12/11/2019-Victor Henrique) Abrir a conexão com o banco de dados
                objCon.Open();

                //(12/11/2019-Victor Henrique) Criar um objeto DataReader que irá receber os dados
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    //Ler os dados que estão no objeto DataReader 
                    objDtr.Read();

                    //(12/11/2019-Victor Henrique) Recupero os valores (Tipo um Popula Objeto)
                    aobj_Categoria.COD_CATEGORIA = Convert.ToInt16(objDtr["I_COD_CATEGORIA"]);
                    aobj_Categoria.TIT_CATEGORIA = objDtr["S_TIT_CATEGORIA"].ToString();
                    aobj_Categoria.DESC_CATEGORIA = objDtr["T_DESC_CATEGORIA"].ToString();
                }

                objCon.Close();
                objDtr.Close();
                return aobj_Categoria;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_Categoria;
            }
        }


        /****************************************************************************
        * Nome           : FindAllCategoria
        * Procedimento   : Responsável por encontrar todos os Objetos na Base de Dados
        *                   Método para Buscar uma lista de registros 
        * Parametros     : Objeto da Classe Categoria
        * Data Criação   : 12/11/2019
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public List<Categoria> FindAllCategoria()
        {
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());
            string varSql = " SELECT * FROM TB_CATEGORIA ";
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Categoria> aLista = new List<Categoria>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Categoria aobj_Categoria = new Categoria();

                        aobj_Categoria.COD_CATEGORIA = Convert.ToInt16(objDtr["I_COD_CATEGORIA"]);
                        aobj_Categoria.TIT_CATEGORIA = objDtr["S_TIT_CATEGORIA"].ToString();
                        aobj_Categoria.DESC_CATEGORIA = objDtr["T_DESC_CATEGORIA"].ToString();

                        aLista.Add(aobj_Categoria);

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
