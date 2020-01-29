using System;
using tabuleiro;

namespace JogoXadrez
{
    class Tela
    {
        public static void imrpimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " "  );
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

            Console.Write("  a b c d e f g h");
        }
    }
}
