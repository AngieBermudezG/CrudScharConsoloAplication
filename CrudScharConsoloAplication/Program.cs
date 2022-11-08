using System;
using System.Data.SqlClient;

namespace CrudScharConsoloAplication
{
    class Program
    {
        static string cadenaConexion = String.Empty;
        static SqlConnection _sqlConnection = null;
        static SqlCommand _command = null;  //representa un procedimiento almacenado par las base de datos
        private static SqlDataReader _reader = null; // Proporciona una forma de leer un flujo de filas de la base de datos
        
        static void Main(string[] args)
        {
            Console.WriteLine("Trabajando con base de datos en c#");
            ConectarSqlServer();
            /*MostrarDatosDeJuegos();
            InsertarDatos(6,"Super Man","Estrategia",100000);
            ActualizarJuego(5,"Cars","Carreras",80000);
            EliminarJuego();*/
            CerrarConexion();
            
        }

        private static void ConectarSqlServer()
        {
            try
            {
                cadenaConexion = @"Server=DESARROLLO157;Database=plays;User Id=sa;Password=Angie123";
                _sqlConnection = new SqlConnection(cadenaConexion);
                _sqlConnection.Open();
                Console.WriteLine("Conexion exitosa!!!");
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al conectarse a la base de datos");
                Console.WriteLine(e.Message);
            }
        }

       

        private static void CerrarConexion()
        {
            try
            {
                _sqlConnection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al conectarse a la base de datos");
                Console.WriteLine(e.Message);
            }
        }
    }
}
