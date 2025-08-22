using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear conjunto de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add($"Ciudadano {i}");
        }

        // Crear conjunto de 75 vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>();
        for (int i = 1; i <= 75; i++)
        {
            pfizer.Add($"Ciudadano {i}"); // Ejemplo ciudadano 1 a 75
        }

        // Crear conjunto de 75 vacunados con AstraZeneca
        HashSet<string> astrazeneca = new HashSet<string>();
        for (int i = 50; i < 125; i++) // Note que hay solapamiento con Pfizer para simular algunos con ambas vacunas
        {
            astrazeneca.Add($"Ciudadano {i}");
        }

        // Ciudadanos que han recibido ambas dosis (intersección)
        HashSet<string> ambasDosis = new HashSet<string>(pfizer);
        ambasDosis.IntersectWith(astrazeneca);

        // Ciudadanos que solo han recibido Pfizer (diferencia)
        HashSet<string> soloPfizer = new HashSet<string>(pfizer);
        soloPfizer.ExceptWith(astrazeneca);

        // Ciudadanos que solo han recibido AstraZeneca (diferencia)
        HashSet<string> soloAstraZeneca = new HashSet<string>(astrazeneca);
        soloAstraZeneca.ExceptWith(pfizer);

        // Ciudadanos que no se han vacunado (diferencia con la unión de vacunados)
        HashSet<string> vacunados = new HashSet<string>(pfizer);
        vacunados.UnionWith(astrazeneca);

        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunados);

        // Resultados (solo cantidades para no saturar salida)
        Console.WriteLine($"Ciudadanos que no se han vacunado: {noVacunados.Count}");
        Console.WriteLine($"Ciudadanos que han recibido ambas dosis: {ambasDosis.Count}");
        Console.WriteLine($"Ciudadanos que solo han recibido Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Ciudadanos que solo han recibido AstraZeneca: {soloAstraZeneca.Count}");
        
        // Opcional: listar algunos ciudadanos (comentado para evitar salida extensa)
        /*
        Console.WriteLine("\nEjemplo ciudadanos no vacunados:");
        foreach (var c in noVacunados)
            Console.WriteLine(c);
        */
    }
}
