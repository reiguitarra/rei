﻿using System;
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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(2 , 7));


                Tela.imrpimirTabuleiro(tab);

                Console.ReadKey();
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }
           
        }

        
    }
}
