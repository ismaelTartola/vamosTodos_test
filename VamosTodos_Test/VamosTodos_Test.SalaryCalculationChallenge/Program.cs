// See https://aka.ms/new-console-template for more information

// Ejemplo de uso de la función
Console.WriteLine("Ingrese la hora de inicio del trabajador (HH:MM):");
string horaInicioStr = Console.ReadLine();

Console.WriteLine("Ingrese la hora de fin del trabajador (HH:MM):");
string horaFinStr = Console.ReadLine();

Console.WriteLine("Ingrese el salario por hora (horario normal):");
double salarioNormal = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Ingrese el Factor multiplicador por hora (horario normal):");
double factorMultiplicador = Convert.ToDouble(Console.ReadLine());

double salarioTotal = CalcularSalarioTotal(horaInicioStr, horaFinStr, salarioNormal, factorMultiplicador);
Console.WriteLine("El salario total del día es: $" + salarioTotal);

static double CalcularSalarioTotal(string horaInicioStr, string horaFinStr, double salarioNormal, double factorMultiplicador)
{
    // Convertir las horas de inicio y fin a objetos DateTime
    DateTime horaInicio = DateTime.ParseExact(horaInicioStr, "HH:mm", null);
    DateTime horaFin = DateTime.ParseExact(horaFinStr, "HH:mm", null);

    // Definir el horario normal de trabajo
    DateTime horaInicioNormal = DateTime.ParseExact("08:00", "HH:mm", null);
    DateTime horaFinNormal = DateTime.ParseExact("18:00", "HH:mm", null);

    double salarioTotal = 0;

    // Calcular salario durante el horario normal
    if (horaInicio >= horaInicioNormal && horaFin <= horaFinNormal)
    {
        // El trabajador trabajó todo el día en horario normal
        salarioTotal = (horaFin - horaInicio).TotalHours * salarioNormal;
    }
    else
    {
        double horasExtras = 0;        

        // Calcular salario fuera del horario normal
        if (horaInicio < horaInicioNormal)
            horasExtras += (horaInicioNormal - horaInicio).TotalHours;
        if (horaFin > horaFinNormal)
            horasExtras += (horaFin - horaFinNormal).TotalHours;

        // Calcular salario fuera del horario normal
        double horasNormales = ((horaFin - horaInicio).TotalHours - horasExtras);

        salarioTotal = (horasNormales * salarioNormal) + (horasExtras * salarioNormal * factorMultiplicador);
    }

    return salarioTotal;
}
