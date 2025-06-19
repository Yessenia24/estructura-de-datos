using System;
using System.Collections.Generic;

namespace AgendaTelefonica
{
    // Definimos la estructura Contacto
    public struct Contacto
    {
        public string Nombre;
        public string Telefono;

        public Contacto(string nombre, string telefono)
        {
            Nombre = nombre;
            Telefono = telefono;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear lista de contactos con los datos iniciales
            List<Contacto> agenda = new List<Contacto>
            {
                new Contacto("Keiko Yanacallo", "0959114684"),
                new Contacto("Estefania Torres", "0982521271")
            };

            // Mostrar contactos
            Console.WriteLine("Agenda Telefónica:");
            foreach (var contacto in agenda)
            {
                Console.WriteLine($"Nombre: {contacto.Nombre}, Teléfono: {contacto.Telefono}");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
