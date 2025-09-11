using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogoBelleza
{
    // Clase que representa un producto de belleza
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        
        public Producto(int id, string nombre, string marca, string categoria, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Marca = marca;
            Categoria = categoria;
            Precio = precio;
            Stock = stock;
        }
        
        public override string ToString()
        {
            return $"{Id}. {Nombre} - {Marca} ({Categoria}) - ${Precio} - Stock: {Stock}";
        }
    }

    public class Catalogo
    {
        private List<Producto> productos;
        
        public Catalogo()
        {
            productos = new List<Producto>();
            InicializarCatalogo();
        }
        
        private void InicializarCatalogo()
        {
            // Productos de cuidado facial
            AgregarProducto(new Producto(1, "Crema Hidratante", "La Roche-Posay", "Cuidado Facial", 25.99m, 15));
            AgregarProducto(new Producto(2, "Serum Vitamina C", "The Ordinary", "Cuidado Facial", 12.50m, 20));
            AgregarProducto(new Producto(3, "Protector Solar FPS 50", "Vichy", "Cuidado Facial", 18.75m, 30));
            
            // Productos de maquillaje
            AgregarProducto(new Producto(4, "Base de Maquillaje", "MAC", "Maquillaje", 32.00m, 12));
            AgregarProducto(new Producto(5, "Paleta de Sombras", "Huda Beauty", "Maquillaje", 45.00m, 8));
            AgregarProducto(new Producto(6, "Labial Matte", "Fenty Beauty", "Maquillaje", 19.99m, 25));
            
            // Productos para el cabello
            AgregarProducto(new Producto(7, "Shampoo Reparador", "Olaplex", "Cuidado Capilar", 28.00m, 18));
            AgregarProducto(new Producto(8, "Aceite Capilar", "Moroccanoil", "Cuidado Capilar", 35.50m, 10));
            AgregarProducto(new Producto(9, "Mascarilla Nutritiva", "Kérastase", "Cuidado Capilar", 22.75m, 14));
            
            // Productos corporales
            AgregarProducto(new Producto(10, "Crema Corporal", "Nivea", "Cuidado Corporal", 8.99m, 40));
            AgregarProducto(new Producto(11, "Exfoliante Corporal", "The Body Shop", "Cuidado Corporal", 15.25m, 22));
            AgregarProducto(new Producto(12, "Aceite de Masaje", "L'Occitane", "Cuidado Corporal", 29.99m, 16));
        }
        
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }
        
        // Búsqueda iterativa por nombre
        public List<Producto> BuscarPorNombre(string nombre)
        {
            List<Producto> resultados = new List<Producto>();
            foreach (var producto in productos)
            {
                if (producto.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    resultados.Add(producto);
                }
            }
            return resultados;
        }
        
        // Búsqueda binaria por ID (iterativa)
        public Producto BuscarPorId(int id)
        {
            // Ordenar por ID para la búsqueda binaria
            var listaOrdenada = productos.OrderBy(p => p.Id).ToList();
            
            int izquierda = 0;
            int derecha = listaOrdenada.Count - 1;
            
            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;
                Producto productoMedio = listaOrdenada[medio];
                
                if (productoMedio.Id == id)
                    return productoMedio;
                else if (productoMedio.Id < id)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }
            
            return null;
        }
        
        // Búsqueda por categoría
        public List<Producto> BuscarPorCategoria(string categoria)
        {
            return productos
                .Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        // Búsqueda por rango de precios
        public List<Producto> BuscarPorPrecio(decimal precioMin, decimal precioMax)
        {
            return productos
                .Where(p => p.Precio >= precioMin && p.Precio <= precioMax)
                .OrderBy(p => p.Precio)
                .ToList();
        }
        
        // Mostrar todos los productos
        public void MostrarTodos()
        {
            Console.WriteLine("\n--- CATÁLOGO COMPLETO ---");
            foreach (var producto in productos.OrderBy(p => p.Categoria).ThenBy(p => p.Nombre))
            {
                Console.WriteLine(producto);
            }
        }
        
        // Mostrar categorías disponibles
        public void MostrarCategorias()
        {
            var categorias = productos.Select(p => p.Categoria).Distinct();
            Console.WriteLine("\n--- CATEGORÍAS DISPONIBLES ---");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"- {categoria}");
            }
        }
        
        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("💄 CATÁLOGO DE PRODUCTOS DE BELLEZA 💅");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Ver catálogo completo");
                Console.WriteLine("2. Buscar por nombre");
                Console.WriteLine("3. Buscar por ID");
                Console.WriteLine("4. Buscar por categoría");
                Console.WriteLine("5. Buscar por precio");
                Console.WriteLine("6. Ver categorías disponibles");
                Console.WriteLine("7. Salir");
                Console.Write("\nSeleccione una opción: ");
                
                string opcion = Console.ReadLine();
                
                switch (opcion)
                {
                    case "1":
                        MostrarTodos();
                        break;
                    case "2":
                        Console.Write("Ingrese nombre a buscar: ");
                        string nombre = Console.ReadLine();
                        var resultadosNombre = BuscarPorNombre(nombre);
                        MostrarResultados(resultadosNombre, $"Resultados para '{nombre}'");
                        break;
                    case "3":
                        Console.Write("Ingrese ID a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            var producto = BuscarPorId(id);
                            if (producto != null)
                                Console.WriteLine($"\n✓ Encontrado: {producto}");
                            else
                                Console.WriteLine("\n✗ Producto no encontrado");
                        }
                        else
                        {
                            Console.WriteLine("\n❌ ID inválido");
                        }
                        break;
                    case "4":
                        Console.Write("Ingrese categoría: ");
                        string categoria = Console.ReadLine();
                        var resultadosCategoria = BuscarPorCategoria(categoria);
                        MostrarResultados(resultadosCategoria, $"Productos en '{categoria}'");
                        break;
                    case "5":
                        Console.Write("Precio mínimo: ");
                        decimal min = decimal.Parse(Console.ReadLine());
                        Console.Write("Precio máximo: ");
                        decimal max = decimal.Parse(Console.ReadLine());
                        var resultadosPrecio = BuscarPorPrecio(min, max);
                        MostrarResultados(resultadosPrecio, $"Productos entre ${min} - ${max}");
                        break;
                    case "6":
                        MostrarCategorias();
                        break;
                    case "7":
                        Console.WriteLine("¡Gracias por usar nuestro catálogo! 💖");
                        return;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
                
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
        
        private void MostrarResultados(List<Producto> resultados, string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ---");
            if (resultados.Count == 0)
            {
                Console.WriteLine("No se encontraron productos");
            }
            else
            {
                foreach (var producto in resultados)
                {
                    Console.WriteLine(producto);
                }
                Console.WriteLine($"\nTotal encontrados: {resultados.Count}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Catalogo catalogo = new Catalogo();
            catalogo.MostrarMenu();
        }
    }
}