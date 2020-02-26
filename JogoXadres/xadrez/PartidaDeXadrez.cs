using System;
using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {

        public Tabuleiro Tab { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        public PartidaDeXadrez()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();


            ColocarPecas();
        }


        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.IncrementaQtdMovimento();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.colocarPeca(p, destino);

            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            

        }
        
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();

        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ValidaPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na origem escolhida!");
            }

            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem não é sua!");
            }

            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidaPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("A posição de Destino é inválida!");
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }
        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }
        private void ColocarPecas()
        {

            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

            //Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            //Tab.colocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            //Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            //Tab.colocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            //Tab.colocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());


        }

    }
}
