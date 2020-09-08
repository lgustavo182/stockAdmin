using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_UC10
{
    class Categoria
    {
        //(Gabriel Prado - 12/02/2020) Metodo de Destruição da Classe
        ~Categoria()
        {
        }

        //(Gabriel Prado - 12/02/2019) Atributos/Propriedades Privadas Encapsuladas
        int VCOD_CATEGORIA = -1;
        string VTIT_CATEGORIA = null;
        string VDESC_CATEGORIA = null;

        //(Gabriel Prado - 12/02/2019) Metodos Públicos

        /***********************************************************************
        * NOME:            COD_CATEGORIA     
        * METODO:          Representação do atributo Código da categoria com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public int COD_CATEGORIA
        {
            get { return VCOD_CATEGORIA; }
            set { VCOD_CATEGORIA = value; }
        }


        /***********************************************************************
        * NOME:            TIT_CATEGORIA     
        * METODO:          Representação do atributo Titulo da Categoria com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public string TIT_CATEGORIA
        {
            get { return VTIT_CATEGORIA; }
            set { VTIT_CATEGORIA = value; }
        }


        /***********************************************************************
        * NOME:            DESC_CATEGORIA     
        * METODO:          Representação do atributo Descrição da Categoria com os métodos 
        *                  Get e Set          
        * DT CRIAÇÃO:      12/02/2019    
        * DT ALTERAÇÃO:    -
        * ESCRITA POR:     Gabriel Prado
        **********************************************************************/
        public string DESC_CATEGORIA
        {
            get { return VDESC_CATEGORIA; }
            set { VDESC_CATEGORIA = value; }
        }

    }
}
