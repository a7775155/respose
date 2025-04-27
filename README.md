# Emergency Response Simulation

**Author:** [Ashenafi Abera]

## Project Description

This C# console application simulates an emergency response system where different types of emergency units (Police, Firefighters, Ambulances) respond to various incidents (Crime, Fire, Medical emergencies).  
The user configures the number and attributes of each unit at the beginning. Then, through a turn-based system, the user inputs incidents, and appropriate units are dispatched automatically based on the type of emergency.  
The game tracks and displays a score based on the successful handling of incidents.

## Features
- Configure different emergency units (name and speed).
- Handle three types of incidents: Crime, Fire, and Medical emergencies.
- Award points for successful responses and deduct points for failures.
- Apply Object-Oriented Programming (OOP) concepts for scalability and maintainability.

## How to Run
1. Open the project in Visual Studio or any C# IDE.
2. Build and run the program.
3. Follow the on-screen prompts to configure units and simulate emergency incidents.
# Short Report

## Project Title
**Emergency Response Simulation**

## OOP Concepts Applied
- **Abstraction:**  
  `EmergencyUnit` is an abstract class that defines common behavior for all emergency units (Police, Firefighter, Ambulance) without implementing everything.
- **Inheritance:**  
  `Police`, `Firefighter`, and `Ambulance` classes inherit from the `EmergencyUnit` abstract class.
- **Polymorphism:**  
  `EmergencyUnit` defines abstract methods (`CanHandle`, `RespondToIncident`) that are overridden differently in each derived class.
- **Encapsulation:**  
  Properties like `Name` and `Speed` are protected and managed through constructors, keeping internal state controlled.
- **Composition:**  
  `Program` class uses a `List<EmergencyUnit>` to manage multiple units and dispatch them dynamically.

## Simple Class Diagram (Text Version)
+-------------------------+ | EmergencyUnit | (abstract) +-------------------------+ | #Name: string | | #Speed: int | +-------------------------+ | +CanHandle(type): bool | (abstract) | +RespondToIncident(incident): void | (abstract) +-------------------------+ ▲ ▲ ▲ | | | +---------+ +----------+ +------------+ | Police | | Firefighter | | Ambulance | +---------+ +----------+ +------------+ | Overrides CanHandle | | Overrides RespondToIncident | +----------------------+

## Lessons Learned / Challenges Faced
- **Choosing the right OOP structure:**  
  Initially, designing which parts should be abstract (like `EmergencyUnit`) and which parts should be specific (like `Police`, `Firefighter`, `Ambulance`) was a bit tricky but became clear by applying the "Is-A" relationship principle.
- **User input validation:**  
  Managing user inputs for speed, names, and incident types needed careful handling to prevent crashes or invalid states.
- **Balancing simplicity and flexibility:**  
  The goal was to make the project small yet easily expandable (e.g., new unit types like "Rescue Dogs" or "Helicopter Medics" can be added with minimal code changes).

