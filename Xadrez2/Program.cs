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


                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Black), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Black), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Black), new Posicao(0, 2));
                tab.ColocarPeca(new Torre(tab, Cor.White), new Posicao(3, 5));
                tab.ColocarPeca(new Torre(tab, Cor.White), new Posicao(4, 5));
                tab.ColocarPeca(new Rei(tab, Cor.White), new Posicao(5, 2));

                Tela.ImprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            
            
        }
    }
}
