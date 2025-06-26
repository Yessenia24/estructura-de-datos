using System;
using System.Collections.Generic;

class Asignatura
{
    public string Nombre { get; set; }
    public double Nota { get; set; }
    public Asignatura(string nombre) { Nombre = nombre; }
}

class Programa
{
    static void Main()
    {
        List<Asignatura> asignaturas = new List<Asignatura>
        {
            new Asignatura("Matemáticas"),
            new Asignatura("Física"),
            new Asignatura("Química"),
            new Asignatura("Historia"),
            new Asignatura("Lengua")
        };

        foreach (var asignatura in asignaturas)
        {
            Console.Write($"Introduce la nota de {asignatura.Nombre}: ");
            asignatura.Nota = double.Parse(Console.ReadLine());
        }

        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"En {asignatura.Nombre} has sacado {asignatura.Nota}");
        }
    }
}
