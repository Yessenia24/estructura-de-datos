using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    static void Main()
    {
        List<double> precios = new List<double> { 10.5, 20.0, 5.75, 12.3, 8.9 };

        double menor = precios.Min();
        double mayor = precios.Max();

        Console.WriteLine($"Precio menor: {menor}");
        Console.WriteLine($"Precio mayor: {mayor}");
    }
}
