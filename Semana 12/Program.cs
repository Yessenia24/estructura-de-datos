using System;
using System.Collections.Generic;
using System.Linq;

namespace TorneoFutbol
{
    public class TorneoFutbol
    {
        // Mapa: Dictionary<string, HashSet<string>> para equipos y jugadores
        private Dictionary<string, HashSet<string>> equipos;
        
        // Mapa: Dictionary<string, (int goles, int asistencias)> para estadísticas
        private Dictionary<string, (int goles, int asistencias)> estadisticas;

        public TorneoFutbol()
        {
            equipos = new Dictionary<string, HashSet<string>>();
            estadisticas = new Dictionary<string, (int goles, int asistencias)>();
        }

        public void RegistrarEquipo(string nombreEquipo)
        {
            if (!equipos.ContainsKey(nombreEquipo))
            {
                equipos[nombreEquipo] = new HashSet<string>();
                Console.WriteLine($"Equipo '{nombreEquipo}' registrado con éxito.");
            }
            else
            {
                Console.WriteLine($"El equipo '{nombreEquipo}' ya existe.");
            }
        }

        public void RegistrarJugador(string nombreEquipo, string nombreJugador)
        {
            if (equipos.ContainsKey(nombreEquipo))
            {
                // Verificar si el jugador ya existe en algún equipo
                if (JugadorExisteEnAlgunEquipo(nombreJugador))
                {
                    Console.WriteLine($"Error: El jugador '{nombreJugador}' ya está registrado en otro equipo.");
                    return;
                }

                if (equipos[nombreEquipo].Add(nombreJugador))
                {
                    Console.WriteLine($"Jugador '{nombreJugador}' añadido al equipo '{nombreEquipo}'.");
                }
                else
                {
                    Console.WriteLine($"El jugador '{nombreJugador}' ya está en el equipo '{nombreEquipo}'.");
                }
            }
            else
            {
                Console.WriteLine($"Error: El equipo '{nombreEquipo}' no está registrado.");
            }
        }

        private bool JugadorExisteEnAlgunEquipo(string nombreJugador)
        {
            return equipos.Values.Any(jugadores => jugadores.Contains(nombreJugador));
        }

        public void ConsultarEquipos()
        {
            Console.WriteLine("\n--- Equipos en el Torneo ---");
            if (equipos.Count == 0)
            {
                Console.WriteLine("No hay equipos registrados.");
                return;
            }

            foreach (var equipo in equipos)
            {
                Console.WriteLine($"- {equipo.Key} ({equipo.Value.Count} jugadores)");
            }
        }

        public void ConsultarJugadoresEquipo(string nombreEquipo)
        {
            if (equipos.ContainsKey(nombreEquipo))
            {
                var jugadores = equipos[nombreEquipo];
                Console.WriteLine($"\n--- Jugadores del equipo '{nombreEquipo}' ---");
                
                if (jugadores.Count > 0)
                {
                    foreach (var jugador in jugadores)
                    {
                        Console.WriteLine($"- {jugador}");
                    }
                }
                else
                {
                    Console.WriteLine("El equipo no tiene jugadores registrados.");
                }
            }
            else
            {
                Console.WriteLine($"Error: El equipo '{nombreEquipo}' no está registrado.");
            }
        }

        public void BuscarJugador(string nombreJugador)
        {
            Console.WriteLine($"\n--- Buscando al jugador '{nombreJugador}' ---");
            
            foreach (var equipo in equipos)
            {
                if (equipo.Value.Contains(nombreJugador))
                {
                    Console.WriteLine($"El jugador '{nombreJugador}' pertenece al equipo '{equipo.Key}'.");
                    return;
                }
            }
            
            Console.WriteLine($"El jugador '{nombreJugador}' no se encuentra en ningún equipo.");
        }

        public void RegistrarEstadisticas(string nombreJugador, int goles, int asistencias)
        {
            if (JugadorExisteEnAlgunEquipo(nombreJugador))
            {
                estadisticas[nombreJugador] = (goles, asistencias);
                Console.WriteLine($"Estadísticas actualizadas para '{nombreJugador}': {goles} goles, {asistencias} asistencias.");
            }
            else
            {
                Console.WriteLine($"Error: El jugador '{nombreJugador}' no existe en ningún equipo.");
            }
        }

        public void ConsultarEstadisticas(string nombreJugador)
        {
            if (estadisticas.ContainsKey(nombreJugador))
            {
                var stats = estadisticas[nombreJugador];
                Console.WriteLine($"Estadísticas de '{nombreJugador}': {stats.goles} goles, {stats.asistencias} asistencias.");
            }
            else
            {
                Console.WriteLine($"No se encontraron estadísticas para el jugador '{nombreJugador}'.");
            }
        }

        // Método adicional: Obtener el equipo de un jugador
        public string ObtenerEquipoDeJugador(string nombreJugador)
        {
            foreach (var equipo in equipos)
            {
                if (equipo.Value.Contains(nombreJugador))
                {
                    return equipo.Key;
                }
            }
            return null;
        }

        // Método adicional: Mostrar todas las estadísticas
        public void MostrarTodasEstadisticas()
        {
            Console.WriteLine("\n--- Estadísticas de Todos los Jugadores ---");
            foreach (var stat in estadisticas)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value.goles} goles, {stat.Value.asistencias} asistencias");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TorneoFutbol torneo = new TorneoFutbol();

            // Registro de equipos
            torneo.RegistrarEquipo("Barcelona");
            torneo.RegistrarEquipo("Real Madrid");
            torneo.RegistrarEquipo("Barcelona"); // Intento duplicado

            Console.WriteLine();

            // Registro de jugadores
            torneo.RegistrarJugador("Barcelona", "Messi");
            torneo.RegistrarJugador("Barcelona", "Neymar");
            torneo.RegistrarJugador("Real Madrid", "Benzema");
            torneo.RegistrarJugador("Real Madrid", "Messi"); // Esto fallará

            Console.WriteLine();

            // Consultas
            torneo.ConsultarEquipos();
            torneo.ConsultarJugadoresEquipo("Barcelona");
            torneo.ConsultarJugadoresEquipo("Real Madrid");

            Console.WriteLine();

            // Búsquedas
            torneo.BuscarJugador("Benzema");
            torneo.BuscarJugador("Ronaldo");

            Console.WriteLine();

            // Estadísticas
            torneo.RegistrarEstadisticas("Messi", 25, 10);
            torneo.RegistrarEstadisticas("Benzema", 20, 5);
            torneo.RegistrarEstadisticas("Ronaldo", 15, 8); // Jugador no existente

            Console.WriteLine();

            torneo.ConsultarEstadisticas("Messi");
            torneo.ConsultarEstadisticas("Benzema");
            torneo.ConsultarEstadisticas("Neymar"); // Sin estadísticas

            Console.WriteLine();

            // Métodos adicionales
            string equipoMessi = torneo.ObtenerEquipoDeJugador("Messi");
            Console.WriteLine($"Messi juega en: {equipoMessi}");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}