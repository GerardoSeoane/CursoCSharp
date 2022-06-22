using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validaciones;

namespace Interfaz_Grafica
{
    class Interfaz
    {
        static Validar validar = new Validar();
        static void Main(string[] args)
        {
            
            char opc = 'y';
            do
            {
                inicio:;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Respuesta de BD--> {validar.ConectarBD()}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1.- Mostrar");
                Console.WriteLine("2.- Insertar");
                Console.WriteLine("3.- Actualizar");
                Console.WriteLine("4.- Eliminar\n");

                Console.Write("Opcion: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":MostrarDatos();
                        break;
                    case "2":InsertarDatos();
                        break;
                    case "3":ActualizarDatos();
                        break;
                    case "4":EliminarDatos();
                        break;
                    case "5":goto inicio;
                        break;
                    default:
                        break;
                }

                Console.WriteLine("\nVolver a Menu?    SI (Y)    NO (Cualquier Tecla)   ");
                opc = char.Parse(Console.ReadLine());
                Console.Clear();
                validar.DesconectarBD();
            } while (opc=='Y' || opc=='y');

            validar.DesconectarBD();
        }

        public static void MostrarDatos()
        {
            Console.Clear();
            List<EntPersona> ListaPersonas= validar.MostrarDatos();

            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"            MOSTRAR DATOS            ");
            Console.WriteLine("--------------------------------------\n");

            foreach (EntPersona val in ListaPersonas)
            {
                if (val.Nombre.Length>10)
                {
                    Console.WriteLine($"{val.ID} | {val.Nombre.ToString().Substring(0, 10)} | {val.Edad} | {val.Nacionalidad}");
                }

                else
                {
                    Console.WriteLine($"{val.ID} | {val.Nombre.PadRight(10,' ')} | {val.Edad} | {val.Nacionalidad}");
                }
            }           
        }

        public static void InsertarDatos()
        {
            try
            {
                Console.Clear();
                int Id, Edad;
                string Nombre, Nacionalidad;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"           INSERTAR DATOS            ");
                Console.WriteLine("--------------------------------------\n");

                List<EntPersona> ListaPersonas = validar.MostrarDatos();

                foreach (EntPersona val in ListaPersonas)
                {
                    if (val.Nombre.Length > 10)
                    {
                        Console.WriteLine($"{val.ID} | {val.Nombre.ToString().Substring(0, 10)} | {val.Edad} | {val.Nacionalidad}");
                    }

                    else
                    {
                        Console.WriteLine($"{val.ID} | {val.Nombre.PadRight(10, ' ')} | {val.Edad} | {val.Nacionalidad}");
                    }
                }

                Console.Write("\nIngrese ID: ");
                Id = int.Parse(Console.ReadLine());
                Console.Write("Ingrese Nombre: ");
                Nombre = Console.ReadLine();
                Console.Write("Ingrese Edad: ");
                Edad = int.Parse(Console.ReadLine());
                Console.Write("Ingrese Nacionalidad: ");
                Nacionalidad = Console.ReadLine();
                validar.InsertarDatos(Id, Nombre, Edad, Nacionalidad);

                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"       INSERTADO CORRECTAMENTE       ");
                Console.WriteLine("--------------------------------------\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"          FALLO AL INSERTAR          ");
                Console.WriteLine("--------------------------------------\n");
            }
        }

        public static void ActualizarDatos()
        {
            try
            {
                Console.Clear();
                int Id;
                string Nombre;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"         ACTUALIZAR DATOS            ");
                Console.WriteLine("--------------------------------------\n");

                List<EntPersona> ListaPersonas = validar.MostrarDatos();

                foreach (EntPersona val in ListaPersonas)
                {
                    if (val.Nombre.Length > 10)
                    {
                        Console.WriteLine($"{val.ID} | {val.Nombre.ToString().Substring(0, 10)} | {val.Edad} | {val.Nacionalidad}");
                    }

                    else
                    {
                        Console.WriteLine($"{val.ID} | {val.Nombre.PadRight(10, ' ')} | {val.Edad} | {val.Nacionalidad}");
                    }
                }

                Console.Write("\nIngrese ID: ");
                Id = int.Parse(Console.ReadLine());
                Console.Write("Ingrese Nombre: ");
                Nombre = Console.ReadLine();
                
                validar.ActualizarDatos(Id, Nombre);

                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"       ACTUALIZADO CORRECTAMENTE       ");
                Console.WriteLine("--------------------------------------\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"          FALLO AL ACTUALIZAR          ");
                Console.WriteLine("--------------------------------------\n");
            }
        }

        public static void EliminarDatos()
        {
            try
            {
                Console.Clear();
                int Id;
                string Nombre;
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"           ELIMINAR DATOS            ");
                Console.WriteLine("--------------------------------------\n");

                List<EntPersona> ListaPersonas = validar.MostrarDatos();

                foreach (EntPersona val in ListaPersonas)
                {
                    if (val.Nombre.Length > 10)
                    {
                        Console.WriteLine($"{val.ID} | {val.Nombre.ToString().Substring(0, 10)} | {val.Edad} | {val.Nacionalidad}");
                    }

                    else
                    {
                        Console.WriteLine($"{val.ID} | {val.Nombre.PadRight(10, ' ')} | {val.Edad} | {val.Nacionalidad}");
                    }
                }

                Console.Write("\nIngrese ID: ");
                Id = int.Parse(Console.ReadLine());

                validar.EliminarDatos(Id);

                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"         ELIMINADO CORRECTAMENTE       ");
                Console.WriteLine("--------------------------------------\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine($"           FALLO AL ELIMINAR           ");
                Console.WriteLine("--------------------------------------\n");
            }
        }
    }
}
