# 📦 Product API .NET Core

API RESTful desarrollada en ASP.NET Core para la gestión de productos, con operaciones CRUD completas, preparada para ejecutarse en contenedores junto con su base de datos SQL Server.

---

## 📌 Tecnologías

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Docker / Docker Compose
- Swagger (OpenAPI)
- C#

---

## 📈 Funcionalidades

- Obtener todos los productos `GET /products`
- Obtener un producto por ID `GET /products/{id}`
- Crear un nuevo producto `POST /products`
- Actualizar un producto existente `PUT /products/{id}`
- Eliminar un producto `DELETE /products/{id}`

---

## 📦 Estructura del Proyecto

/Controllers
/Services
/Models
/DTOs
/Data
/Migrations
/Dockerfile
/docker-compose.yml


---

## ⚙️ Configuración y Ejecución

### 📥 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)

---

### 🚀 Clonar Repositorio

git clone https://github.com/joselugo/product-api-dotnet-joselugo.git
cd product-api-dotnet-joselugo

### 🗄️ Ejecutar Migraciones
- desde la terminal: dotnet ef database update
