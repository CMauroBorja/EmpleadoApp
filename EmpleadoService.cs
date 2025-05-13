using MySql.Data.MySqlClient;
using System;

public class EmpleadoService
{
    private string connectionString = "server=localhost;user=root;database=Empresa;port=3306;password=1234";

    public void InsertarEmpleado(string nombre, int edad)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        string query = "INSERT INTO empleados (nombre, edad) VALUES (@nombre, @edad)";
        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@nombre", nombre);
        cmd.Parameters.AddWithValue("@edad", edad);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Empleado insertado correctamente.");
    }

    public void MostrarEmpleados()
    {
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM empleados";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Nombre: {reader["nombre"]}, Edad: {reader["edad"]}");
            }
        }
    }

    public void ActualizarEmpleado(int id, string nuevoNombre, int nuevaEdad)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        string query = "UPDATE empleados SET nombre = @nuevoNombre, edad = @nuevaEdad WHERE id = @id";
        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@nuevoNombre", nuevoNombre);
        cmd.Parameters.AddWithValue("@nuevaEdad", nuevaEdad);
        int filas = cmd.ExecuteNonQuery();
        Console.WriteLine(filas > 0 ? "Empleado actualizado." : "Empleado no enconttrado.");
    }

    public void EliminarEmpleado(int id)
    {
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
        string query = "DELETE FROM empleados WHERE id = @id";
        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        int filas = cmd.ExecuteNonQuery();
        Console.WriteLine(filas > 0 ? "empleado eliminado." : "Empleado no encontrado.");
    }   
}
         
    