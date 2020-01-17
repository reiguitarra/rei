using System;
using tabuleiro;

namespace JogoXadres
{
    class Program
    {
        static void Main(string[] args)
        {

            Tabuleiro tab = new Tabuleiro(8, 8);


            Tela.imrpimirTabuleiro(tab);

            Console.ReadKey();
        }

        
    }
}
