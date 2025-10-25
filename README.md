# 📦 Inventory Management System API

A simple, scalable and secure API for managing product inventory with automated stock alert.

---

## 🚀 Features

- **Product Management**
  - Full CRUD operations
  - Track stock levels and quantities

- **Low Stock Alert System**
  - Background job runs every **1 minute**
  - Detects products below threshold (default: **10**)
  - Records alerts in the `Notifications` table

- **Clean Architecture**
  - Controller → Service → Repository pattern  
  - EF Core for database operations  
  - Fully dependency-injected and maintainable  

- **Extensible Design**
  - Easy integration for Email / SMS / Push notifications  
  - Enterprise-ready structure  

---

## 🧰 Tech Stack

| Technology | Purpose |
|----------|----------|
| ASP.NET Core 9.0 | Framework |
| Entity Framework Core | ORM |
| PostgreSQL | Database |
| IHostedService | Automated tasks |
| Dependency Injection | Architecture |

---

## ⚙️ Getting Started

### ✅ 1️⃣ Clone the Repository

git clone https://github.com/Fidel-Jr/InventoryManagementAPI.git

cd InventoryManagementAPI

---

### ✅ 2️⃣ Configure the Database

Update appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=inventory_db;Username=yourusername;Password=yourpassword"
}


### Note:

⚠️ Ensure PostgreSQL is installed and running on your system.

⚠️ Host=localhost and Port=5432 are the default values for PostgreSQL.

⚠️ If your PostgreSQL server uses a different host or port, update them accordingly.

⚠️ Replace yourusername and yourpassword with your actual PostgreSQL credentials.


Apply migrations:

dotnet ef database update

---

### ✅ 3️⃣ Run the API
dotnet run

---

Expected logs:

⏰ Background job started.
🔍 Checking low stock products...

🔁 Low Stock Notification System

Runs every minute and checks:

Any product where Quantity < 10

Inserts a notification into the database

### 📨 Example Notification Record

| Id | Message | CreatedAt | IsRead |
|:--:|----------|------------|:------:|
| 1 | ⚠️ Product 'Milk' is low (Qty: 5) | 2025-10-22T12:00:00Z | false |

---

## 📌 API Endpoints Documentation

### 🛒 Products

| Method | Endpoint | Description |
|:------:|----------|-------------|
| GET | `/api/Products` | Get all products |
| GET | `/api/Products/{id}` | Get product by ID |
| POST | `/api/Products` | Create new product |
| PUT | `/api/Products/{id}` | Update product |
| DELETE | `/api/Products/{id}` | Delete product |

---

## 🚀 Continuous Improvement

This API is highly extensible and can always be improved to meet larger system demands or new use cases.
You can:

Integrate email/SMS gateways for real notifications

Add user dashboards and analytics

Implement multi-tenancy, audit logs, or role-based permissions

Scale the background job system using Hangfire, Quartz.NET, or Azure Functions

🧠 Designed for growth: The architecture allows continuous enhancement and can be adapted for enterprise-level inventory solutions.

---

Your feedback is always welcome and appreciated!

### Contact

💼 LinkedIn: [linkedin.com/in/fidel-jr](https://www.linkedin.com/in/colinares-jr/)
