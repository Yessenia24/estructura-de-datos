using System;

class Nodo
{
    public int dato;
    public Nodo siguiente;
    public Nodo(int d) { dato = d; siguiente = null; }
}

class ListaEnlazada
{
    public Nodo cabeza;

    public void Agregar(int valor)
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

    public int Contar()
    {
        int count = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            count++;
            actual = actual.siguiente;
        }
        return count;
    }

    public bool EsIgual(ListaEnlazada otra)
    {
        Nodo actual1 = this.cabeza;
        Nodo actual2 = otra.cabeza;

        while (actual1 != null && actual2 != null)
        {
            if (actual1.dato != actual2.dato)
                return false;
            actual1 = actual1.siguiente;
            actual2 = actual2.siguiente;
        }
        // Si ambas son null, son iguales en tamaño y contenido
        return actual1 == null && actual2 == null;
    }
}

class Programa
{
    static void Main()
    {
        ListaEnlazada lista1 = new ListaEnlazada();
        ListaEnlazada lista2 = new ListaEnlazada();

        Console.Write("Cantidad de elementos para lista 1: ");
        int n1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los elementos de lista 1:");
        for (int i = 0; i < n1; i++)
        {
            int val = int.Parse(Console.ReadLine());
            lista1.Agregar(val);
        }

        Console.Write("Cantidad de elementos para lista 2: ");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese los elementos de lista 2:");
        for (int i = 0; i < n2; i++)
        {
            int val = int.Parse(Console.ReadLine());
            lista2.Agregar(val);
        }

        if (lista1.Contar() == lista2.Contar())
        {
            if (lista1.EsIgual(lista2))
                Console.WriteLine("Las listas son iguales en tamaño y contenido.");
            else
                Console.WriteLine("Las listas son iguales en tamaño pero no en contenido.");
        }
        else
        {
            Console.WriteLine("Las listas no tienen el mismo tamaño ni contenido.");
        }
    }
}
