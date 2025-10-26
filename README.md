# Introduction 
This Repository contains the code for the tool used to evaluate Diagnostic tests, which were executed using the ENNA Framework (New Test Automation Framework for Infotainment System.

# Getting Started

1.	Installation process
The Diagnostic Evaluation Tool consists of two main components:

Front-End GUI Application – developed as part of this thesis project.

Database Management System – implemented in PostgreSQL and developed as a separate, complementary thesis project.

This documentation focuses on the Front-End GUI component of the tool.

    
2.	Software dependencies
   Required NuGet Packages

To successfully build and run this application, ensure that the following packages are installed:

Package	Version
linq2db.PostgreSQL	2.9.8
System.Runtime.CompilerServices.Unsafe	4.6.0
Microsoft.Bcl.AsyncInterfaces	1.1.0
System.Buffers	4.5.0
System.Numerics.Vectors	4.5.0
Npgsql	4.0.12
System.ValueTuple	4.5.0
linq2db	3.1.1
System.Memory	4.5.3
System.Text.Encodings.Web	4.6.0
System.Text.Json	4.6.0
System.Threading.Tasks.Extensions	4.5.4

Make sure these packages are restored via NuGet before building the solution.
    
3. Installation & Setup
   i. Clone this repository:
         git clone https://github.com/<your-username>/<repo-name>.git

   ii. Open the solution file Evaluation Tool for ENNA.sln in Visual Studio 2017 or later.

   iii. Restore NuGet dependencies:
       Tools → NuGet Package Manager → Restore Packages

   iv. Configure the PostgreSQL database connection string in the application settings.
    v. Build and run the solution.

4. Development Notes

  This software is currently in the prototype phase.

  Features, functionality, and UI design are subject to continuous improvement.

  The application is intended solely for research and development purposes and not for customer deployment.

5. Latest Release

  The latest version and release notes will be published once the prototype reaches a stable milestone.

6. API Reference

  Detailed API and data model documentation will be added in a future release.

