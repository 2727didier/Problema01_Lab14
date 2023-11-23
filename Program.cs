using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema01_Lab14
{
    internal class Program
    {
      
        
            static List<Persona> encuestaData = new List<Persona>();

            static void Main()
            {
                int opcion;

                do
                {
                    MostrarMenu();
                    Console.Write("Ingrese una opción: ");
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        ProcesarOpcion(opcion);
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opción válida.");
                    }

                } while (opcion != 5);
            }

            static void MostrarMenu()
            {
                Console.WriteLine("================================");
                Console.WriteLine("Encuesta Covid-19");
                Console.WriteLine("================================");
                Console.WriteLine("1: Realizar Encuesta");
                Console.WriteLine("2: Mostrar Datos de la encuesta");
                Console.WriteLine("3: Mostrar Resultados");
                Console.WriteLine("4: Buscar Personas por edad");
                Console.WriteLine("5: Salir");
                Console.WriteLine("================================");
            }

            static void ProcesarOpcion(int opcion)
            {
                switch (opcion)
                {
                    case 1:
                        RealizarEncuesta();
                        break;
                    case 2:
                        MostrarDatosEncuesta();
                        break;
                    case 3:
                        MostrarResultados();
                        break;
                    case 4:
                        BuscarPorEdad();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }

            static void RealizarEncuesta()
            {
                Console.Write("Ingrese la edad de la persona: ");
                if (int.TryParse(Console.ReadLine(), out int edad))
                {
                    Console.Write("¿Se ha vacunado? (Sí/No): ");
                    string respuesta = Console.ReadLine().ToLower();

                    bool seHaVacunado = respuesta == "sí" || respuesta == "si";

                    encuestaData.Add(new Persona(edad, seHaVacunado));

                    Console.WriteLine("Encuesta registrada exitosamente.");
                }
                else
                {
                    Console.WriteLine("Ingrese una edad válida.");
                }
            }

            static void MostrarDatosEncuesta()
            {
                Console.WriteLine("Datos de la encuesta:");
                foreach (var persona in encuestaData)
                {
                    Console.WriteLine($"Edad: {persona.Edad}, Se ha vacunado: {persona.SeHaVacunado}");
                }
            }

            static void MostrarResultados()
            {
                int totalEncuestados = encuestaData.Count;
                int totalVacunados = encuestaData.Count(p => p.SeHaVacunado);

                Console.WriteLine($"Total encuestados: {totalEncuestados}");
                Console.WriteLine($"Total vacunados: {totalVacunados}");
                Console.WriteLine($"Porcentaje de vacunados: {(double)totalVacunados / totalEncuestados * 100}%");
            }

            static void BuscarPorEdad()
            {
                Console.Write("Ingrese la edad a buscar: ");
                if (int.TryParse(Console.ReadLine(), out int edad))
                {
                    var personasEncontradas = encuestaData.Where(p => p.Edad == edad).ToList();

                    if (personasEncontradas.Count > 0)
                    {
                        Console.WriteLine($"Personas encontradas con edad {edad}:");
                        foreach (var persona in personasEncontradas)
                        {
                            Console.WriteLine($"Se ha vacunado: {persona.SeHaVacunado}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No se encontraron personas con edad {edad}.");
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese una edad válida.");
                }
            }
        }

        class Persona
        {
            public int Edad { get; set; }
            public bool SeHaVacunado { get; set; }

            public Persona(int edad, bool seHaVacunado)
            {
                Edad = edad;
                SeHaVacunado = seHaVacunado;
            }
        }
}


