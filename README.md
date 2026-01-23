<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 8.0" />
  <img src="https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C# 12.0" />
  <img src="https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white" alt="SQL Server" />
  <img src="https://img.shields.io/badge/EF%20Core-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="Entity Framework Core" />
  <img src="https://img.shields.io/badge/ASP.NET-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="ASP.NET Core MVC" />
  <img src="https://img.shields.io/badge/Identity-Auth-000000?style=for-the-badge&logo=openid&logoColor=white" alt="Identity" />
  <img src="https://img.shields.io/badge/License-MIT-blue?style=for-the-badge" alt="License: MIT" />
</p>

<h1 align="center">🎓ScholarHub</h1>

<p align="center">
  <strong>A robust, N-Tier Architecture School Management System built with ASP.NET Core MVC</strong>
</p>

<p align="center">
  ScholarHub  is a comprehensive academic management solution designed to streamline the administration of educational institutes. It provides full control over departments, students, and user roles through a secure, scalable, and user-friendly web interface.
</p>

---

## 📋 Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [Architecture](#-architecture)
- [Project Structure](#-project-structure)
- [Prerequisites](#-prerequisites)
- [Installation](#-installation)
- [Modules](#-modules)
- [Contributing](#-contributing)

---

## 🌟 Overview

**ScholarHub** is a feature-rich School Management System tailored to bridge the gap between administration and data management. Built on the **ASP.NET Core MVC** framework and following the **Repository Pattern**, it ensures clean code separation and maintainability. The system empowers administrators to manage academic departments, student records, and system access with granular security controls using ASP.NET Core Identity.

### Key Highlights

- 🔐 **Robust Security** — Integrated ASP.NET Core Identity for secure Authentication & Authorization
- 🏛️ **Organization Management** — Complete lifecycle management for Departments and details
- 👨‍🎓 **Student Affairs** — Comprehensive student profiles, enrollment, and record tracking
- 🛠️ **Scalable Architecture** — Built using N-Tier architecture (DAL, BLL, PL) for maximum extensibility
- 🔄 **Efficient Data Access** — Implements Repository Pattern for abstract and clean data handling
- 👥 **Role-Based Access** — Dynamic Role and User management system

---

## ✨ Features

### 🔐 Authentication & Security
| Feature | Description |
|---------|-------------|
| Admin Sign-in | Secure login portal for administrators and staff |
| Role Management | Create, edit, and assign roles dynamically |
| User Administration | Manage system users and their access levels |
| Access Control | Route protection based on roles and permissions |

### 🏛️ Department Module
| Feature | Description |
|---------|-------------|
| Create Department | Add new academic departments with detailed info |
| Department Listing | View and filter all active departments |
| Update Records | Modify department details and codes |
| Safe Deletion | Soft or hard delete capabilities for department cleanup |

### 👨‍🎓 Student Module
| Feature | Description |
|---------|-------------|
| Student Enrollment | Register new students to specific departments |
| Profile Management | Manage student personal and academic data |
| Department Allocation | Assign or transfer students between departments |
| Search & Filter | Quick lookup for students by name or ID |

---

## 🏗️ Architecture

EduCore follows a strict **N-Tier Architecture** to ensure separation of concerns:

```
┌────────────────────────────────────────────────────────────┐
│                       ITI.MVC.PL                           │
│              (Presentation Layer - MVC)                    │
│      Controllers, Views, ViewModels, wwwroot               │
├────────────────────────────────────────────────────────────┤
│                       ITI.MVC.BLL                          │
│               (Business Logic Layer)                       │
│           Interfaces, Repositories (Logic)                 │
├────────────────────────────────────────────────────────────┤
│                       ITI.MVC.DAL                          │
│                (Data Access Layer)                         │
│         DbContext, Entities (Models), Migrations           │
└────────────────────────────────────────────────────────────┘
```

### Layer Responsibilities

| Layer | Responsibility |
|-------|----------------|
| **DAL** | Direct interaction with SQL Server, EF Core Context configuration, and Entity definitions. |
| **BLL** | Encapsulates business rules, interfaces, and implements the **Repository Pattern**. |
| **PL** | Handles HTTP requests, renders Views (UI), and manages User Interaction via Controllers. |

---

## 📁 Project Structure

```
EduCore/
├── 📂 ITI.MVC.PL/                  # Presentation Layer
│   ├── Controllers/
│   │   ├── AccountController.cs    # Auth & Login logic
│   │   ├── DepartmentController.cs # Department CRUD
│   │   ├── StudentController.cs    # Student CRUD
│   │   ├── RoleController.cs       # Role Management
│   │   └── UserController.cs       # User Management
│   ├── Views/                      # Razor Views (UI)
│   ├── wwwroot/                    # Static Assets (CSS, JS, Libs)
│   └── Program.cs                  # App Configuration & DI
│
├── 📂 ITI.MVC.BLL/                 # Business Logic Layer
│   ├── Interfaces/                 # Repository Interfaces
│   └── Repositories/               # Repository Implementations
│
├── 📂 ITI.MVC.DAL/                 # Data Access Layer
│   ├── Context/                    # SchoolDBContext
│   └── Models/                     # Database Entities (Student, Dept, etc.)
│
└── 📄 ITI.MVC.sln                  # Solution file
```

---

## 🛠️ Technologies Used

| Technology | Purpose |
|------------|---------|
| ![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet) | Core Framework |
| ![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET-MVC-512BD4?logo=dotnet) | Web Framework |
| ![EF Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?logo=dotnet) | ORM & Data Access |
| ![SQL Server](https://img.shields.io/badge/SQL%20Server-Latest-CC2927?logo=microsoftsqlserver) | Database Engine |
| ![Identity](https://img.shields.io/badge/Identity-Core-000000?logo=security) | Security & Auth |
| ![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?logo=bootstrap) | UI Styling |

---

## 📋 Prerequisites

Before running EduCore, ensure you have the following installed:

- ✅ [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- ✅ [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- ✅ [Visual Studio 2022](https://visualstudio.microsoft.com/)

---

## 🚀 Installation

### 1. Clone the Repository

```bash
git clone https://github.com/Ahmed-Abdulrahim/ScholarHub.MVC.git
cd ScholarHub.MVC 
```

### 2. Configure Database

Open `appsettings.json` in the **ITI.MVC.PL** project and update the connection string:

```json
{
  "ConnectionStrings": {
    "Conn1": "Server=YOUR_SERVER;Database=SchoolDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }
}
```

### 3. Apply Migrations

Open Package Manager Console (PMC) and run:

```powershell
Update-Database
```
*Or via CLI:*
```bash
dotnet ef database update --project ITI.MVC.DAL --startup-project ITI.MVC.PL
```

### 4. Run the Application

```bash
dotnet run --project ITI.MVC.PL
```

Access the application at: `https://localhost:7123` (or the port shown in your terminal).

---

## 🤝 Contributing

Contributions are welcome! Please follow these steps:

1. **Fork** the repository
2. **Create** a feature branch (`git checkout -b feature/NewFeature`)
3. **Commit** your changes (`git commit -m 'Add NewFeature'`)
4. **Push** to the branch (`git push origin feature/NewFeature`)
5. **Open** a Pull Request

---
