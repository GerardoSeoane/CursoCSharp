using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos;

namespace Validaciones
{
    public class Validar
    {
        Conexion conexion = new Conexion();

        public string ConectarBD()
        {
            try
            {
                bool response=conexion.ConectarBase();
                if (response==true)
                {
                    return "Conexion Existosa";
                }
                else
                {
                    return "Conexion Fallida";
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public string DesconectarBD()
        {
            try
            {
                bool response = conexion.DesconectarBase();
                if (response == true)
                {
                    return "Desconexion Existosa";
                }
                else
                {
                    return "Desconexion Fallida";
                }
            }
            catch (Exception error)
            {
                return error.ToString();
            }
        }

        public List<EntPersona> MostrarDatos()
        {
            List<EntPersona> ListaPersonas = new List<EntPersona>();
            DataTable Datos = conexion.MostrarDatos();

            foreach (DataRow valor in Datos.Rows)
            {
                EntPersona Persona = new EntPersona();

                Persona.ID = Convert.ToInt32(valor["_id"]);
                Persona.Nombre = valor["nombre"].ToString();
                Persona.Edad = Convert.ToInt32(valor["edad"]);
                Persona.Nacionalidad = valor["nacionalidad"].ToString();

                ListaPersonas.Add(Persona);
            }

            return ListaPersonas;
        }

        public void InsertarDatos(int Id, string Nombre, int Edad, string Nacionalidad)
        {
            int FilasAfectadas = conexion.InsertarDatos(Id,Nombre,Edad,Nacionalidad);
            if (FilasAfectadas != 1)
                throw new ApplicationException("Error al Insertar");     
        }

        public void ActualizarDatos(int Id, string Nombre)
        {
            int FilasAfectadas = conexion.ActualizarDatos(Id, Nombre);
            if (FilasAfectadas != 1)
                throw new ApplicationException("Error al Actualizar");
        }

        public void EliminarDatos(int Id)
        {
            int FilasAfectadas = conexion.EliminarDatos(Id);
            if (FilasAfectadas != 1)
                throw new ApplicationException("Error al Eliminar");
        }
        
    }
}
