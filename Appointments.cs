using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Reflection;

public class Appointments
{
    protected string? Name { get; set; }
    protected string? Address { get; set; }
    protected string? Email { get; set; }
    protected string? Password { get; set; }
    protected string? DoctorAssigned { get; set; }
    protected double PatientID { get; set; }
    protected DateOnly AppointmentDate { get; set; }
    protected TimeOnly AppointmentTime { get; set; }

    public static void AddAppointment(string? aName, string? aAddress, string? aEmail, string? aPassword, double aPatientID, string? aDoctorAssigned, DateOnly aAppointmentDate, TimeOnly aAppointmentTime)
    {
        appointmentList.Add(new Appointments
        {
            Name = aName,
            Address = aAddress,
            Email = aEmail,
            Password = aPassword,
            DoctorAssigned = aDoctorAssigned,
            PatientID = aPatientID,
            AppointmentDate = aAppointmentDate,
            AppointmentTime = aAppointmentTime
        });
    }
    private static List<Appointments> appointmentList = new List<Appointments>();
    static Appointments()
    {
        for (int i = 0; i < DoctorsFunctions.DoctorsList.Count; i++)
        {
            AddAppointment("John Doe", "123 Main St", "john.doe@example.com", "password1", 1, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 14), new TimeOnly(9, 0));
            AddAppointment("Jane Smith", "456 Elm St", "jane.smith@example.com", "password2", 2, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 15), new TimeOnly(10, 0));
            AddAppointment("Alice Johnson", "789 Oak St", "alice.johnson@example.com", "password3", 3, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 16), new TimeOnly(11, 0));
            AddAppointment("Bob Roberts", "321 Pine St", "bob.roberts@example.com", "password4", 4, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 17), new TimeOnly(12, 0));
            AddAppointment("Emily Davis", "654 Birch St", "emily.davis@example.com", "password5", 5, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 18), new TimeOnly(13, 0));
            AddAppointment("David Wilson", "987 Maple St", "david.wilson@example.com", "password6", 6, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 19), new TimeOnly(14, 0));
            AddAppointment("Sarah Thompson", "741 Oak St", "sarah.thompson@example.com", "password7", 7, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 20), new TimeOnly(15, 0));
            AddAppointment("Michael Jackson", "852 Elm St", "michael.jackson@example.com", "password8", 8, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 21), new TimeOnly(16, 0));
            AddAppointment("Lisa White", "963 Cedar St", "lisa.white@example.com", "password9", 9, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 22), new TimeOnly(17, 0));
            AddAppointment("Kevin Brown", "159 Spruce St", "kevin.brown@example.com", "password10", 10, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 23), new TimeOnly(18, 0));
            AddAppointment("Amanda Miller", "357 Oak St", "amanda.miller@example.com", "password11", 11, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 24), new TimeOnly(19, 0));
            AddAppointment("Ryan Wilson", "258 Pine St", "ryan.wilson@example.com", "password12", 12, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 25), new TimeOnly(20, 0));
            AddAppointment("Jessica Taylor", "369 Elm St", "jessica.taylor@example.com", "password13", 13, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 26), new TimeOnly(21, 0));
            AddAppointment("Mark Anderson", "147 Maple St", "mark.anderson@example.com", "password14", 14, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 27), new TimeOnly(22, 0));
            AddAppointment("Laura Martinez", "258 Cedar St", "laura.martinez@example.com", "password15", 15, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 28), new TimeOnly(23, 0));
            AddAppointment("Chris Lopez", "369 Spruce St", "chris.lopez@example.com", "password16", 16, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 29), new TimeOnly(10, 30));
            AddAppointment("Erica Rodriguez", "741 Birch St", "erica.rodriguez@example.com", "password17", 17, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 4, 30), new TimeOnly(11, 30));
            AddAppointment("Daniel Perez", "852 Pine St", "daniel.perez@example.com", "password18", 18, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 5, 1), new TimeOnly(12, 30));
            AddAppointment("Alexis Hernandez", "963 Elm St", "alexis.hernandez@example.com", "password19", 19, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 5, 2), new TimeOnly(13, 30));
            AddAppointment("Justin Garcia", "159 Maple St", "justin.garcia@example.com", "password20", 20, DoctorsFunctions.DoctorsList[i].DoctorName, new DateOnly(2024, 5, 3), new TimeOnly(14, 30));
        }
    }

    public static void DisplayAppointments()
    {
        var groupedAppointments = Appointments.appointmentList.GroupBy(a => a.DoctorAssigned);

        foreach (var doctorGroup in groupedAppointments)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            AnsiConsole.WriteLine($"Doctor: {doctorGroup.Key}");
            Console.ResetColor();
            int count = 0;
            foreach (var appointment in doctorGroup)
            {
                AnsiConsole.WriteLine($"Nombre: {appointment.Name}, Dirección: {appointment.Address}, Email: {appointment.Email}, ID: {appointment.PatientID}, Fecha: {appointment.AppointmentDate}, Hora: {appointment.AppointmentTime}");
                count++;
                if (count >= 20)
                {
                    break;
                }
            }
        }
    }


    public static void AddNewAppointment()
    {
        AnsiConsole.WriteLine("Agregar nueva cita:");
        string? name = AnsiConsole.Ask<string>("Nombre:");
        string? address = AnsiConsole.Ask<string>("Dirección:");
        string ?email = AnsiConsole.Ask<string>("Email:");
        string? password = AnsiConsole.Ask<string>("Contraseña:");
        double patientID = appointmentList.Count + 1; // Assign a unique ID
        string? doctorAssigned = AnsiConsole.Ask<string>("Doctor asignado:");
        DateOnly appointmentDate = AnsiConsole.Ask<DateOnly>("Fecha de la cita:");
        TimeOnly appointmentTime = AnsiConsole.Ask<TimeOnly>("Hora de la cita:");

        AddAppointment(name, address, email, password, patientID, doctorAssigned, appointmentDate, appointmentTime);

        AnsiConsole.WriteLine("Nueva cita agregada exitosamente.");
    }

    public static void RemoveAppointmentByID(double patientID)
    {
        var appointmentToRemove = appointmentList.FirstOrDefault(a => a.PatientID == patientID);
        if (appointmentToRemove != null)
        {
            appointmentList.Remove(appointmentToRemove);
            AnsiConsole.WriteLine($"Cita con la ID {patientID} eliminada exitosamente.");
        }
        else
        {
            AnsiConsole.WriteLine($"No se encontró ninguna cita para la siguiente ID: {patientID}...");
        }
    }

    public static void FindAppointmentByID(double patientID)
    {
        var appointment = appointmentList.FirstOrDefault(a => a.PatientID == patientID);
        if (appointment != null)
        {
            AnsiConsole.WriteLine($"Cita existente {patientID}:");
            AnsiConsole.WriteLine($"Nombre: {appointment.Name}, Dirección: {appointment.Address}, Email: {appointment.Email}, Doctor asignado: {appointment.DoctorAssigned}, Fecha: {appointment.AppointmentDate}, Tiempo: {appointment.AppointmentTime}");
        }
        else
        {
            AnsiConsole.WriteLine($"No appointment found for PatientID {patientID}.");
        }
    }
    public static void UpdateAppointmentByIDAll(double patientID, string? name = null, string? address = null, string? email = null, string? password = null, string? doctorAssigned = null, DateOnly? appointmentDate = null, TimeOnly? appointmentTime = null)
    {
        var appointment = appointmentList.FirstOrDefault(a => a.PatientID == patientID);
        if (appointment != null)
        {
            appointment.Name = name ?? appointment.Name;
            appointment.Address = address ?? appointment.Address;
            appointment.Email = email ?? appointment.Email;
            appointment.Password = password ?? appointment.Password;
            appointment.DoctorAssigned = doctorAssigned ?? appointment.DoctorAssigned;
            appointment.AppointmentDate = appointmentDate ?? appointment.AppointmentDate;
            appointment.AppointmentTime = appointmentTime ?? appointment.AppointmentTime;

            AnsiConsole.WriteLine($"Cita con la ID {patientID} fue actualizada exitosamente.");

            // Mostrar la información actualizada
            AnsiConsole.WriteLine("Información actualizada de la cita:");
            AnsiConsole.WriteLine($"Nombre: {appointment.Name}");
            AnsiConsole.WriteLine($"Dirección: {appointment.Address}");
            AnsiConsole.WriteLine($"Email: {appointment.Email}");
            AnsiConsole.WriteLine($"Contraseña: {appointment.Password}");
            AnsiConsole.WriteLine($"Doctor asignado: {appointment.DoctorAssigned}");
            AnsiConsole.WriteLine($"Fecha de la cita: {appointment.AppointmentDate}");
            AnsiConsole.WriteLine($"Hora de la cita: {appointment.AppointmentTime}");
        }
        else
        {
            AnsiConsole.WriteLine($"No se encontró ninguna cita para la siguiente ID: {patientID}...");
        }
    }

   public static void UpdateAppointmentVariableByIDIndividually(double patientID)
    {
        var appointment = appointmentList.FirstOrDefault(a => a.PatientID == patientID);
        if (appointment != null)
        {
            AnsiConsole.WriteLine("Seleccionar la información que desea actualizar:");
            AnsiConsole.WriteLine("1. Nombre");
            AnsiConsole.WriteLine("2. Dirección");
            AnsiConsole.WriteLine("3. Email");
            AnsiConsole.WriteLine("4. Contraseña");
            AnsiConsole.WriteLine("5. Doctor asignado");
            AnsiConsole.WriteLine("6. Fecha de la cita");
            AnsiConsole.WriteLine("7. Hora de la cita");

            var choice = AnsiConsole.Ask<int>("Ingresar su opción:");
            switch (choice)
            {
                case 1:
                    appointment.Name = AnsiConsole.Ask<string>("Ingrese nuevo nombre:");
                    break;
                case 2:
                    appointment.Address = AnsiConsole.Ask<string>("Ingrese nuevo dirección:");
                    break;
                case 3:
                    appointment.Email = AnsiConsole.Ask<string>("Ingrese nuevo Email:");
                    break;
                case 4:
                    appointment.Password = AnsiConsole.Ask<string>("Ingrese nueva contraseña:");
                    break;
                case 5:
                    appointment.DoctorAssigned = AnsiConsole.Ask<string>("Ingrese nuevo doctor asignado:");
                    break;
                case 6:
                    appointment.AppointmentDate = AnsiConsole.Ask<DateOnly>("Ingrese nueva fecha:");
                    break;
                case 7:
                    appointment.AppointmentTime = AnsiConsole.Ask<TimeOnly>("Ingrese nueva hora:");
                    break;
                default:
                    AnsiConsole.WriteLine("Opción invalida....");
                    break;
            }

            AnsiConsole.WriteLine($"Cita con la ID {patientID} fue actualizada exitosamente.");

            // Mostrar la información actualizada
            AnsiConsole.WriteLine("Información actualizada de la cita:");
            AnsiConsole.WriteLine($"Nombre: {appointment.Name}");
            AnsiConsole.WriteLine($"Dirección: {appointment.Address}");
            AnsiConsole.WriteLine($"Email: {appointment.Email}");
            AnsiConsole.WriteLine($"Contraseña: {appointment.Password}");
            AnsiConsole.WriteLine($"Doctor asignado: {appointment.DoctorAssigned}");
            AnsiConsole.WriteLine($"Fecha de la cita: {appointment.AppointmentDate}");
            AnsiConsole.WriteLine($"Hora de la cita: {appointment.AppointmentTime}");
        }
        else
        {
            AnsiConsole.WriteLine($"No se encontró ninguna cita para la siguiente ID: {patientID}...");
        }
    }


}
