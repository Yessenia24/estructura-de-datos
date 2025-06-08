Yessenia
********************
Practica
*******************
using System;

namespace FigurasGeometricas
{
    public class Cuadrado
    {
        private double lado;

        public Cuadrado(double lado)
        {
            if (lado <= 0)
                throw new ArgumentException("El lado debe ser un número positivo.");
            this.lado = lado;
        }

        public double CalcularArea() => lado * lado;

        public double CalcularPerimetro() => 4 * lado;

        public void MostrarInformacion()
        {
            Console.WriteLine("Cuadrado:");
            Console.WriteLine($"Lado: {lado}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }

    public class Pentagono
    {
        private double lado;

        public Pentagono(double lado)
        {
            if (lado <= 0)
                throw new ArgumentException("El lado debe ser un número positivo.");
            this.lado = lado;
        }

        public double CalcularArea() => (5 * lado * lado) / (4 * Math.Tan(Math.PI / 5));

        public double CalcularPerimetro() => 5 * lado;

        public void MostrarInformacion()
        {
            Console.WriteLine("Pentágono:");
            Console.WriteLine($"Lado: {lado}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cuadrado cuadrado = new Cuadrado(4);
                cuadrado.MostrarInformacion();

                Console.WriteLine();

                Pentagono pentagono = new Pentagono(3);
                pentagono.MostrarInformacion();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

