using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJETO_UC10
{
    class Connection
    {
        //05/11/2019 - Luis Gustavo de Almeida Monteiro - Metodo da classe que retorna o caminho da conexão
        public static string ConnectionPath()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\PROJETOS\StockAdmin - VERSÃO FINAL\StockAdmin2\StockAdmin\PROJETO UC10.mdf;Integrated Security=True; Connect Timeout = 30";
        }
    }
}
