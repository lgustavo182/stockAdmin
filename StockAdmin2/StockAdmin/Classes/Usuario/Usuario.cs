using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_UC10
{
    class Usuario
    {
        //(Mfacine - 12/02/2020) Metodo de Destruição da Classe
        ~Usuario()
        {
        }

        //(Mfacine - 12/02/2020) Atributos/Propriedades Privadas Encapsuladas
        int VCOD_USUARIO = -1;
        string VLOG_USUARIO = null;
        string VPASS_USUARIO = null;
        int VLEV_USUARIO = -1;
     

        //(Mfacine - 12/02/2020) Metodos Públicos

        /***********************************************************************
        * NOME:            COD_USUARIO     
        * METODO:          Representação do atributo Código com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020       
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public int COD_USUARIO
        {
            get { return VCOD_USUARIO; }
            set { VCOD_USUARIO = value; }
        }

        /***********************************************************************
        * NOME:            LOG_USUARIO     
        * METODO:          Representação do atributo Titulo com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020     
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public string LOG_USUARIO
        {
            get { return VLOG_USUARIO; }
            set { VLOG_USUARIO = value; }
        }


        /***********************************************************************
        * NOME:            PASS_USUARIO     
        * METODO:          Representação do atributo descrição com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020       
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public string PASS_USUARIO
        {
            get { return VPASS_USUARIO; }
            set { VPASS_USUARIO = value; }
        }

        /***********************************************************************
        * NOME:            LEV_USUARIO     
        * METODO:          Representação do atributo descrição com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public int LEV_USUARIO
        {
            get { return VLEV_USUARIO; }
            set { VLEV_USUARIO = value; }

        }

        /***********************************************************************
       * NOME:            NM_USUARIO     
       * METODO:          Representação do atributo descrição com os métodos 
       *                  Get e Set          
       * DT CRIAÇÃO:      14/02/2020    
       * DT ALTERAÇÃO:    -
       * ESCRITA POR:     Victor Henrique Martins
       **********************************************************************/
     
    }
}