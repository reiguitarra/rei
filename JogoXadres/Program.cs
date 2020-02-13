using System;
using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.imrpimirTabuleiro(partida.Tab);
                    Console.WriteLine();
                    

                    
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] PosPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.imrpimirTabuleiro(partida.Tab, PosPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.RealizaJogada(origem, destino);


                }
                

                

                Console.ReadKey();
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }
           
        }

        
    }
}
