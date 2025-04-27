using System;
using System.Collections.Generic;

public class Incident
{
    public string Type { get; }
    public string Location { get; }

    public Incident(string type, string location)
    {
        Type = type;
        Location = location;
    }
}

public abstract class EmergencyUnit
{
    public string Name { get; protected set; }
    public int Speed { get; protected set; }

    public abstract bool CanHandle(string incidentType);
    public abstract void RespondToIncident(Incident incident);
}

public class Police : EmergencyUnit
{
    public Police(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType) =>
        incidentType.Equals("Crime", StringComparison.OrdinalIgnoreCase);

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is en route to {incident.Location} at {Speed} mph.");
        Console.WriteLine($"{Name} is handling crime scene at {incident.Location}.");
    }
}

public class Firefighter : EmergencyUnit
{
    public Firefighter(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType) =>
        incidentType.Equals("Fire", StringComparison.OrdinalIgnoreCase);

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is en route to {incident.Location} at {Speed} mph.");
        Console.WriteLine($"{Name} is extinguishing fire at {incident.Location}.");
    }
}

public class Ambulance : EmergencyUnit
{
    public Ambulance(string name, int speed)
    {
        Name = name;
        Speed = speed;
    }

    public override bool CanHandle(string incidentType) =>
        incidentType.Equals("Medical", StringComparison.OrdinalIgnoreCase);

    public override void RespondToIncident(Incident incident)
    {
        Console.WriteLine($"{Name} is en route to {incident.Location} at {Speed} mph.");
        Console.WriteLine($"{Name} is treating patients at {incident.Location}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var units = new List<EmergencyUnit>();
        int score = 0;

        ConfigureUnits(units);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"\n--- Turn {i + 1} ---");

            var incident = GetUserIncident();
            Console.WriteLine($"Incident: {incident.Type} at {incident.Location}");

            var responder = FindResponder(units, incident);

            if (responder != null)
            {
                responder.RespondToIncident(incident);
                score += 10;
                Console.WriteLine($"+10 points\nCurrent Score: {score}");
            }
            else
            {
                score -= 5;
                Console.WriteLine($"No available units! -5 points\nCurrent Score: {score}");
            }
        }

        Console.WriteLine($"\nFinal Score: {score}");
        Console.ReadLine();
    }

    static void ConfigureUnits(List<EmergencyUnit> units)
    {
        Console.WriteLine("-- Emergency Unit Configuration --");
        AddUnits("Police", units);
        AddUnits("Firefighter", units);
        AddUnits("Ambulance", units);
    }

    static void AddUnits(string unitType, List<EmergencyUnit> units)
    {
        Console.Write($"Number of {unitType} units: ");
        if (!int.TryParse(Console.ReadLine(), out int count) || count < 0)
        {
            Console.WriteLine("Invalid input. Defaulting to 0.");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Console.Write($"{unitType} Unit {i + 1} Name: ");
            string name = Console.ReadLine().Trim();

            Console.Write($"Speed (mph): ");
            if (!int.TryParse(Console.ReadLine(), out int speed) || speed <= 0)
            {
                Console.WriteLine("Invalid speed. Using default 50 mph.");
                speed = 50;
            }

            switch (unitType.ToLower())
            {
                case "police":
                    units.Add(new Police(name, speed));
                    break;
                case "firefighter":
                    units.Add(new Firefighter(name, speed));
                    break;
                case "ambulance":
                    units.Add(new Ambulance(name, speed));
                    break;
            }
        }
    }

    static Incident GetUserIncident()
    {
        string type;
        do
        {
            Console.Write("Enter incident type (Crime/Fire/Medical): ");
            type = Console.ReadLine().Trim();
        } while (!IsValidIncidentType(type));

        Console.Write("Enter location: ");
        string location = Console.ReadLine().Trim();

        return new Incident(type, location);

        bool IsValidIncidentType(string input) =>
            input.Equals("Crime", StringComparison.OrdinalIgnoreCase) ||
            input.Equals("Fire", StringComparison.OrdinalIgnoreCase) ||
            input.Equals("Medical", StringComparison.OrdinalIgnoreCase);
    }

    static EmergencyUnit FindResponder(List<EmergencyUnit> units, Incident incident)
    {
        foreach (var unit in units)
        {
            if (unit.CanHandle(incident.Type))
            {
                return unit;
            }
        }
        return null;
    }
}