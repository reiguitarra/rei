﻿using System;
using tabuleiro;

namespace JogoXadres
{
    class Tela
    {
        public static void imrpimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.Peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.Peca(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
