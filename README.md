# 📚 Library Management System API

This is an ASP.NET Core Web API for managing a library system. It supports features like book management, user registration, and more using a clean architecture approach.

---

## 🧰 Technologies Used

- ASP.NET Core 8 Web API
- Entity Framework Core
- MediatR (CQRS)
- FluentValidation
- xUnit & Moq (for unit testing)
- Swagger / Swashbuckle
- SQL Server or PostgreSQL (configurable)

---

## 🚀 Getting Started

### 📦 Prerequisites

Make sure you have the following installed:

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/) 
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

---

## ⚙️ How to Run the Application

1. **Clone the repository**

```bash
git clone https://github.com/Gideon-isa/library-management-api.git
cd library-management-api

Edit the appsettings.json or appsettings.Development.json in the WebApi project to update values

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LibraryDb;User Id=your_user;Password=your_password;"
}

 "JwtOptions": {
   "SigningKey": "",
   "Issuer": "",
   "Audience": "",
   "Subject": ""
 }

 Replace Infrastructure and WebApi with the actual project folder names if different.

 Run the API

```bash
dotnet run --libraryManagementSystem WebApi

Navigate to: https://localhost:7209/swagger/index.html to view Swagger UI.


Use tools like Postman or Swagger UI to test endpoints.

Make sure to pass the JWT token in the Authorization header like so:
Authorization: Bearer <your-token>