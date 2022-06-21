using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validar;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            Validaciones Val = new Validaciones();

            string Respuesta = Val.Validar_conexion();
            Console.WriteLine(Respuesta);

            String Respuesta1 = Val.Validar_Desconexion();
            Console.WriteLine(Respuesta1);

            Console.ReadKey();
        }
    }
}
