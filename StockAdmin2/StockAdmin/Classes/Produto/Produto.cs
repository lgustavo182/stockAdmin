using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_UC10
{
    class Produto
    {
        //(Gabriel Prado - 12/02/2020) Metodo de Destruição da Classe
        ~Produto()
        {
        }

        //(Gabriel Prado - 12/02/2020) Atributos/Propriedades Privadas Encapsuladas
        int VCOD_PRODUTO = -1;
        int VCOD_CATEGORIA = -1;
        string VNM_PRODUTO = null;
        double VVLV_PRODUTO = -1;
        double VVLC_PRODUTO = -1;
        int VNF_PRODUTO = -1;

        //(Gabriel Prado - 12/02/2020) Metodos Públicos

        /***********************************************************************
        * NOME:            COD_PRODUTO     
        * METODO:          Representação do atributo Código do Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public int COD_PRODUTO
        {
            get { return VCOD_PRODUTO; }
            set { VCOD_PRODUTO = value; }
        }

        /***********************************************************************
        * NOME:            COD_CATEGORIA    
        * METODO:          Representação do atributo Código da Categoria com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public int COD_CATEGORIA
        {
            get { return VCOD_CATEGORIA; }
            set { VCOD_CATEGORIA = value; }
        }


        /***********************************************************************
        * NOME:            NM_PRODUTO     
        * METODO:          Representação do atributo Nome do Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public string NM_PRODUTO
        {
            get { return VNM_PRODUTO; }
            set { VNM_PRODUTO = value; }
        }


        /***********************************************************************
        * NOME:            NM_PRODUTO     
        * METODO:          Representação do atributo Valor de Venda do Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public double VLV_PRODUTO
        {
            get { return VVLV_PRODUTO; }
            set { VVLV_PRODUTO = value; }
        }


        /***********************************************************************
        * NOME:            VLC_PRODUTO    
        * METODO:          Representação do atributo Valor de Custo do Produto com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public double VLC_PRODUTO
        {
            get { return VVLC_PRODUTO; }
            set { VVLC_PRODUTO = value; }
        }


        /***********************************************************************
        * NOME:            NF_PRODUTO   
        * METODO:          Representação do atributo Tamanho com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2020    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public int NF_PRODUTO
        {
            get { return VNF_PRODUTO; }
            set { VNF_PRODUTO = value; }
        }

    }
}

