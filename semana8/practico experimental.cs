using System;
using System.Collections.Generic;

public class Persona
{
    public string Nombre { get; set; }
    public int AsientoAsignado { get; set; } = -1;

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

public class Atraccion
{
    private Queue<Persona> colaEspera = new Queue<Persona>();
    private int totalAsientos = 30;
    private int asientosAsignados = 0;

    public void EncolarPersona(Persona p)
    {
        if (asientosAsignados < totalAsientos)
        {
            colaEspera.Enqueue(p);
            Console.WriteLine($"Persona {p.Nombre} en cola.");
        }
        else
        {
            Console.WriteLine("No hay más asientos disponibles.");
        }
    }

    public void AsignarAsiento()
    {
        if (colaEspera.Count > 0 && asientosAsignados < totalAsientos)
        {
            Persona p = colaEspera.Dequeue();
            p.AsientoAsignado = ++asientosAsignados;
            Console.WriteLine($"Asiento {p.AsientoAsignado} asignado a {p.Nombre}");
        }
        else
        {
            Console.WriteLine("No hay personas en cola o no hay asientos disponibles.");
        }
    }

    public void MostrarCola()
    {
        Console.WriteLine("Personas en cola:");
        foreach (var persona in colaEspera)
        {
            Console.WriteLine(persona.Nombre);
        }
    }
}

class Program
{
    static void Main()
    {
        Atraccion atraccion = new Atraccion();

        // Simulación de llegada de personas
        atraccion.EncolarPersona(new Persona("Keiko"));
        atraccion.EncolarPersona(new Persona("Adrian"));
        atraccion.EncolarPersona(new Persona("Liam"));
        atraccion.EncolarPersona(new Persona("Yessenia"));
        
        atraccion.MostrarCola();

        // Asignar asientos en orden
        atraccion.AsignarAsiento();
        atraccion.AsignarAsiento();

        atraccion.MostrarCola();
    }
}
