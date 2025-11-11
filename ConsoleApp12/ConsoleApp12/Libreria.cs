using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class Libreria
    {
        string[] NombresLibros = new string[100];
        double[] PreciosLibros = new double[100];
        int cantidad = 0;

        public void Registrar()
        {
            Console.WriteLine("\n--- Registrar Nuevo Libro ---");

            string nombre;
            double precio;
            int existe;

            Console.Write("Ingrese nombre del libro: ");
            nombre = Console.ReadLine();

            existe = 0;
            for (int i = 0; i < cantidad; i++)
            {
                if (NombresLibros[i] == nombre)
                {
                    Console.WriteLine("Ese libro ya existe.");
                    existe = 1;
                    break;
                }
            }

            if (existe == 1)
            {
                return;
            }

            Console.Write("Ingrese precio del libro (Máx. 1000): ");
            precio = Convert.ToDouble(Console.ReadLine());

            if (precio < 0)
            {
                Console.WriteLine("El precio no puede ser negativo.");
                return;
            }
            else if (precio > 1000)
            {
                Console.WriteLine("El precio máximo es 1000.");
                return;
            }

            NombresLibros[cantidad] = nombre;
            PreciosLibros[cantidad] = precio;
            cantidad = cantidad + 1;

            Console.WriteLine("\nLibro registrado correctamente.");
        }

        public void Mostrar()
        {
            Console.WriteLine("\n--- Libros Registrados ---");

            if (cantidad == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + NombresLibros[i] + " - S/ " + PreciosLibros[i]);
            }
        }

        public void Modificar()
        {
            Console.WriteLine("\n--- Modificar Libro ---");
            Console.Write("Ingrese el nombre del libro a modificar: ");
            string buscar = Console.ReadLine();

            int pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (NombresLibros[i] == buscar)
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("Libro no encontrado.");
                return;
            }

            Console.Write("Ingrese el nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo precio: ");
            double nuevoPrecio = Convert.ToDouble(Console.ReadLine());

            if (nuevoPrecio < 0)
            {
                Console.WriteLine("El precio no puede ser negativo.");
                return;
            }
            else if (nuevoPrecio > 1000)
            {
                Console.WriteLine("El precio máximo es 1000.");
                return;
            }

            NombresLibros[pos] = nuevoNombre;
            PreciosLibros[pos] = nuevoPrecio;

            Console.WriteLine("\nLibro modificado correctamente.");
        }

        public void Eliminar()
        {
            Console.WriteLine("\n--- Eliminar Libro ---");
            Console.Write("Ingrese el nombre del libro a eliminar: ");
            string eliminar = Console.ReadLine();

            int pos = -1;
            for (int i = 0; i < cantidad; i++)
            {
                if (NombresLibros[i] == eliminar)
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("Libro no encontrado.");
                return;
            }

            for (int i = pos; i < cantidad - 1; i++)
            {
                NombresLibros[i] = NombresLibros[i + 1];
                PreciosLibros[i] = PreciosLibros[i + 1];
            }

            cantidad = cantidad - 1;
            Console.WriteLine("Libro eliminado correctamente.");
        }
    }
}

