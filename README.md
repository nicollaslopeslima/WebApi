# 📋 WebApiEmpresa

WebApiEmpresa is a REST API built using .NET, MVC architecture, and SQL Server.

This project was developed to practice backend development concepts, API structuring, and relational database integration using custom HTTP endpoints.

The API manages two main entities:

* Empresa
* Jogos

Each game is linked to a company through the `EmpresaId` relationship.

---

# 🚀 Technologies

Csharp DotNet SQLServer Swagger

* C#
* .NET
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger

---

# ⚙️ Features

✅ Company endpoints
✅ Game endpoints
✅ SQL Server integration
✅ Entity Framework Core
✅ Relational database structure
✅ Swagger documentation
✅ REST API architecture

---

# 🗂️ Database Structure

## Empresa Table

| Column | Type   |
| ------ | ------ |
| Id     | int    |
| Nome   | string |

---

## Jogos Table

| Column    | Type   |
| --------- | ------ |
| Id        | int    |
| Nome      | string |
| EmpresaId | int    |

---

# 🔗 Relationship

Each game belongs to one company through the `EmpresaId` foreign key.

Example:

```json
{
  "id": 1,
  "nome": "The Witcher 3",
  "empresaId": 2
}
```

---

# 🌐 API Endpoints

## Empresa Endpoints

| Method | Endpoint                           | Description            |
| ------ | ---------------------------------- | ---------------------- |
| GET    | `/ListarEmpresas`                  | List all companies     |
| GET    | `/BuscarEmpresaPorId/{idEmpresa}`  | Get company by ID      |
| GET    | `/BuscarEmpresaPorIdJogo/{idJogo}` | Get company by game ID |
| POST   | `/CriarEmpresa`                    | Create a new company   |
| PUT    | `/EditarEmpresa`                   | Update company         |
| DELETE | `/ExcluirEmpresa`                  | Delete company         |

---

## Jogo Endpoints

| Method | Endpoint                              | Description             |
| ------ | ------------------------------------- | ----------------------- |
| GET    | `/BuscarJogoPorId/{idJogo}`           | Get game by ID          |
| GET    | `/BuscarJogoPorIdEmpresa/{idEmpresa}` | Get games by company ID |
| POST   | `/CriarJogo`                          | Create a new game       |
| PUT    | `/EditarJogo`                         | Update game             |
| DELETE | `/ExcluirJogo`                        | Delete game             |

---

# ⚙️ How to Run the Project

## 1️⃣ Clone the repository

```bash
git clone https://github.com/yourusername/GameCompanyAPI
```

## 2️⃣ Open the project in Visual Studio

## 3️⃣ Configure the database connection

Update the `appsettings.json` file:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=WebApiEmpresa;Trusted_Connection=True;"
}
```

## 4️⃣ Run the migrations

```bash
Update-Database
```

## 5️⃣ Run the application

The API will open with Swagger UI enabled.

---

# 📌 Project Status

⚠️ This project is currently under development.

The main goal is to improve backend development skills, API creation, and relational database integration using .NET and SQL Server.

---

# 🎯 Future Improvements

* JWT Authentication
* Repository Pattern
* Service Layer
* DTO validations
* Logging system
* Unit tests
* Docker support
* API versioning

---

# 📚 Purpose of the Project

This project was created to:

* Practice REST API development with .NET
* Improve SQL Server integration skills
* Work with relational databases
* Practice endpoint creation
* Reinforce backend architecture concepts
* Simulate real-world API development scenarios
