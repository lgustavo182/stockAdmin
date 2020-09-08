/*****************************************************************************
* Nome           : UsuarioBD
* Classe         : Representação da classe que se conecta com o banco através 
*                  da entidade Usuario
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
    class UsuarioBD
    {
        //13/02/2020 - Victor Henrique - ToDo: criar uma classe de funções gerais (FuncGeral)

        /*****************************************************************************
        * Nome           : Incluir
        * Procedimento   : Responsável por incluir o Objeto na Base de Dados
        *                  Método para inclui um registro na tabela Usuario
        * Parametros     : Objeto da Classe Usuario
        * Data  Criação  : 05/11/2019
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public int Incluir(Usuario aobj_Usuario)
        {
            //13/02/2020 - Victor Henrique - Criar objeto de conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //13/02/2020 - Victor Henrique - Criar a variável que contém a instrução SQL
            string varSql = "INSERT INTO TB_USUARIO " +
                            "(" +
                            " S_LOG_USUARIO,   " +
                            " S_PASS_USUARIO,   " +
                            " I_LEV_USUARIO   " +
                            ")" +
                            "VALUES " +
                            "(" +
                            " @S_LOG_USUARIO,   " +
                            " @S_PASS_USUARIO,   " +
                            " @I_LEV_USUARIO   " +
                            "); " +
                            "SELECT ident_current('TB_USUARIO') as 'id'";

            //13/02/2020 - Victor Henrique - Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);

            objCmd.Parameters.AddWithValue("@I_COD_USUARIO", aobj_Usuario.COD_USUARIO);
            objCmd.Parameters.AddWithValue("@S_LOG_USUARIO", aobj_Usuario.LOG_USUARIO);
            objCmd.Parameters.AddWithValue("@S_PASS_USUARIO", aobj_Usuario.PASS_USUARIO);
            objCmd.Parameters.AddWithValue("@I_LEV_USUARIO", aobj_Usuario.LEV_USUARIO);
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
        *                  Método para Alteração de um registro na tabela Usuario
        * Parametros     : Objeto da Classe Usuario
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Alterar(Usuario aobj_Usuario)
        {


            if (aobj_Usuario.COD_USUARIO != -1)
            {
                //(08/11/2018-Victor Henrique) Criar objeto de conexão com o banco de dados
                SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

                //(15/06/2018-Victor Henrique) Criar a variável que contém a instrução SQL
                string varSql = "UPDATE TB_USUARIO SET " +
                                "I_COD_USUARIO = @I_COD_USUARIO," +
                                "S_LOG_USUARIO = @S_LOG_USUARIO,  " +
                                "S_PASS_USUARIO = @S_PASS_USUARIO,  " +
                                "I_LEV_USUARIO = @I_LEV_USUARIO  " +
                                "WHERE I_COD_USUARIO = @I_COD_USUARIO";

                //(08/11/2019-Victor Henrique) Criar objeto para executar o comando
                SqlCommand objCmd = new SqlCommand(varSql, objCon);
                objCmd.Parameters.AddWithValue("@I_COD_USUARIO", aobj_Usuario.COD_USUARIO);
                objCmd.Parameters.AddWithValue("@S_LOG_USUARIO", aobj_Usuario.LOG_USUARIO);
                objCmd.Parameters.AddWithValue("@S_PASS_USUARIO", aobj_Usuario.PASS_USUARIO);
                objCmd.Parameters.AddWithValue("@I_LEV_USUARIO", aobj_Usuario.LEV_USUARIO);
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
        * Parametros     : Objeto da Classe Usuario
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Boolean Excluir(Usuario aobj_Usuario)
        {
            //(13/02/2020-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection ObjCon = new SqlConnection(Connection.ConnectionPath());

            //(13/02/2020-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " DELETE FROM TB_USUARIO " +
                            " WHERE I_COD_USUARIO = @I_COD_USUARIO";

            //(13/02/2020-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, ObjCon);
            objCmd.Parameters.AddWithValue("@I_COD_USUARIO", aobj_Usuario.COD_USUARIO);

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
      * Nome           : FindByLogUsuario
      * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
      *                  Método para Buscar um registro na tabela TB_USUARIO
      * Parametros     : Objeto da Classe Usuario
      * Data  Criação  : 12/11/2018
      * Data Alteração : -
      * Escrito por    : Mfacine (Monstro)
      * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
      * ***************************************************************************/
        public Usuario FindByLogUsuario(Usuario aobj_Usuario)
        {
            //(12/11/2018-Mfacine) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(12/11/2018-Mfacine) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_USUARIO " +
                            " WHERE S_LOG_USUARIO = @S_LOG_USUARIO ";

            //(12/11/2018-Mfacine) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@S_LOG_USUARIO", aobj_Usuario.LOG_USUARIO);

            try
            {
                //(12/11/2018-Mfacine) Abrir a conexão com o banco de dados
                objCon.Open();

                //(12/11/2018-Mfacine) Criar um objeto DataReader que irá receber os dados
                SqlDataReader objDtr = objCmd.ExecuteReader();

                if (objDtr.HasRows)
                {
                    //Ler os dados que estão no objeto DataReader 
                    objDtr.Read();

                    //(12/11/2018-mfacine) Recupero os valores (Tipo um Popula Objeto)

                    aobj_Usuario.COD_USUARIO = Convert.ToInt16(objDtr["I_COD_USUARIO"]);
                    aobj_Usuario.LOG_USUARIO = objDtr["S_LOG_USUARIO"].ToString();
                    aobj_Usuario.PASS_USUARIO = objDtr["S_PASS_USUARIO"].ToString();
                    aobj_Usuario.LEV_USUARIO = Convert.ToInt16(objDtr["I_LEV_USUARIO"]);

                }
                else
                {
                    aobj_Usuario.LOG_USUARIO = "";
                }

                objCon.Close();
                objDtr.Close();
                return aobj_Usuario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_Usuario;
            }
        }

        /*****************************************************************************
        * Nome           : FindByCodUsuario
        * Procedimento   : Responsável por encontrar o Objeto na Base de Dados
        *                  Método para Buscar um registro na tabela TB_USUARIO
        * Parametros     : Objeto da Classe Usuario
        * Data  Criação  : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public Usuario FindByCodUsuario(Usuario aobj_Usuario)
        {
            //(13/02/2020-Victor Henrique) Criar objeto para conexão com o banco de dados
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());

            //(13/02/2020-Victor Henrique) Criar uma váriavel que contém a instrução SQL
            string varSql = " SELECT * FROM TB_USUARIO " +
                            " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            //(13/02/2020-Victor Henrique) Criar objeto para executar o comando
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            objCmd.Parameters.AddWithValue("@I_COD_USUARIO", aobj_Usuario.COD_USUARIO);

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
                    aobj_Usuario.COD_USUARIO = Convert.ToInt16(objDtr["I_COD_USUARIO"]);
                    aobj_Usuario.LOG_USUARIO = objDtr["S_LOG_USUARIO"].ToString();
                    aobj_Usuario.PASS_USUARIO = objDtr["S_PASS_USUARIO"].ToString();
                    aobj_Usuario.LEV_USUARIO = Convert.ToInt16(objDtr["I_LEV_USUARIO"]);

                }

                objCon.Close();
                objDtr.Close();
                return aobj_Usuario;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return aobj_Usuario;
            }
        }


        /****************************************************************************
        * Nome           : FindAllUsuario
        * Procedimento   : Responsável por encontrar todos os Objetos na Base de Dados
        *                   Método para Buscar uma lista de registros 
        * Parametros     : Objeto da Classe Usuario
        * Data Criação   : 13/02/2020
        * Data Alteração : -
        * Escrito por    : Victor Henrique(Monstro)
        * Observações    : Utiliza a Classe Connection para acessar o Base de Dados
        * ***************************************************************************/
        public List<Usuario> FindAllUsuario()
        {
            SqlConnection objCon = new SqlConnection(Connection.ConnectionPath());
            string varSql = " SELECT * FROM TB_USUARIO ";
            SqlCommand objCmd = new SqlCommand(varSql, objCon);
            try
            {
                objCon.Open();
                SqlDataReader objDtr = objCmd.ExecuteReader();

                List<Usuario> aLista = new List<Usuario>();

                if (objDtr.HasRows)
                {
                    while (objDtr.Read())
                    {
                        Usuario aobj_Usuario = new Usuario();

                        aobj_Usuario.COD_USUARIO = Convert.ToInt16(objDtr["I_COD_USUARIO"]);
                        aobj_Usuario.LOG_USUARIO = objDtr["S_LOG_USUARIO"].ToString();
                        aobj_Usuario.PASS_USUARIO = objDtr["S_PASS_USUARIO"].ToString();
                        aobj_Usuario.LEV_USUARIO = Convert.ToInt16(objDtr["I_LEV_USUARIO"]);

                        aLista.Add(aobj_Usuario);

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
