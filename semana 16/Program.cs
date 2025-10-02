using System;
using System.Collections.Generic;
using System.Linq;

// Clase principal para modelar el grafo y aplicar Dijkstra
public class GrafoVuelos
{
    // Diccionario para simular la base de datos de vuelos: Origen -> Lista de (Destino, Costo)
    private Dictionary<string, List<(string Destino, int Costo)>> adjacencias = new Dictionary<string, List<(string Destino, int Costo)>>();

    public GrafoVuelos()
    {
        // Base de datos de vuelos ficticia (Ciudad A -> Ciudad B, Costo)
        AgregarVuelo("Lima", "Bogotá", 300);
        AgregarVuelo("Lima", "Santiago", 450);
        AgregarVuelo("Bogotá", "Santiago", 200);
        AgregarVuelo("Bogotá", "Miami", 600);
        AgregarVuelo("Santiago", "Buenos Aires", 150);
        AgregarVuelo("Buenos Aires", "Madrid", 1200);
        AgregarVuelo("Miami", "Madrid", 900);
        AgregarVuelo("Santiago", "Lima", 400); // Vuelo de vuelta con costo diferente
    }

    // Método para construir el grafo
    public void AgregarVuelo(string origen, string destino, int costo)
    {
        if (!adjacencias.ContainsKey(origen))
            adjacencias[origen] = new List<(string, int)>();

        adjacencias[origen].Add((destino, costo));

        // Asegurarse de que las ciudades sin salidas tengan una entrada vacía para Dijkstra
        if (!adjacencias.ContainsKey(destino))
            adjacencias[destino] = new List<(string, int)>();
    }

    // Algoritmo de Dijkstra para encontrar la ruta de menor costo
    public (List<string> Ruta, int CostoTotal) EncontrarVueloMasBarato(string origen, string destino)
    {
        // 1. Inicialización
        var distancias = new Dictionary<string, int>();
        var previos = new Dictionary<string, string>();
        var noVisitados = new SortedSet<(int Costo, string Ciudad)>(); // Usado como Min-Heap

        foreach (var ciudad in adjacencias.Keys)
        {
            distancias[ciudad] = int.MaxValue;
            previos[ciudad] = null;
        }

        distancias[origen] = 0;
        noVisitados.Add((0, origen));

        // 2. Ejecución del Algoritmo
        while (noVisitados.Count > 0)
        {
            var actual = noVisitados.Min;
            noVisitados.Remove(actual);
            string u = actual.Ciudad;
            int costoU = actual.Costo;

            if (u == destino) break;
            if (costoU == int.MaxValue) continue;

            // Explorar vecinos
            if (adjacencias.ContainsKey(u))
            {
                foreach (var (v, peso) in adjacencias[u])
                {
                    int nuevoCosto = costoU + peso;
                    if (nuevoCosto < distancias[v])
                    {
                        // Actualizar la distancia y el nodo previo
                        noVisitados.Remove((distancias[v], v)); // Quitar el viejo valor
                        distancias[v] = nuevoCosto;
                        previos[v] = u;
                        noVisitados.Add((nuevoCosto, v)); // Agregar el nuevo valor
                    }
                }
            }
        }

        // 3. Reconstrucción de la Ruta
        var ruta = new List<string>();
        string paso = destino;
        int costoFinal = distancias.ContainsKey(destino) ? distancias[destino] : -1;

        if (costoFinal == int.MaxValue || costoFinal == -1)
            return (new List<string> { "Ruta no encontrada" }, -1);

        while (paso != null)
        {
            ruta.Add(paso);
            if (!previos.ContainsKey(paso)) break; // Evita error si el origen no está en previos
            paso = previos[paso];
        }
        ruta.Reverse();
        return (ruta, costoFinal);
    }

    // Método de reportería para mostrar la estructura
    public void MostrarEstructura()
    {
        Console.WriteLine("\n--- REPORTERÍA: ESTRUCTURA DEL GRAFO DE VUELOS ---");
        Console.WriteLine($"Total de Ciudades/Nodos: {adjacencias.Keys.Count}");
        Console.WriteLine("-------------------------------------------------");

        foreach (var origen in adjacencias.Keys.OrderBy(k => k))
        {
            Console.Write($"Ciudad Origen: {origen} (Nodos Adyacentes):");
            if (adjacencias[origen].Any())
            {
                Console.WriteLine();
                foreach (var vuelo in adjacencias[origen])
                {
                    Console.WriteLine($"  -> Vuelo a {vuelo.Destino}, Costo: {vuelo.Costo}");
                }
            }
            else
            {
                Console.WriteLine(" No hay salidas directas.");
            }
        }
        Console.WriteLine("-------------------------------------------------");
    }
}

// Clase para la ejecución
public class Ejecucion
{
    public static void Main(string[] args)
    {
        GrafoVuelos vuelos = new GrafoVuelos();
        string origen = "Lima";
        string destino = "Madrid";

        // 1. Mostrar Reportería de la Estructura
        vuelos.MostrarEstructura();

        // 2. Ejecutar Búsqueda de Vuelos
        var (ruta, costo) = vuelos.EncontrarVueloMasBarato(origen, destino);

        // 3. Mostrar Resultados
        Console.WriteLine($"\n--- RESULTADOS DE LA BÚSQUEDA ---");
        Console.WriteLine($"Ruta de Vuelo más barata de {origen} a {destino}:");
        if (costo != -1)
        {
            Console.WriteLine($"Ruta: {string.Join(" -> ", ruta)}");
            Console.WriteLine($"Costo Total: {costo}");
        }
        else
        {
            Console.WriteLine("No se encontró una ruta de vuelo.");
        }
    }
}
