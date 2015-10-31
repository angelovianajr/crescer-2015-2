﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Locadora.Dominio
{
    public class Relatorio
    {
        public string URL { get; private set; }
        public const string URLXML = @"C:\Users\Angelo\Documents\crescer-2015-2\src\modulo-04-c-sharp\TrabalhoLocadora\Locadora\game_store.xml";

        public void ExportarRelatorio(Biblioteca bd)
        {
            string URLRelatorio = @"C:\Users\Angelo\Documents\crescer-2015-2\src\modulo-04-c-sharp\TrabalhoLocadora\Locadora\relatorio.txt";
            string cabecalho = string.Format("{0,30}LOCADORA NUNES GAMES{0,-30}", "");
            string dataTempo = string.Format("{0,-40:dd/MM/yyyy}{0,40:HH:mm:ss}", DateTime.Now);
            string titulo = string.Format("{0,30}Relatório de jogos{0,-30}", "");
            string sepIgual = "================================================================================";
            string cabecColunas = string.Format("ID{0,7}Categoria{0,8}Nome{0,26}Preço{0,9}Disponivel", "");


            using (var writer = new StreamWriter(URLRelatorio, true))
            {
                writer.WriteLine(cabecalho);
                writer.WriteLine(dataTempo);
                writer.WriteLine(titulo);
                writer.WriteLine("");
                writer.WriteLine(sepIgual);
                writer.WriteLine(cabecColunas);
                writer.WriteLine(listarJogos(bd));

            }
        }

        private string DiminuirNome(string nome)
        {
            return nome = nome.Length < 26 ? nome : nome.Substring(0, 22) + "...";
        }

        private string listarJogos(Biblioteca bd)
        {
            
            XElement gameStore = XElement.Load(URLXML);
            var t = gameStore.Elements("jogo").Select(j => j);
            var tc = bd.ConvertXelToJogo(t.ToList());
            string lista = "";
            foreach (var jogo in tc)
            {
                lista += (String.Format("{0,-9}{1,-17}{2,-30}R${3,-14}{4,8}",
                    t.ElementAt(tc.IndexOf(jogo)).Attribute("id").Value,
                    jogo.Categoria.ToString(), DiminuirNome(jogo.Nome),
                    jogo.Preco.ToString(),
                    "SIM")) + Environment.NewLine;
            }
            return lista;
        }

    }
}
