using System;
using System.IO;

namespace MyApp// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class ConsultaMedica
        {
            public string? NombrePaciente { get; set;}
            public DateTime FechaCita { get; set;}
            public string? RazonConsulta { get; set;}
            public double CostoConsulta { get; set;}
        }


        private static List<ConsultaMedica> citas = new List<ConsultaMedica>();
         static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.WriteLine("\n-----------CITAS PARA LA CLINICA DENTISTA------------");
                Console.WriteLine("1. Agregar nueva cita");
                Console.WriteLine("2. Mostrar citas");
                Console.WriteLine("3. Salir");
                Console.Write("Selecciones una opcion: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarCita();
                            break;
                        case 2:
                            MostrarCitas();
                            break;
                        case 3:
                            Console.WriteLine("\nSaliendo del programa. ¡Hasta luego!\n");
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente de nuevo.");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Ingrese un número válido.");
                }

            }while (opcion != 3);
        }

        static void AgregarCita()
        {
            ConsultaMedica consulta = new ConsultaMedica();

                Console.WriteLine($"Ingrese los datos para la cita:");
                Console.Write("Nombre del paciente: ");
                consulta.NombrePaciente = Console.ReadLine();

                Console.Write("Fecha de la cita (DD/MM/YYYY H:MM): ");
                consulta.FechaCita = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Razón de la consulta: ");
                consulta.RazonConsulta = Console.ReadLine();

                Console.Write("Costo de la consulta: ");
                consulta.CostoConsulta = Convert.ToDouble(Console.ReadLine());

                citas.Add(consulta);

                // Crear el nombre del archivo según el formato especificado
                string nombreArchivo = $"Cita{citas.Count:D3}_{consulta.NombrePaciente}.txt";
                GuardarConsultaEnArchivo(consulta, nombreArchivo);

                Console.WriteLine("Cita agregada y guardad exitosamente.\n");
        }

        static void GuardarConsultaEnArchivo(ConsultaMedica consulta, string nombreArchivo)
        {
            // Crear el contenido del archivo
            string contenido =  $"Nombre del Paciente: {consulta.NombrePaciente}\n" +
                                $"Fecha de Citas: {consulta.FechaCita}\n" +
                                $"Razón de Consulta: {consulta.RazonConsulta}\n" +
                                $"Costo de Consulta: {consulta.CostoConsulta}";


            // Guardar el contenido en el archivo
            File.WriteAllText(nombreArchivo, contenido);

            Console.WriteLine($"\nCita guardad en el archivo: {nombreArchivo}");
        }


        static void MostrarCitas()
        {
            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas para mostrar.");
                return;
            }

            Console.WriteLine("\nLista de Citas:");
            for (int i = 0; i < citas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {citas[i].NombrePaciente}, {citas[i].FechaCita}");
            }

            Console.Write("\nSeleccione el número de la cita para ver detalles: ");
            int seleccion = Convert.ToInt32(Console.ReadLine());

            if (seleccion >= 1 && seleccion <= citas.Count)
            {
                MostrarDetallesCita(citas[seleccion - 1]);
            }
            else
            {
                Console.WriteLine("Número de cita no válido.");
            }
        }

        static void MostrarDetallesCita(ConsultaMedica cita)
        {
            Console.WriteLine($"\nDetalles de la Cita:");
            Console.WriteLine($"Nombre del Paciente: {cita.NombrePaciente}");
            Console.WriteLine($"Fecha de Cita: {cita.FechaCita}");
            Console.WriteLine($"Razón de Consulta: {cita.RazonConsulta}");
            Console.WriteLine($"Costo de Consulta: {cita.CostoConsulta}\n");
        }
    }
}
