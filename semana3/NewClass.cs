using System;

namespace RegistroEstudiante
{
    // Definición de la clase Estudiante
    class Estudiante
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } = new string[3]; // Array para 3 teléfonos

        // Constructor para inicializar el estudiante
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            if (telefonos.Length == 3)
            {
                Telefonos = telefonos;
            }
            else
            {
                throw new ArgumentException("Debe proporcionar exactamente 3 teléfonos.");
            }
        }

        // Método para mostrar la información del estudiante
        public void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear un array con los teléfonos
            string[] telefonos = { "555-1234", "555-5678", "555-9012" };

            // Crear un objeto Estudiante
            Estudiante estudiante = new Estudiante(1, "Juan", "Pérez", "Calle Falsa 123", telefonos);

            // Mostrar la información del estudiante
            estudiante.MostrarInfo();

            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
