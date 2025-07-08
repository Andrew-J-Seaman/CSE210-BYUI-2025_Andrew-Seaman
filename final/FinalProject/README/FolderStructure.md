******************************************************************************************
AUTHOR: Andrew Seaman
DATE: 2025-07-08
SOURCE: ChatGPT

DESCRIPTION: CSE 210 Final Project Folder Structure
This document provides a suggested folder structure for the scoped project: Simulated Vehicle Telemetry Processor.
******************************************************************************************

    🧱 Suggested Folder Structure

    VehicleTelemetry/
    ├── Program.cs
    ├── Models/
    │   ├── Vehicle.cs
    │   ├── GasVehicle.cs
    │   ├── HybridVehicle.cs
    │   └── Entry.cs
    ├── Services/
    │   ├── DataLoader.cs
    │   ├── DataTransformer.cs
    │   ├── ReportGenerator.cs
    │   └── AppController.cs
    ├── Data/
    │   └── test_data.csv / .json
    └── Utils/
        └── CsvParser.cs (optional helper)