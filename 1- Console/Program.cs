using _2__BusinessLogic;
using MongoDB.Bson;

class Program
{
    static void Main(string[] args)
    {
        var businessLogic = new BusinessLogic();
        bool continueLoop = true;

        do
        {
            Console.Clear();
            Console.WriteLine("################################");
            Console.WriteLine("## Bienvenido a la aplicación ##");
            Console.WriteLine("################################\n");

            Console.WriteLine("1. Listar todos los usuarios");
            Console.WriteLine("2. Buscar personas por rol");
            Console.WriteLine("3. Cambiar rol de una persona");
            Console.WriteLine("4. Eliminar persona por cédula");
            Console.WriteLine("5. Salir");

            Console.Write("\nSeleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var personas = businessLogic.GetPersonas();
                    foreach (var persona in personas)
                    {
                        Console.WriteLine($"Cédula: {persona.cedula}, Nombre: {persona.nombre}, Rol: {persona.rol}");
                    }
                    break;

                case "2":
                    Console.Write("Ingrese el rol que desea buscar: ");
                    string role = Console.ReadLine();

                    var personasPorRol = businessLogic.GetPersonasByRole(role);

                    if (personasPorRol == null)
                    {
                        Console.WriteLine("No se encontraron personas con el rol proporcionado.");
                    }
                    else
                    {
                        foreach (var persona in personasPorRol)
                        {
                            Console.WriteLine($"Cédula: {persona.cedula}, Nombre: {persona.nombre}, Rol: {persona.rol}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Ingrese la cédula de la persona: ");
                    string cedula = Console.ReadLine();

                    Console.Write("Ingrese el nuevo rol: ");
                    string newRole = Console.ReadLine();

                    string currentRole = businessLogic.GetRoleByCedula(cedula);
                    if (currentRole == null)
                    {
                        Console.WriteLine("No se encontró ninguna persona con la cédula proporcionada.");
                    }
                    else if (currentRole == newRole)
                    {
                        Console.WriteLine("La persona ya tiene el rol que intenta asignar.");
                    }
                    else
                    {
                        businessLogic.ChangeRole(cedula, newRole);
                        Console.WriteLine("Rol actualizado exitosamente.");
                    }
                    break;

                case "4":
                    Console.Write("Ingrese la cédula de la persona a eliminar: ");
                    string cedulaToDelete = Console.ReadLine();

                    if (!businessLogic.ExistsPersonaByCedula(cedulaToDelete))
                    {
                        Console.WriteLine("No se encontró ninguna persona con la cédula proporcionada.");
                    }
                    else
                    {
                        businessLogic.DeletePersonaByCedula(cedulaToDelete);
                        Console.WriteLine("Persona eliminada exitosamente. Listando todos los usuarios...");

                        var personasAfterDelete = businessLogic.GetPersonas();
                        foreach (var persona in personasAfterDelete)
                        {
                            Console.WriteLine($"Cédula: {persona.cedula}, Nombre: {persona.nombre}, Rol: {persona.rol}");
                        }
                    }
                    break;

                case "5":
                    continueLoop = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }

            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();

        } while (continueLoop);
    }
}

