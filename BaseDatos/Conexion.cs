using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BaseDatos
{
    public class Conexion
    {
        private NpgsqlConnection Connection = new NpgsqlConnection("Host=127.0.0.1;port=5432;DataBase=cursocsharp;user id=postgres;password=12345");

        public bool ConectarBase()
        {
            try
            {
                Connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool DesconectarBase()
        {
            try
            {
                Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public DataTable MostrarDatos()
        {
            try
            {
                DataTable Datos = new DataTable();
                string query = "SELECT * FROM PERSONA ORDER BY _id";
                NpgsqlDataAdapter getData = new NpgsqlDataAdapter(query, Connection);
                getData.Fill(Datos);
                return Datos;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public int InsertarDatos(int Id, string Nombre,int Edad, string Nacionalidad)
        {
            try
            {
                DataTable Datos = new DataTable();
                string query = $"INSERT INTO PERSONA VALUES({Id},'{Nombre}',{Edad},'{Nacionalidad}')";
                NpgsqlCommand SetData = new NpgsqlCommand(query, Connection);
                int FilasAfectadas=SetData.ExecuteNonQuery();
                return FilasAfectadas;
            }
            catch (Exception)
            {
                return 0;
            }
        }


    }
}
