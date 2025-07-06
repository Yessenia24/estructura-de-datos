using System;

class Nodo
{
    public double dato;
    public Nodo siguiente;
    public Nodo(double d) { dato = d; siguiente = null; }
}

class ListaEnlazada
{
    public Nodo cabeza;

    public void Agregar(double valor)
    {
        if (cabeza == null)
            cabeza = new Nodo(valor);
        else
        {
            Nodo actual = cabeza;
            while (actual.siguiente != null)
                actual = actual.siguiente;
            actual.siguiente = new Nodo(valor);
        }
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;
        }
        Console.WriteLine();
    }

    public int Contar()
    {
        int c = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            c++;
            actual = actual.siguiente;
        }
        return c;
    }

    public double Sumar()
    {
        double suma = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            suma += actual.dato;
            actual = actual.siguiente;
        }
        return suma;
    }
}

class Programa
{
    static void Main()
    {
        var lista = new ListaEnlazada();

        Console.Write("Cantidad de datos: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese los datos:");
        for (int i = 0; i < n; i++)
            lista.Agregar(double.Parse(Console.ReadLine()));

        double promedio = lista.Sumar() / lista.Contar();

        var menoresIguales = new ListaEnlazada();
        var mayores = new ListaEnlazada();

        Nodo actual = lista.cabeza;
        while (actual != null)
        {
            if (actual.dato <= promedio)
                menoresIguales.Agregar(actual.dato);
            else
                mayores.Agregar(actual.dato);
            actual = actual.siguiente;
        }

        Console.WriteLine("\nLista original:");
        lista.Mostrar();

        Console.WriteLine($"Promedio: {promedio}");

        Console.WriteLine("Datos <= promedio:");
        menoresIguales.Mostrar();

        Console.WriteLine("Datos > promedio:");
        mayores.Mostrar();
    }
}

