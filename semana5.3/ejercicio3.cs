using System;
using System.Collections.Generic;

class Programa
{
    static void Main()
    {
        List<int> numerosGanadores = new List<int>();

        Console.WriteLine("Introduce 5 números ganadores:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Número {i + 1}: ");
            int numero = int.Parse(Console.ReadLine());
            numerosGanadores.Add(numero);
        }

        numerosGanadores.Sort();

        Console.WriteLine("Números ganadores ordenados:");
        foreach (int numero in numerosGanadores)
        {
            Console.WriteLine(numero);
        }
    }
}

