using System;
using System.Collections.Generic;

class TraductorBasico
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"},
        {"person", "persona"},
        {"year", "año"},
        {"way", "camino"},
        {"day", "día"},
        {"thing", "cosa"},
        {"man", "hombre"},
        {"world", "mundo"},
        {"life", "vida"},
        {"hand", "mano"}
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor ingrese un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("Ingrese una frase para traducir: ");
        string frase = Console.ReadLine().ToLower();
        string[] palabras = frase.Split(new char[] { ' ', ',', '.', ';', ':', '-', '!' , '?' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Construir la frase traducida con traducciones parciales
        string fraseTraducida = frase;
        foreach (var palabra in palabras)
        {
            if (diccionario.ContainsKey(palabra))
            {
                // Reemplazamos la palabra original respetando mayúsculas y minúsculas
                fraseTraducida = ReplaceWord(fraseTraducida, palabra, diccionario[palabra]);
            }
        }

        Console.WriteLine("Traducción (parcial): " + fraseTraducida);
    }

    static string ReplaceWord(string texto, string palabraOriginal, string palabraTraducida)
    {
        // Reemplaza la palabra original en el texto considerando que puede aparecer en mayúsculas o minúsculas
        // Se reemplaza respetando la forma original: si la palabra original inicia con mayúscula, la traducción también lo hará
        if (string.IsNullOrEmpty(palabraOriginal)) return texto;

        string traduccionFinal = palabraTraducida;
        if (char.IsUpper(palabraOriginal[0]))
        {
            traduccionFinal = char.ToUpper(palabraTraducida[0]) + palabraTraducida.Substring(1);
        }

        // Solo reemplaza palabras completas (usando delimitadores)
        string[] delimiters = new string[] { " ", ",", ".", ";", ":", "-", "!", "?", "\n", "\r" };
        string[] partes = texto.Split(delimiters, StringSplitOptions.None);
        for (int i = 0; i < partes.Length; i++)
        {
            if (string.Equals(partes[i], palabraOriginal, StringComparison.OrdinalIgnoreCase))
            {
                partes[i] = traduccionFinal;
            }
        }
        return string.Join(" ", partes);
    }

    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string palabraIngles = Console.ReadLine().ToLower();
        Console.Write("Ingrese la palabra en español: ");
        string palabraEspanol = Console.ReadLine().ToLower();

        if (diccionario.ContainsKey(palabraIngles))
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
        else
        {
            diccionario.Add(palabraIngles, palabraEspanol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
    }
}
