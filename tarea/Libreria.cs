using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea
{
    internal class Libreria
    {
        // Arreglos unidimensionales dinámicos (List<T>)
        private List<string> NombresLibros = new List<string>(); // Inicialmente con 0 espacios
        private List<decimal> PreciosLibros = new List<decimal>(); // Inicialmente con 0 espacios
                                                                   // Método 1: Registrar()
        public void Registrar()
        {
            Console.WriteLine("\n--- Registrar Nuevo Libro ---");
            string nombre = string.Empty;
            decimal precio = 0;
            bool inputValido = false;

            // Pedir y validar Nombre (No nulo/vacío, No duplicados)
            while (!inputValido)
            {
                Console.Write("Ingrese nombre del libro: ");
                nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("❌ El nombre del libro no puede ser vacío o nulo.");
                }
                else if (NombresLibros.Contains(nombre))
                {
                    Console.WriteLine($"❌ El libro '{nombre}' ya existe. No se permiten nombres duplicados.");
                }
                else
                {
                    inputValido = true;
                }
            }

            // Pedir y validar Precio (Numérico, No negativo, Máx. 1000)
            inputValido = false;
            while (!inputValido)
            {
                Console.Write("Ingrese precio del libro (Máx. 1000.00): ");
                string inputPrecio = Console.ReadLine();

                if (!decimal.TryParse(inputPrecio, out precio) || string.IsNullOrWhiteSpace(inputPrecio))
                {
                    Console.WriteLine(" El precio debe ser un valor numérico válido y no nulo.");
                }
                else if (precio < 0)
                {
                    Console.WriteLine(" El precio no puede ser negativo.");
                }
                else if (precio > 1000)
                {
                    Console.WriteLine(" El precio máximo permitido es 1000.");
                }
                else
                {
                    inputValido = true;
                }
            }

            // Registrar (Agregar a los arreglos paralelos)
            NombresLibros.Add(nombre);
            PreciosLibros.Add(precio);
            Console.WriteLine($"\n Libro '{nombre}' (Precio: {precio:C}) registrado correctamente.");
        }

        // Método 2: Mostrar()
        public void Mostrar()
        {
            Console.WriteLine("\n--- Libros Registrados ---");
            if (NombresLibros.Count == 0)
            {
                Console.WriteLine("📚 La librería está vacía. No hay libros para mostrar.");
                return;
            }

            for (int i = 0; i < NombresLibros.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] Nombre: {NombresLibros[i]}, Precio: {PreciosLibros[i]:C}");
            }
        }

        // Método 3: Modificar()
        public void Modificar()
        {
            Console.WriteLine("\n--- Modificar Libro ---");
            Console.Write("Ingrese el nombre del libro a modificar: ");
            string nombreBuscar = Console.ReadLine();

            int indice = NombresLibros.IndexOf(nombreBuscar);

            if (indice >= 0)
            {
                Console.WriteLine($"\nModificando libro: {NombresLibros[indice]} (Precio actual: {PreciosLibros[indice]:C})");

                // --- Pedir y validar el NUEVO Nombre ---
                string nuevoNombre = string.Empty;
                bool nombreValido = false;

                while (!nombreValido)
                {
                    Console.Write("Ingrese el NUEVO nombre del libro (Deje vacío para mantener el actual): ");
                    nuevoNombre = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nuevoNombre))
                    {
                        // Si deja vacío, mantiene el nombre actual.
                        nuevoNombre = NombresLibros[indice];
                        nombreValido = true;
                    }
                    // Validar duplicados, excluyendo el libro actual
                    else if (NombresLibros.Contains(nuevoNombre) && NombresLibros.IndexOf(nuevoNombre) != indice)
                    {
                        Console.WriteLine($"❌ El nombre '{nuevoNombre}' ya está siendo usado por otro libro.");
                    }
                    else
                    {
                        nombreValido = true;
                    }
                }

                // --- Pedir y validar el NUEVO Precio ---
                decimal nuevoPrecio = 0;
                bool precioValido = false;

                while (!precioValido)
                {
                    Console.Write("Ingrese el NUEVO precio del libro: ");
                    string inputPrecio = Console.ReadLine();

                    if (!decimal.TryParse(inputPrecio, out nuevoPrecio) || string.IsNullOrWhiteSpace(inputPrecio))
                    {
                        Console.WriteLine(" El precio debe ser un valor numérico válido y no nulo.");
                    }
                    else if (nuevoPrecio < 0)
                    {
                        Console.WriteLine(" El precio no puede ser negativo.");
                    }
                    else if (nuevoPrecio > 1000)
                    {
                        Console.WriteLine(" El precio máximo permitido es 1000.");
                    }
                    else
                    {
                        precioValido = true;
                    }
                }

                // Actualizar los arreglos
                NombresLibros[indice] = nuevoNombre;
                PreciosLibros[indice] = nuevoPrecio;
                Console.WriteLine($"\n Libro modificado a '{nuevoNombre}' con precio {nuevoPrecio:C} correctamente.");
            }
            else
            {
                Console.WriteLine($"\n El libro '{nombreBuscar}' no se encontró en la librería.");
            }
        }

        // Método 4: Eliminar()
        public void Eliminar()
        {
            Console.WriteLine("\n--- Eliminar Libro ---");
            Console.Write("Ingrese el nombre del libro a eliminar: ");
            string nombreEliminar = Console.ReadLine();

            int indice = NombresLibros.IndexOf(nombreEliminar);

            if (indice >= 0)
            {
                // Eliminar de ambos arreglos para mantener la coherencia
                NombresLibros.RemoveAt(indice);
                PreciosLibros.RemoveAt(indice);
                Console.WriteLine($"\n Libro '{nombreEliminar}' eliminado correctamente.");
            }
            else
            {
                Console.WriteLine($"\n El libro '{nombreEliminar}' no se encontró en la librería.");
            }
        }
    }
}

