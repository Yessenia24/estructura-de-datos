using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();

    static void MoverDiscos(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (n == 1)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            MostrarTorres();
            return;
        }

        MoverDiscos(n - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);
        MoverDiscos(1, origen, destino, auxiliar, nombreOrigen, nombreDestino, nombreAuxiliar);
        MoverDiscos(n - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }

    static void MostrarTorres()
    {
        Console.WriteLine("Torre A: " + string.Join(", ", torreA));
        Console.WriteLine("Torre B: " + string.Join(", ", torreB));
        Console.WriteLine("Torre C: " + string.Join(", ", torreC));
        Console.WriteLine();
    }

    static void Main()
    {
        int numDiscos = 3;

        // Inicializar torre A con discos (mayor en el fondo)
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }

        Console.WriteLine("Estado inicial:");
        MostrarTorres();

        MoverDiscos(numDiscos, torreA, torreC, torreB, "A", "C", "B");

        Console.WriteLine("Estado final:");
        MostrarTorres();
    }
}
