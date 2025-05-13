class Program
{
    static async Task Main(string[] args)
    {
        EmpleadoService servicio = new EmpleadoService();
        Console.WriteLine("Bienvenido al sistema de gestión de empleados.");
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Mostrar empleados");
            Console.WriteLine("2. Insertar empleado");
            Console.WriteLine("3. Actualizar empleado");
            Console.WriteLine("4. Eliminar empleado");
            Console.WriteLine("5. Obtener datos externos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    servicio.MostrarEmpleados();
                    break;
                case "2":
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Edad: ");
                    int edad = int.Parse(Console.ReadLine());
                    servicio.InsertarEmpleado(nombre, edad);
                    break;
                case "3":
                    Console.Write("ID a modificar:");
                     int idMod = int.Parse(Console.ReadLine());
                    Console.Write("Nuevo nombre: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Nueva edad: ");
                    int nuevaEdad = int.Parse(Console.ReadLine());
                    servicio.ActualizarEmpleado(idMod, nuevoNombre, nuevaEdad);
                    break;
                case "4":
                    Console.Write("ID a eliminar: ");
                    int idEliminar = int.Parse(Console.ReadLine());
                    servicio.EliminarEmpleado(idEliminar);
                    break;
                case "5":
                    ApiService apiService = new ApiService();
                    await apiService.ObtenerDatosExternosAsync();
                    break;
                case "6":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
                                   
            }
        }
    }
}