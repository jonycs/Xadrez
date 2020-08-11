using System;
using Xadrez;

namespace tabuleiro
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez Partida = new PartidaDeXadrez();
                while (!Partida.Terminada == true)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(Partida.tab);
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] PosicoesPossiveis = Partida.tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(Partida.tab, PosicoesPossiveis);
                    
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                    Partida.ExecutaMovimento(origem, destino);
                }

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            
            
        }
    }
}
