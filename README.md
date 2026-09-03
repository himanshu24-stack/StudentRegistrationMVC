# ?? Student Registration System (ASP.NET Core MVC)

[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-blue.svg)](https://learn.microsoft.com/aspnet/core/)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0-green.svg)](https://learn.microsoft.com/ef/core/)
[![Database](https://img.shields.io/badge/SQL%20Server-LocalDB-red.svg)](https://learn.microsoft.com/sql/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple.svg)](https://getbootstrap.com/)

A modern, responsive, and robust **Student Registration System** built with **ASP.NET Core MVC**, **Entity Framework Core**, and **Microsoft SQL Server**.

The system enables academic institutions to register students through an organized, interactive multi-section form, validate data both client-side and server-side, persist information into a SQL Server database, and generate comprehensive student profile dossiers.

---

## ? Features

- **Multi-Section Organized Registration Form**:
  - **Section A: Personal Information** (Name, DOB, Gender radio buttons, Blood group dropdown).
  - **Section B: Contact Information** (Email, 10-digit mobile number).
  - **Section C: Address Information** (Residential address textarea, City, State, Pincode, Country).
  - **Section D: Academic Information** (Course, Department, Semester dropdowns, Enrollment No., Institution, Percentage).
  - **Section E: Parent / Guardian Information** (Father, Mother, Guardian name and contact).
  - **Section F: Additional Information** (Hobbies textarea, Hosteller toggle with dynamic hostel block allocation, Emergency contact).

- **Dynamic Interactive UI (JavaScript)**:
  - Toggling **"Is Hosteller?"** dynamically reveals or hides the **Hostel Name** field with instant HTML5 validation constraint adjustments.

- **Dual-Tier Validation**:
  - **Client-Side**: Real-time feedback powered by jQuery Unobtrusive Validation using `asp-validation-for` and `asp-validation-summary`.
  - **Server-Side**: Model-level validation enforced via `ModelState.IsValid` and Data Annotations.

- **Database Persistence with EF Core**:
  - Connects to **Microsoft SQL Server LocalDB**.
  - Automatically initializes and creates the database schema (`StudentRegistrationDB`) and `Students` table on startup without requiring manual SQL scripts.

- **Student Profile & Dossier**:
  - Detailed view summarizing all 25+ attributes in categorized tables.
  - Built-in **Print / Save PDF** functionality.

- **Registered Students Directory**:
  - Tabular list of all enrolled students with search badges and direct detail links.

---

## ??? Technology Stack

- **Framework**: .NET 10 (C#)
- **Architecture**: ASP.NET Core MVC (Model-View-Controller)
- **Database & ORM**: Microsoft SQL Server LocalDB + Entity Framework Core (`Microsoft.EntityFrameworkCore.SqlServer`)
- **Frontend / Styling**: Bootstrap 5, Bootstrap Icons, HTML5, CSS3, JavaScript
- **Client Validation**: jQuery, `jquery.validate`, `jquery.validate.unobtrusive`

---

## ?? Project Structure

```
StudentRegistrationMVC/
¦
+-- Controllers/
¦   +-- HomeController.cs              # Landing page controller
¦   +-- StudentController.cs           # Student registration, details, validation & listing
¦
+-- Data/
¦   +-- ApplicationDbContext.cs        # EF Core DbContext with Student entity configuration
¦
+-- Models/
¦   +-- Student.cs                     # Comprehensive model with Data Annotations
¦   +-- ErrorViewModel.cs              # Error handling view model
¦
+-- Views/
¦   +-- Home/
¦   ¦   +-- Index.cshtml               # Home portal landing page
¦   +-- Student/
¦   ¦   +-- Create.cshtml              # Registration form with dynamic JS & sections
¦   ¦   +-- Details.cshtml             # Comprehensive student profile & tabular dossier
¦   ¦   +-- List.cshtml                # Table listing all registered students
¦   ¦   +-- Success.cshtml             # Registration confirmation with Student ID
¦   +-- Shared/
¦   ¦   +-- _Layout.cshtml             # Master layout with responsive navbar & footer
¦   ¦   +-- _ValidationScriptsPartial.cshtml
¦   +-- _ViewImports.cshtml
¦   +-- _ViewStart.cshtml
¦
+-- wwwroot/
¦   +-- css/site.css                   # Custom styles for cards, form groups & badges
¦   +-- js/site.js
¦
+-- GlobalUsings.cs                    # C# 10+ Global Usings demonstration
+-- Program.cs                         # DbContext injection, auto DB creation, and middleware
+-- appsettings.json                   # SQL Server LocalDB connection string
+-- StudentRegistrationMVC.sln         # Visual Studio Solution File
```

---

## ?? Getting Started

### Prerequisites
- [Visual Studio 2022+ / 2026](https://visualstudio.microsoft.com/) or [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Microsoft SQL Server LocalDB (included with Visual Studio `.NET desktop development` / `ASP.NET and web development` workloads)

### Steps to Run

1. **Clone or Download the Repository**:
   ```bash
   git clone https://github.com/<your-username>/StudentRegistrationMVC.git
   cd StudentRegistrationMVC
   ```

2. **Open in Visual Studio**:
   - Double-click `StudentRegistrationMVC.sln`.

3. **Run the Project**:
   - Press <kbd>F5</kbd> or click the green **Run** button in Visual Studio.
   - The application will automatically build, create the database, and launch your browser at:
     ```
     http://localhost:5038/Student/Create
     ```

4. **Or run via .NET CLI**:
   ```bash
   dotnet restore
   dotnet build
   dotnet run --urls "http://localhost:5038"
   ```

---

## ?? Database Configuration

The application is configured to connect to **SQL Server LocalDB** out of the box in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StudentRegistrationDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

On first run, `context.Database.EnsureCreated()` in `Program.cs` automatically creates the database and table.
