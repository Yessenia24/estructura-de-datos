using System;
using System.Collections.Generic;

class Asignatura
{
    public string Nombre { get; set; }
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
            Console.WriteLine($"Yo estudio {asignatura.Nombre}");
        }
    }
}
