# 📦 Inventory Management System API

A scalable and secure API for managing product inventory with automated stock alerts.

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
| BackgroundService / IHostedService | Automated tasks |
| Dependency Injection | Architecture |

---

## ⚙️ Getting Started

### ✅ 1️⃣ Clone the Repository
```bash
git clone https://github.com/<your-username>/InventoryManagementAPI.git
cd InventoryManagementAPI
