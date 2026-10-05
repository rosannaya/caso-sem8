using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_sem8
{
    internal class Program
    {
       


        // 4.3 Declaración de Arreglos Estáticos Paralelos y contador de control
        static int MAX_EMPLEADOS = 50;
        static string[] nombres = new string[MAX_EMPLEADOS];
        static string[] correos = new string[MAX_EMPLEADOS];
        static int totalEmpleados = 0; // Controla cuántos elementos ocupados hay

        static void MostrarEncabezado()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("   SISTEMA DE EMPLEADOS - ARREGLOS Y CADENAS (C#)");
            Console.WriteLine(new string('=', 60));
        }

        static void RegistrarEmpleado()
        {
            Console.WriteLine("\n--- REGISTRAR EMPLEADO ---");

            if (totalEmpleados >= MAX_EMPLEADOS)
            {
                Console.WriteLine("❌ Error: Capacidad máxima alcanzada.");
                return;
            }

            Console.Write("Ingrese Nombres y Apellidos: ");
            string nombreCompleto = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombreCompleto))
            {
                Console.WriteLine("❌ Error: El nombre no puede estar vacío.");
                return;
            }

            // 4.2 Métodos comunes de cadenas: ToUpper y Split
            string nombreMayus = nombreCompleto.ToUpper();
            string[] partes = nombreMayus.Split(' ');
            string primerNombre = partes.Length > 0 ? partes[0] : "USUARIO";

            // Generar correo institucional manipulando strings
            string correo = $"{primerNombre.ToLower()}@ferreteria.com";

            // 4.3 Inserción en los arreglos paralelos usando el contador
            nombres[totalEmpleados] = nombreMayus;
            correos[totalEmpleados] = correo;
            totalEmpleados++;

            Console.WriteLine($"✅ Empleado registrado con éxito. Correo generado: {correo}");
        }

        static void BuscarPorTexto()
        {
            // 4.4 Búsqueda textual utilizando Contains y recorrido hasta totalEmpleados
            Console.WriteLine("\n--- BÚSQUEDA TEXTUAL DE EMPLEADOS ---");

            if (totalEmpleados == 0)
            {
                Console.WriteLine("⚠️ No hay empleados registrados.");
                return;
            }

            Console.Write("Ingrese parte del nombre o apellido a buscar: ");
            string filtro = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(filtro)) return;

            bool encontrado = false;

            for (int i = 0; i < totalEmpleados; i++)
            {
                // 4.2 / 4.4 Verificamos si la cadena almacenada contiene la subcadena de búsqueda
                if (nombres[i].Contains(filtro))
                {
                    Console.WriteLine($"🔍 Encontrado -> Nombre: {nombres[i]} | Correo: {correos[i]}");
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("❌ No se encontraron coincidencias para ese filtro.");
            }
        }

        static void OrdenarPorNombre()
        {
            // 4.4 Ordenamiento de cadenas (Algoritmo de Burbuja Alfabético)
            if (totalEmpleados <= 1)
            {
                Console.WriteLine("\n⚠️ No hay suficientes elementos para ordenar.");
                return;
            }

            for (int i = 0; i < totalEmpleados - 1; i++)
            {
                for (int j = 0; j < totalEmpleados - 1 - i; j++)
                {
                    // string.Compare devuelve > 0 si el primer string va después alfabéticamente que el segundo
                    if (string.Compare(nombres[j], nombres[j + 1]) > 0)
                    {
                        // Intercambiar nombres en el arreglo
                        string tempNombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = tempNombre;

                        // Intercambiar correos correspondientes para mantener el paralelismo
                        string tempCorreo = correos[j];
                        correos[j] = correos[j + 1];
                        correos[j + 1] = tempCorreo;
                    }
                }
            }
            Console.WriteLine("\n✅ ¡Empleados ordenados alfabéticamente (A-Z) con éxito!");
        }

        static void MostrarListado()
        {
            // 3.1 / 4.3 Recorrido de arreglos paralelos de cadenas
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("                LISTADO GENERAL DE EMPLEADOS");
            Console.WriteLine(new string('=', 60));

            if (totalEmpleados == 0)
            {
                Console.WriteLine("⚠️ No hay registros para mostrar.");
                Console.WriteLine(new string('=', 60));
                return;
            }

            for (int i = 0; i < totalEmpleados; i++)
            {
                Console.WriteLine($"{i + 1}. {nombres[i]} - Correo: {correos[i]}");
            }
            Console.WriteLine(new string('=', 60));
        }

        // ==========================================
        // MÉTODO PRINCIPAL (MENÚ INTERACTIVO)
        // ==========================================
        static void Main(string[] args)
        {
            MostrarEncabezado();
            int opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                Console.WriteLine("1. Registrar empleado");
                Console.WriteLine("2. Buscar empleado por texto");
                Console.WriteLine("3. Ordenar empleados alfabéticamente (A-Z)");
                Console.WriteLine("4. Mostrar todos los empleados");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("❌ Error: Ingrese una opción numérica válida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarEmpleado();
                        break;
                    case 2:
                        BuscarPorTexto();
                        break;
                    case 3:
                        OrdenarPorNombre();
                        break;
                    case 4:
                        MostrarListado();
                        break;
                    case 5:
                        Console.WriteLine("\n¡Gracias por usar el sistema!");
                        break;
                    default:
                        Console.WriteLine("❌ Opción incorrecta. Elija entre 1 y 5.");
                        break;
                }
            }

        }
    }
}
        
  
