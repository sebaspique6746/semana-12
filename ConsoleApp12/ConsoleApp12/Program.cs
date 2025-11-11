using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libreria miLibreria = new Libreria();
            bool salir = false;
            string opcion;

            while (!salir)
            {
                MostrarMenu();
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        miLibreria.Registrar();
                        break;
                    case "2":
                        miLibreria.Mostrar();
                        break;
                    case "3":
                        miLibreria.Modificar();
                        break;
                    case "4":
                        miLibreria.Eliminar();
                        break;
                    case "5":
                        salir = true;
                        Console.WriteLine(" Saliendo del sistema. ¡Adiós!");
                        break;
                    default:
                        Console.WriteLine(" Opción no válida. Intente de nuevo.");
                        break;
                }
                if (!salir)
                {
                    Console.WriteLine("\nPresione ENTER para volver al menú...");
                    Console.ReadLine();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine(" GESTIÓN DE LIBRERÍA ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Registrar Libro");
            Console.WriteLine("2. Mostrar Libros");
            Console.WriteLine("3. Modificar Libro");
            Console.WriteLine("4. Eliminar Libro");
            Console.WriteLine("5. Salir");
            Console.WriteLine("-------------------------------------");
            Console.Write("Seleccione una opción: ");
        }
    }
}
        
    

