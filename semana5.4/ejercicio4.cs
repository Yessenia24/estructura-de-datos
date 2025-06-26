using System;
using System.Collections.Generic;
using System.Linq;

class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }
    public Asignatura(string nombre, double nota)
    {
        Nombre = nombre;
        Nota = nota;
    }
}

class Programa
{
    static void Main()
    {
        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas", 6.5),
            new Asignatura("Física", 4.0),
            new Asignatura("Química", 7.0),
            new Asignatura("Historia", 3.5),
            new Asignatura("Lengua", 8.0)
        };

        asignaturas.RemoveAll(a => a.Nota >= 5);

        Console.WriteLine("Asignaturas que debes repetir:");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"{asignatura.Nombre} con nota {asignatura.Nota}");
        }
    }
}
