using System;
using System.Linq;
using Spectre.Console;

public class SessionHandling : OptionsMenu
{
     public static bool Login(string? email, string? password)
    {
        // Check if the provided email and password match any doctor's credentials
        var doctor = DoctorsFunctions.DoctorsList.FirstOrDefault(d => d.DoctorEmail == email && d.DoctorPassword == password);

        if (doctor != null)
        {
            // Check if the doctor is an admin
            bool isAdmin = doctor.IsAdmin;
            if (isAdmin)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                AnsiConsole.WriteLine($"\nBienvenido, Dr. {doctor.DoctorName} (Admin)!");
                Console.ResetColor();
                OptionsMenu.AdminMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                AnsiConsole.WriteLine($"\nBienvenido, Dr. {doctor.DoctorName}!");
                Console.ResetColor();
            }
            return true;
        }
        else
        {
            AnsiConsole.WriteLine("Invalid email or password.");
            return false;
        }
    }

    public static void SetAdmin(string email)
    {
        var doctor = DoctorsFunctions.DoctorsList.FirstOrDefault(d => d.DoctorEmail == email);
        if (doctor != null)
        {
            doctor.IsAdmin = true;
            AnsiConsole.WriteLine($"{doctor.DoctorName} has been set as an admin.");
        }
        else
        {
            AnsiConsole.WriteLine("Doctor not found.");
        }
    }

    public static void SetNonAdmin(string email)
    {
        var doctor = DoctorsFunctions.DoctorsList.FirstOrDefault(d => d.DoctorEmail == email);
        if (doctor != null)
        {
            doctor.IsAdmin = false;
            AnsiConsole.WriteLine($"{doctor.DoctorName} has been set as a non-admin.");
        }
        else
        {
            AnsiConsole.WriteLine("Doctor not found.");
        }
    }
}