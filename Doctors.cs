using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;

public class DoctorsFunctions
{
    public string DoctorName { get; set; }
    public string DoctorPassword { get; set; }
    public string DoctorEmail { get; set; }
    public bool IsAdmin { get; set; }
    public string Specialty { get; set; }

    public DoctorsFunctions(string aDoctorName, string aDoctorPassword, string aDoctorEmail, bool aIsAdmin = false, string aSpecialty = "Doctor General")
    {
        DoctorName = aDoctorName;
        DoctorPassword = aDoctorPassword;
        DoctorEmail = aDoctorEmail;
        Specialty = aSpecialty;
        IsAdmin = aIsAdmin;
    }

    public static List<DoctorsFunctions> DoctorsList = new List<DoctorsFunctions>();
    static DoctorsFunctions()
    {
        DoctorsList.Add(new DoctorsFunctions("Smith", "password1", "smith@example.com", true, "Medicina general"));
        DoctorsList.Add(new DoctorsFunctions("Johnson", "password2", "johnson@example.com", false, "Cardiología"));
        DoctorsList.Add(new DoctorsFunctions("Brown", "password3", "brown@example.com", false, "Dermatología"));
        DoctorsList.Add(new DoctorsFunctions("Wilson", "password4", "wilson@example.com", false, "Endocrinología"));
        DoctorsList.Add(new DoctorsFunctions("Anderson", "password5", "anderson@example.com", false, "Gastroenterología"));
        DoctorsList.Add(new DoctorsFunctions("Garcia", "password6", "garcia@example.com", false, "Geriatría"));
        DoctorsList.Add(new DoctorsFunctions("Perez", "password7", "perez@example.com", false, "Hematología"));
        DoctorsList.Add(new DoctorsFunctions("Hernandez", "password8", "hernandez@example.com", false, "Inmunología"));
        DoctorsList.Add(new DoctorsFunctions("Adams", "password9", "adams@example.com", false, "Medicina interna"));
    }


    public static void AddDoctor()
    {
        AnsiConsole.WriteLine("Agregar un nuevo doctor:");
        string? name = AnsiConsole.Ask<string>("Nombre:");
        string? password = AnsiConsole.Ask<string>("Contraseña:");
        string? specialty = AnsiConsole.Ask<string>("Especialidad (opcional):");

        DoctorsList.Add(new DoctorsFunctions(name, password, specialty));

        AnsiConsole.WriteLine("Nuevo doctor agregado exitosamente.");
    }

    public static void DisplayDoctors()
    {
        foreach (var doctor in DoctorsList)
        {
            AnsiConsole.WriteLine($"Dr.{doctor.DoctorName}, Especialidad: {doctor.Specialty}");
        }
    }

    public static void UpdateDoctorSpecialty(string doctorName)
    {
        var doctor = DoctorsList.FirstOrDefault(d => d.DoctorName == doctorName);
        if (doctor != null)
        {
            string newSpecialty = AnsiConsole.Ask<string>("Ingrese la nueva especialidad:");
            doctor.Specialty = newSpecialty;
            AnsiConsole.WriteLine($"Especialidad del doctor {doctorName} actualizada exitosamente a {newSpecialty}.");
        }
        else
        {
            AnsiConsole.WriteLine($"No se encontró al doctor {doctorName}.");
        }
    }

    public static void RemoveDoctor(string doctorName)
    {
        var doctorToRemove = DoctorsList.FirstOrDefault(d => d.DoctorName == doctorName);
        if (doctorToRemove != null)
        {
            DoctorsList.Remove(doctorToRemove);
            AnsiConsole.WriteLine($"Doctor {doctorName} eliminado exitosamente.");
        }
        else
        {
            AnsiConsole.WriteLine($"No se encontró al doctor {doctorName}.");
        }
    }

    public static string? DisplayDoctorsMenu()
    {
        AnsiConsole.WriteLine("Selecciona un doctor:");
        var doctors = DoctorsList.Select(d => d.DoctorName).ToArray();

        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string?>()
                .Title("Doctores")
                .PageSize(10)
                .AddChoices(doctors)
        );

        AnsiConsole.WriteLine($"Has seleccionado: {choice}");
        return choice;
    }

}
