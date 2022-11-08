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
            MostrarDatosDeJuegos();
            InsertarDatos(6,"Super Man","Estrategia",100000);
            ActualizarJuego(5,"Cars","Carreras",80000);
            EliminarJuego();
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
 private static void MostrarDatosDeJuegos()
        {
            try
            {
                string sqlQuery = "SELECT * FROM plays";
                _command = new SqlCommand(sqlQuery, _sqlConnection);
                _reader = _command.ExecuteReader();
                Console.WriteLine("plays IdPlay\t\t Name\t\t Tipo\t\t Price\t\t ");
                Console.WriteLine("______________________________________________");
                while (_reader.Read())
                {
                    Console.WriteLine($"{_reader["IdPlay"]}\t\t {_reader["Name"]}\t\t {_reader["Tipo"]}\t\t {_reader["Price"]}\t\t ");
                }
                _reader.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al conectarse a la base de datos");
                Console.WriteLine(e.Message);
            }
        }

        private static void InsertarDatos(int id, string name, string tipo, int price)
        {
            try
            {
                var sqlQuery = @"Insert INTO plays (IdPlay,Name,Tipo,Price) VALUES (@IdPlay,@Name,@Tipo,@Price)";
                _command = new SqlCommand(sqlQuery, _sqlConnection);
                _command.Parameters.AddWithValue("IdPlay", id);
                _command.Parameters.AddWithValue("Name", name);
                _command.Parameters.AddWithValue("Tipo", tipo);
                _command.Parameters.AddWithValue("Price", price);
                var result = _command.ExecuteNonQuery(); //devuelve el nuymero de filas que se ionserto
                Console.WriteLine($"{result} insertado correctamente");
                Console.WriteLine("Datos actuales de la tabla");
                MostrarDatosDeJuegos();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al conectarse a la base de datos");
                Console.WriteLine(e.Message);
            }
            
        }

        private static void ActualizarJuego(int id, string name, string tipo, int price)
        {
            try
            {
                var sqlQuery = @"Update plays SET Name = @Name,Tipo = @Tipo,Price = @Price WHERE IdPlay = @IdPlay";
                _command = new SqlCommand(sqlQuery, _sqlConnection);
                _command.Parameters.AddWithValue("IdPlay", id);
                _command.Parameters.AddWithValue("Name", name);
                _command.Parameters.AddWithValue("Tipo", tipo);
                _command.Parameters.AddWithValue("Price", price);
                var result = _command.ExecuteNonQuery();
                Console.WriteLine($"{result} ssu registro se a actualizado correctamente");
                Console.WriteLine("Datos actuales de la base de datos");
                MostrarDatosDeJuegos();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error al conectarse a la base de datos");
                Console.WriteLine(e.Message);
            }
          
        }

        private static void EliminarJuego()
        {
            try
            {
                Console.WriteLine("Ingresa el juego a eliminar");
                var juegoEliminar = Console.ReadLine();
                var sqlQuery = @"Delete FROM plays where IdPlay = @IdPlay";
                _command = new SqlCommand(sqlQuery, _sqlConnection);
                _command.Parameters.AddWithValue("IdPlay", juegoEliminar);
                var result = _command.ExecuteNonQuery();
                Console.WriteLine($"{result} Registro eliminado exitosamnete ");
                Console.WriteLine("Datos actualizados de la tabla");
                MostrarDatosDeJuegos();
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
