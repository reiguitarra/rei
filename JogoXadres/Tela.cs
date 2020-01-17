﻿using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace JogoXadres
{
    class Tela
    {
        public static void imrpimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.WriteLine(tab.peca(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
