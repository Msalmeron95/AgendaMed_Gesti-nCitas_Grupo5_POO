
using System.Reflection;
using System.Reflection.Metadata;
using Spectre.Console;

public class OptionsMenu
{
    public static void MainMenu()
    {
        int choice = 0;
        do
        {
            AnsiConsole.WriteLine("Bienvenido a la unidad de salud UNIVO");
            AnsiConsole.WriteLine("1. Iniciar sesión");
            AnsiConsole.WriteLine("2. Salir");
            AnsiConsole.Write("Seleccionar una opción: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {

                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        AnsiConsole.WriteLine("\nOpción inválida. Por favor, seleccione nuevamente.\n");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                AnsiConsole.WriteLine("\nIgrese solo las opciones disponibles (1 - 2).\n"); 
                Console.ResetColor();
            }
            
        } while (true);
        {



        }
    }

    private static void Login()
    {
        int attempts = 0;
        bool loggedIn = false;

        while (attempts < 3 && !loggedIn)
        {
            AnsiConsole.Write("\nEmail: ");
            string? email = Console.ReadLine();
            AnsiConsole.Write("Contraseña: ");
            string? password = Console.ReadLine();

            loggedIn = SessionHandling.Login(email, password);

            if (!loggedIn)
            {
                AnsiConsole.WriteLine("[red]Email o contraseña incorrectos. Por favor, inténtelo de nuevo.[/]");
                attempts++;
            }
        }

        if (!loggedIn)
        {
            AnsiConsole.WriteLine("[red]Has excedido el número máximo de intentos. El programa se cerrará.[/]");
            Environment.Exit(1);
        }
    }

    public static class SharedData
    {
        public static int Option;
    }

    protected static void AdminMenu()
    {
        
        do
        {
            AnsiConsole.WriteLine("Menú de administrador principal:");
            AnsiConsole.WriteLine("1. Ver citas programadas");
            AnsiConsole.WriteLine("2. Ver lista de pacientes");
            AnsiConsole.WriteLine("3. Ver historial médico de un paciente");
            AnsiConsole.WriteLine("4. Cancelar cita (seleccionando la cita y proporcionando el motivo)");
            AnsiConsole.WriteLine("5. Salir");

            AnsiConsole.Write("Selecciona una opción:");  

            if (int.TryParse(Console.ReadLine(), out SharedData.Option))
            {
                switch (SharedData.Option)
                {
                    case 1:
                        Appointments.DisplayAppointments();
                        break;
                    case 3:
                        DoctorsFunctions.AddDoctor();
                        break;
                    case 4:
                        AnsiConsole.Write("\nIngrese el doctor que deceas remover: ");
                        string? NameDoctor= Console.ReadLine();
                        DoctorsFunctions.RemoveDoctor(NameDoctor);
                        break;
                    case 5:
                        AnsiConsole.Write("Salir..");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        AnsiConsole.WriteLine("Opción inválida. Por favor, seleccione nuevamente.");
                        Console.ResetColor();
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                AnsiConsole.WriteLine("\nIgrese solo las opciones disponibles (1 - 7).\n"); 
                Console.ResetColor();
            }
        } while (SharedData.Option != 7);

    }

    protected static void DoctorMenu()
    {
        do
        {
            if (int.TryParse(Console.ReadLine(), out SharedData.Option))
            {
                AnsiConsole.WriteLine("Menú de doctor:");
                AnsiConsole.WriteLine("1. Ver citas");
                AnsiConsole.WriteLine("2. Ver pacientes");
                AnsiConsole.WriteLine("3. Cancelar cita");
                AnsiConsole.WriteLine("4. Salir");

                AnsiConsole.Write("Selecciona una opción:");  

                switch (SharedData.Option)
                {
                    case 1:
                        Appointments.DisplayAppointments();
                        break;
                    case 2:
                        // Implementar lógica para ver pacientes del doctor
                        break;
                    case 3:
                        // Implementar lógica para cancelar cita
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        AnsiConsole.WriteLine("Opción inválida. Por favor, seleccione nuevamente.");
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                AnsiConsole.WriteLine("\nIgrese solo las opciones disponibles (1 - 7).\n"); 
                Console.ResetColor();
            }
            
        } while (SharedData.Option != 4);
        
    }

    protected static void PatientMenu()
{
    do
    {
        AnsiConsole.WriteLine("Menú de paciente:");
        AnsiConsole.WriteLine("1. Ver doctores disponibles por especialidad");
        AnsiConsole.WriteLine("2. Ver citas programadas");
        AnsiConsole.WriteLine("3. Ver historial médico");
        AnsiConsole.WriteLine("4. Agendar cita");
        AnsiConsole.WriteLine("5. Salir");

        AnsiConsole.Write("Selecciona una opción:");

        if (int.TryParse(Console.ReadLine(), out SharedData.Option))
        {
            switch (SharedData.Option)
            {
                case 1:
                    // Implementar lógica para ver doctores disponibles por especialidad
                    break;
                case 2:
                    // Implementar lógica para ver citas programadas
                    break;
                case 3:
                    // Implementar lógica para ver historial médico
                    break;
                case 4:
                    // Implementar lógica para agendar cita
                    break;
                case 5:
                    AnsiConsole.Write("Salir..");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    AnsiConsole.WriteLine("Opción inválida. Por favor, seleccione nuevamente.");
                    Console.ResetColor();
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            AnsiConsole.WriteLine("\nIgrese solo las opciones disponibles (1 - 5).\n");
            Console.ResetColor();
        }
    } while (SharedData.Option != 5);
}

}