using System;
using Xadrez;

namespace tabuleiro
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosicao());


            try
            {


                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Black), new Posicao(0, 3));
                tab.ColocarPeca(new Torre(tab, Cor.Black), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Black), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Black), new Posicao(2, 4));


                Tela.ImprimirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            
            
        }
    }
}
