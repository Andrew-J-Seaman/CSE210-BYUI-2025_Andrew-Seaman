******************************************************************************************
AUTHOR: Andrew Seaman
DATE: 2025-07-08
SOURCE: ChatGPT

DESCRIPTION: CSE 210 Final Project - Class Diagram
This document provides a class diagram and project structure for the scoped project: Simulated Vehicle Telemetry Processor. The project involves creating a system to process and analyze vehicle telemetry data, including fuel efficiency calculations, data loading from CSV/JSON, and generating reports.
******************************************************************************************

Here’s a clear class diagram + project structure for your scoped project: Simulated Vehicle Telemetry Processor.

⸻

🔧 Class Diagram (UML-Style Overview)

         +-------------------+
         |     Vehicle       |  <--- Abstract Base Class
         +-------------------+
         | - id: string       |
         | - make: string     |
         | - model: string    |
         | - year: int        |
         +-------------------+
         | +CalculateFuelEfficiency(): double [abstract]
         | +AddEntry(entry: Entry): void
         | +GetEntries(): List<Entry>
         +-------------------+
                  ▲
        ┌─────────┼─────────┐
        ▼                   ▼
+----------------+   +------------------+
|   GasVehicle   |   |  HybridVehicle   |  <-- Derived Classes
+----------------+   +------------------+
| +CalculateFuelEfficiency() override   |
+----------------+   +------------------+


+------------------+
|     Entry        |  <-- One record of telemetry data
+------------------+
| - timestamp: DateTime     |
| - speed: double (km/h)    |
| - rpm: int                |
| - fuelLevel: double (%)   |
| - distance: double (km)   |
+------------------+


+------------------+
|  DataLoader      |  <-- Loads CSV/JSON into vehicle + entry objects
+------------------+
| +LoadFromCSV(path): List<Vehicle>
| +LoadFromJSON(path): List<Vehicle>
+------------------+


+------------------+
| DataTransformer  |  <-- Transform/aggregate vehicle data
+------------------+
| +GetAverageSpeed(vehicle): double
| +GetTripCount(vehicle): int
| +FilterEntries(vehicle, filter): List<Entry>
+------------------+


+------------------+
|  ReportGenerator |  <-- Outputs metrics to console or file
+------------------+
| +PrintSummary(vehicle): void
+------------------+


+------------------+
|   AppController  |  <-- Entry point, coordinates all logic
+------------------+
| +Run(): void
+------------------+