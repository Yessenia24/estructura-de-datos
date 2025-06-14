using System;

namespace RegistroEstudiante
{
    // Clase que representa un estudiante
    public class Estudiante
    {
        // Propiedades del estudiante
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; } // Array para manejar múltiples teléfonos

        // Constructor para inicializar el estudiante con sus datos
        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        // Método para mostrar la información del estudiante
        public void MostrarInformacion()
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
            // Definimos un array con tres teléfonos
            string[] telefonosEstudiante = new string[3] { "555-1234", "555-5678", "555-9012" };

            // Creamos un objeto Estudiante con datos de ejemplo
            Estudiante estudiante = new Estudiante(
                id: 1,
                nombres: "Juan",
                apellidos: "Pérez López",
                direccion: "Calle Falsa 123, Ciudad de México",
                telefonos: telefonosEstudiante
            );

            // Mostramos la información del estudiante en consola
            estudiante.MostrarInformacion();

            // Pausa para ver resultados
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
