using tabuleiro;

namespace Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null 
                && p is Torre 
                && p.Cor == Cor 
                && p.QtdMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //ACIMA
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //ABAIXO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //ESQUERDA
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna -1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //DIREITA
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //NE
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //SE
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //SO
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //NO
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            //JOGADA ESPECIAL ROQUE
            if(QtdMovimentos == 0 && !Partida.Xeque)
            {
                //ROQUE PEQUENO
                Posicao PosT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if(TesteTorreParaRoque(PosT1))
                {
                    Posicao P1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao P2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if(Tab.Peca(P1) == null && Tab.Peca(P2)==null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                //ROQUE GRANDE
                Posicao PosT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if (TesteTorreParaRoque(PosT2))
                {
                    Posicao P1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao P2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao P3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                    if (Tab.Peca(P1) == null && Tab.Peca(P2) == null && Tab.Peca(P3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 3] = true;
                    }
                }
            }

            return mat;
        }
    }
}
